package statistics.store;

import java.io.IOException;
import java.util.NoSuchElementException;
import org.geotools.data.FeatureReader;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;

/**
 *
 * @author Andre Matos
 */
public class StatisticsFeatureReader implements FeatureReader<SimpleFeatureType, SimpleFeature> {

    @Override
    public SimpleFeatureType getFeatureType() {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public SimpleFeature next() throws IOException, IllegalArgumentException, NoSuchElementException {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean hasNext() throws IOException {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void close() throws IOException {
        throw new UnsupportedOperationException("Not supported yet.");
    }

}
