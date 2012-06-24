package statistics.store.shapes;

import com.vividsolutions.jts.geom.Geometry;
import org.opengis.feature.simple.SimpleFeature;

/**
 *
 * @author Andre Matos
 */
public interface IShapeData {

    Geometry getFeatureGeometry();

    String getShapeId();

    String getShapeName();

    SimpleFeature getSimpleFeature();
}
