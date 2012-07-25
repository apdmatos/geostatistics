package statistics.store.service;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ThreadPoolExecutor;
import javax.xml.namespace.QName;
import org.datacontract.schemas._2004._07.providerdatacontracts.ArrayOfDimensionFilter;
import org.datacontract.schemas._2004._07.providerdatacontracts.IndicatorValueRange;
import org.datacontract.schemas._2004._07.statisticsproxyservicedefenitions.IndicatorValues;
import org.tempuri.DefaultStatisticsProxyImpl;
import org.tempuri.IStatisticsProxyService;
import statistics.model.indicator.Dimension;
import statistics.model.indicator.GeographicDimension;
import statistics.model.indicator.IndicatorConfiguration;
import statistics.model.indicator.IndicatorRangeFuture;
import statistics.model.indicator.IndicatorValue;
import statistics.model.indicator.IndicatorValuesFuture;
import statistics.store.service.extensions.ArrayOfDimensionFilterExtension;
import statistics.store.service.extensions.ArrayOfIndicatorValueExtension;
import statistics.store.service.extensions.IndicatorValueExtension;

/**
 *
 * @author Andre Matos
 */
public class StatisticsServiceProxyImpl implements IStatisticsServiceProxy {

    protected static final QName qname = new QName("http://tempuri.org/", "DefaultStatisticsProxyImpl");
    protected final ThreadPoolExecutor _threadPool;

    private volatile DefaultStatisticsProxyImpl proxy;
    protected volatile URL _serviceURL;

    private class RequestValues implements Runnable {

        IndicatorValuesFuture values;
        IndicatorConfiguration _config;
        List<String> _shapeIds;

        private RequestValues(IndicatorValuesFuture values, IndicatorConfiguration config, List<String> shapeIds) {
            this.values     = values;
            this._config    = config;
            this._shapeIds  = shapeIds;
        }

        @Override
        public void run() {
            IStatisticsProxyService service = getProxyInstance();
            IndicatorValues indicatorValuesResponse = service.getIndicatorValues(
                _config.sourceId,
                _config.indicatorId,
                convertDimensions(_config.filter, _shapeIds),
                convertDimensions(_config.projected, _shapeIds)
            );

            List<IndicatorValue> convertedValues = null;
            if(!indicatorValuesResponse.getValues().isNil())
                convertedValues = ArrayOfIndicatorValueExtension.toIndicatorValueList(indicatorValuesResponse.getValues().getValue());
            else
                convertedValues = new ArrayList<IndicatorValue>();

            values.addValues(convertedValues);
        }
    }

    private class RequestValuesRange implements Runnable {

        IndicatorRangeFuture range;
        IndicatorConfiguration _config;
        List<String> _shapeIds;

        private RequestValuesRange(IndicatorRangeFuture range, IndicatorConfiguration config, List<String> shapeIds) {
            this.range      = range;
            this._config    = config;
            this._shapeIds  = shapeIds;
        }

        @Override
        public void run() {

            IStatisticsProxyService service = getProxyInstance();
            IndicatorValueRange indicatorValueRange = service.getIndicatorValuesRange(
                _config.sourceId,
                _config.indicatorId,
                convertDimensions(_config.filter, this._shapeIds),
                convertDimensions(_config.projected, this._shapeIds),
                getShapeLevel(_config)
            );

            IndicatorValue max = IndicatorValueExtension.toIndicatorValue(indicatorValueRange.getMaximum().getValue());
            IndicatorValue min = IndicatorValueExtension.toIndicatorValue(indicatorValueRange.getMinimum().getValue());
            range.setRange(max, min);
        }
    }

    private synchronized IStatisticsProxyService getProxyInstance() {
        // configure the endpoint
        if(proxy == null)
            proxy = new DefaultStatisticsProxyImpl(_serviceURL, qname);

        return proxy.getBasicHttpBindingIStatisticsProxyService();
    }

    private ArrayOfDimensionFilter convertDimensions(List<Dimension> dimensions, List<String> shapeIds) {

        ArrayOfDimensionFilterExtension dimensionFilter = new ArrayOfDimensionFilterExtension();
        for (Dimension dimension : dimensions) {
            if(dimension instanceof GeographicDimension)
                dimensionFilter.addDimension(dimension.id, shapeIds);
            else dimensionFilter.addDimension(dimension);
        }

        return dimensionFilter;
    }

    private String getShapeLevel(IndicatorConfiguration config) {
        return config.getGeographicDimension().shapeLevel;
    }


    public StatisticsServiceProxyImpl(String serviceURL, ThreadPoolExecutor threadpool)
            throws MalformedURLException {

        _threadPool = threadpool;
        _serviceURL = new URL(serviceURL);
    }

    @Override
    public IndicatorValuesFuture getIndicatorValues(IndicatorConfiguration config, List<String> shapeIds) {

        IndicatorValuesFuture values = new IndicatorValuesFuture();
        RequestValues valuesRequester = new RequestValues(values, config, shapeIds);
        _threadPool.execute(valuesRequester);

        return values;
    }

    @Override
    public IndicatorRangeFuture getIndicatorRange(IndicatorConfiguration config, List<String> shapeIds) {

        IndicatorRangeFuture range = new IndicatorRangeFuture();
        RequestValuesRange valuesRangeRequester = new RequestValuesRange(range, config, shapeIds);
        _threadPool.execute(valuesRangeRequester);
        
        return range;
    }

}
