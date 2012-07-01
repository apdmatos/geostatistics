package statistics.store.shapes;

import org.geotools.geometry.jts.ReferencedEnvelope;
import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public interface IShapeRepository {

    IShapeReader getShapes( 
            String sourceId, String indicatorId,
            String shapeLevel, BBOX bbox, String[] shapeIds);

    int countShapes( 
            String sourceId, String indicatorId,
            String shapeLevel, BBOX bbox, String[] shapeIds);

    ReferencedEnvelope getBounds( 
            String sourceId, String indicatorId,
            String shapeLevel, BBOX bbox, String[] shapeIds);
}
