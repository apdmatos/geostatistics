package statistics.store.shapes;

import java.util.List;
import org.geotools.geometry.jts.ReferencedEnvelope;
import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public interface IShapeRepository {

    IShapeReader getShapes( 
            String sourceId, String indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);

    int countShapes( 
            String sourceId, String indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);

    ReferencedEnvelope getBounds( 
            String sourceId, String indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);
}
