package statistics.store.shapes;

import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public interface IShapeRepository {

    IShapeReader getShapes(String indicator, String shapeLevel, BBOX bbox, String[] shapeIds);
    
}
