package statistics.store.service;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.List;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.namespace.QName;
import org.datacontract.schemas._2004._07.providerdatacontracts.ArrayOfDimensionFilter;
import org.datacontract.schemas._2004._07.providerdatacontracts.IndicatorValueRange;
import org.datacontract.schemas._2004._07.statisticsproxyservicedefenitions.IndicatorValues;
import org.tempuri.DefaultStatisticsProxyImpl;
import org.tempuri.IStatisticsProxyService;
import statistics.model.indicator.Dimension;
import statistics.model.indicator.GeographicDimension;
import statistics.model.indicator.Metadata;
import statistics.model.indicator.IndicatorValue;
import statistics.model.indicator.IndicatorRange;
import statistics.store.service.extensions.ArrayOfDimensionFilterExtension;
import statistics.store.service.extensions.ArrayOfIndicatorValueExtension;
import statistics.store.service.extensions.IndicatorValueRangeExtension;
import statistics.utils.concurrent.ManualResetEvent;

/**
 *
 * @author Andre Matos
 */
public class StatisticsServiceProxyImpl implements IStatisticsServiceProxy {

    protected static final QName qname = new QName("http://tempuri.org/", "DefaultStatisticsProxyImpl");
    protected final ThreadPoolExecutor _threadPool;

    protected volatile Metadata _metadata;
    protected volatile List<String> _shapeIds;
    protected volatile URL _serviceURL;

    // service responses
    private volatile IndicatorValues indicatorValuesResponse;
    private volatile IndicatorValueRange indicatorValueRange;
    private volatile DefaultStatisticsProxyImpl proxy;

    // service requesters
    private RequestValues valuesRequester;
    private RequestValuesRange valuesRangeRequester;

    // response lockers
    private volatile ManualResetEvent valuesEvent = new ManualResetEvent(false);
    private volatile ManualResetEvent valuesRangeEvent = new ManualResetEvent(false);

    private class RequestValues implements Runnable {
        @Override
        public void run() {
            IStatisticsProxyService service = getProxyInstance();
            indicatorValuesResponse = service.getIndicatorValues(
                                            _metadata.sourceId,
                                            _metadata.indicatorId,
                                            getFilterDimensions(),
                                            getProjectedDimensions()
                                      );
            valuesEvent.set();
        }
    }
    
    private class RequestValuesRange implements Runnable {
        @Override
        public void run() {

            IStatisticsProxyService service = getProxyInstance();
            indicatorValueRange = service.getIndicatorValuesRange(
                                        _metadata.sourceId,
                                        _metadata.indicatorId,
                                        getFilterDimensions(),
                                        getProjectedDimensions(),
                                        getShapeLevel()
                                   );
            valuesRangeEvent.set();
        }
    }

    private synchronized IStatisticsProxyService getProxyInstance() {
        // configure the endpoint
        if(proxy == null)
            proxy = new DefaultStatisticsProxyImpl(_serviceURL, qname);
        
        return proxy.getBasicHttpBindingIStatisticsProxyService();
    }

    private ArrayOfDimensionFilter getFilterDimensions() {

        ArrayOfDimensionFilterExtension dimensionFilter = new ArrayOfDimensionFilterExtension();
        for (Dimension dimension : _metadata.dimensions)
            if(! (dimension instanceof GeographicDimension))
                dimensionFilter.addDimension(dimension);

        return dimensionFilter;
    }

    private ArrayOfDimensionFilter getProjectedDimensions() {
        
        GeographicDimension dimension = _metadata.getGeographicDimension();
        ArrayOfDimensionFilterExtension dimensionFilter = new ArrayOfDimensionFilterExtension();
        dimensionFilter.addDimension(dimension.id, _shapeIds);

        return dimensionFilter;
    }

    private String getShapeLevel() {
        return _metadata.getGeographicDimension().shapeLevel;
    }

    public StatisticsServiceProxyImpl(String serviceURL, ThreadPoolExecutor threadpool) 
            throws MalformedURLException {
        
        _threadPool = threadpool;
        _serviceURL = new URL(serviceURL);
        valuesRequester = new RequestValues();
        valuesRangeRequester = new RequestValuesRange();
    }

    public StatisticsServiceProxyImpl(
            String serviceURL, ThreadPoolExecutor threadpool,
            Metadata metadata, List<String> shapeIds) throws MalformedURLException {

        this(serviceURL, threadpool);
        requestIndicatorValues(metadata, shapeIds);
    }

    @Override
    public void requestIndicatorValues(Metadata metadata, List<String> shapeIds) throws IllegalArgumentException {

        if(_metadata == null && _shapeIds == null){
            _metadata = metadata;
            _shapeIds = shapeIds;

            if(_shapeIds == null || _shapeIds.size() == 0) {
                valuesRangeEvent.set();
                valuesEvent.set();
            } else {
                valuesRangeEvent.reset();
                valuesEvent.reset();

                _threadPool.execute(valuesRequester);
                _threadPool.execute(valuesRangeRequester);
            }
        }else
            throw new IllegalArgumentException("This class has been initialized");
    }

    @Override
    public IndicatorValue getIndicatorValue(String shapeId) {
        try {
            valuesEvent.waitOne();
        } catch (InterruptedException ex) {
            Logger.getLogger(StatisticsServiceProxyImpl.class.getName()).log(Level.SEVERE, "Thread was interrupted while waiting for values", ex);
            return null;
        }

        if(indicatorValuesResponse == null || indicatorValuesResponse.getValues().getValue() == null)
            return null;


        List<statistics.model.indicator.IndicatorValue> values = ArrayOfIndicatorValueExtension.getIndicatorValues (
                indicatorValuesResponse.getValues().getValue(),
                _metadata.getGeographicDimension().id,
                shapeId);
        
        if(values == null || values.size() == 0) return null;
        return values.get(0);
    }

    @Override
    public IndicatorRange getIndicatorRange() {
        try {
            valuesEvent.waitOne();
        } catch (InterruptedException ex) {
            Logger.getLogger(StatisticsServiceProxyImpl.class.getName()).log(Level.SEVERE, "Thread was interrupted while waiting for values", ex);
            return null;
        }

        if(indicatorValueRange == null || indicatorValueRange.getMaximum() == null || indicatorValueRange.getMaximum().isNil())
            return null;

        return IndicatorValueRangeExtension.toIndicatorRange(indicatorValueRange);
    }
}
