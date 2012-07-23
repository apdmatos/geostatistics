package statistics.store;

import java.io.IOException;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.logging.Level;
import java.util.logging.Logger;
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
        Logger.getLogger(StatisticsFeatureReader.class.getName()).log (
            Level.INFO,
            "next -> _currentShape != null ? " + (_currentShape != null) + "_currentValues != null ? " + (_currentValues != null)
        );

        if(_currentShape != null && _currentValues != null)
            return _featureBuilder.buildFeature(_currentShape, _currentValues);

        return null;
    }

    @Override
    public boolean hasNext() throws IOException {

        Logger.getLogger(StatisticsFeatureReader.class.getName()).log (
            Level.INFO,
            "hasNext"
        );

        while(_shapes.hasNext()) {
            
            IShapeData data = _shapes.next();
            List<IndicatorValue> values = _proxy.getIndicatorValue(data.getShapeId());

            Logger.getLogger(StatisticsFeatureReader.class.getName()).log (
                Level.INFO,
                "hasNext -> shapeid: " + data.getShapeId() + " contains values = " + (values != null && values.size() > 0)
            );

            if(values != null && values.size() > 0) {
                _currentShape = data;
                _currentValues = values;

                return true;
            }
        }
        _currentShape = null;
        _currentValues = null;

        return false;
    }

    @Override
    public void close() throws IOException {

        Logger.getLogger(StatisticsFeatureReader.class.getName()).log (
            Level.INFO,
            "closing reader"
        );

        _shapes.dispose();
    }
}
