package statistics.store;

import java.io.IOException;
import java.util.NoSuchElementException;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.data.FeatureReader;
import org.geotools.data.store.ContentEntry;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.store.shapes.IShapeReader;

/**
 *
 * @author Andre Matos
 */
public class StatisticsFeatureReader implements FeatureReader<SimpleFeatureType, SimpleFeature> {

    private ContentEntry _entry;
    private IShapeReader _shapes;
    private FeatureBuilder _featureBuilder;

    public StatisticsFeatureReader(ContentEntry entry, IShapeReader shapes, FeatureBuilder featureBuilder){
        this._entry = entry;
        this._shapes = shapes;
        _featureBuilder = featureBuilder;
    }

    @Override
    public SimpleFeatureType getFeatureType() {

        return _featureBuilder.getFeatureType(  );
    }

    @Override
    public SimpleFeature next() throws IOException, IllegalArgumentException, NoSuchElementException {
        //return _shapes.next().getSimpleFeature();

        return _featureBuilder.buildFeature(_shapes.next());
    }

    @Override
    public boolean hasNext() throws IOException {
        return _shapes.hasNext();
    }

    @Override
    public void close() throws IOException {
        _shapes.dispose();
    }
}
