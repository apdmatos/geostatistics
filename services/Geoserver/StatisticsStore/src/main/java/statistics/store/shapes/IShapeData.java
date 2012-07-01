package statistics.store.shapes;

import com.vividsolutions.jts.geom.Geometry;
import org.opengis.feature.simple.SimpleFeature;

/**
 *
 * @author Andre Matos
 */
public interface IShapeData {

    String getFeatureId();

    Geometry getFeatureGeometry();

    String getShapeId();

    String getShapeParentId();

    String getShapeName();

//    SimpleFeature getSimpleFeature();
}
