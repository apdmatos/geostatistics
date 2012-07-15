package statistics.store;

import java.io.IOException;
import java.util.NoSuchElementException;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.data.FeatureReader;
import org.geotools.data.store.ContentEntry;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.queryparser.StatisticsQueryParser;
import statistics.queryparser.StatisticsRequestParameters;
import statistics.store.shapes.IShapeReader;

/**
 *
 * @author Andre Matos
 */
public class StatisticsFeatureReader implements FeatureReader<SimpleFeatureType, SimpleFeature> {

    private ContentEntry _entry;
    private IShapeReader _shapes;
    private FeatureBuilder _featureBuilder;
    private StatisticsQueryParser query;

    public StatisticsFeatureReader(
            ContentEntry entry,
            IShapeReader shapes,
            FeatureBuilder featureBuilder,
            StatisticsQueryParser query)
    {
        this._entry             = entry;
        this._shapes            = shapes;
        this._featureBuilder    = featureBuilder;
        this.query              = query;
    }

    @Override
    public SimpleFeatureType getFeatureType() {

        return _featureBuilder.getFeatureType(  );
    }

    @Override
    public SimpleFeature next() throws IOException, IllegalArgumentException, NoSuchElementException {
        //return _shapes.next().getSimpleFeature();

        return _featureBuilder.buildFeature(query.getParameters(), _shapes.next());
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
