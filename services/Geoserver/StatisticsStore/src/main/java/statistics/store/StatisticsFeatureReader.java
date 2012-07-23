package statistics.store;

import java.io.IOException;
import java.util.List;
import java.util.NoSuchElementException;
import org.geotools.data.FeatureReader;
import org.geotools.data.store.ContentEntry;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.model.indicator.IndicatorValue;
import statistics.store.feature.builders.FeatureBuilder;
import statistics.store.service.IStatisticsServiceProxy;
import statistics.store.shapes.IShapeData;
import statistics.store.shapes.IShapeReader;

/**
 *
 * @author Andre Matos
 */
public class StatisticsFeatureReader implements FeatureReader<SimpleFeatureType, SimpleFeature> {

    private ContentEntry _entry;
    private IShapeReader _shapes;
    private SimpleFeatureType _featureType;
    private FeatureBuilder _featureBuilder;
    private IStatisticsServiceProxy _proxy;
    
    private IShapeData _currentShape;
    private List<IndicatorValue> _currentValues;

    public StatisticsFeatureReader(
            ContentEntry entry,
            IShapeReader shapes,
            SimpleFeatureType featureType,
            FeatureBuilder builder,
            IStatisticsServiceProxy statisticsProxy)
    {
        this._entry             = entry;
        this._shapes            = shapes;
        this._featureType       = featureType;
        this._featureBuilder    = builder;
        this._proxy             = statisticsProxy;
    }

    @Override
    public SimpleFeatureType getFeatureType() {

        return _featureType;
    }

    @Override
    public SimpleFeature next() throws IOException, IllegalArgumentException, NoSuchElementException
    {
        return _featureBuilder.buildFeature(_currentShape, _currentValues);
    }

    @Override
    public boolean hasNext() throws IOException {

        while(_shapes.hasNext()) {
            IShapeData data = _shapes.next();
            List<IndicatorValue> values = _proxy.getIndicatorValue(data.getShapeId());
            if(values != null && values.size() > 0) {
                _currentShape = data;
                _currentValues = values;

                return true;
            }
        }

        return false;
    }

    @Override
    public void close() throws IOException {
        _shapes.dispose();
    }
}
