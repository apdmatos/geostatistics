package statistics.store.shapes;

import org.geotools.data.simple.SimpleFeatureCollection;
import org.geotools.data.simple.SimpleFeatureIterator;
import org.opengis.feature.simple.SimpleFeature;

/**
 *
 * @author Andre Matos
 */
public class ShapeReader implements IShapeReader {

    private final SimpleFeatureCollection _collection;
    private SimpleFeatureIterator _iterator;

    public ShapeReader(SimpleFeatureCollection collection){
        _collection = collection;
        if(_collection != null)
            _iterator = collection.features();
    }

    @Override
    public boolean hasNext() {
        if(_iterator == null) return false;
        return _iterator.hasNext();
    }

    @Override
    public IShapeData next() {
        if(_iterator == null) return null;
        SimpleFeature feature = _iterator.next();
        if(feature != null) return new Shape(feature);
        return null;
    }

    @Override
    public void dispose() {
        if(_iterator != null) _iterator.close();
    }

}
