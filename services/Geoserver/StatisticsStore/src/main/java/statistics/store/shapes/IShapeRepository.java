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
            int sourceId, int indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);

    int countShapes( 
            int sourceId, int indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);

    ReferencedEnvelope getBounds( 
            int sourceId, int indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);

    List<String> getShapeIds(
            int sourceId, int indicatorId,
            String shapeLevel, BBOX bbox, List<String> shapeIds);
}
