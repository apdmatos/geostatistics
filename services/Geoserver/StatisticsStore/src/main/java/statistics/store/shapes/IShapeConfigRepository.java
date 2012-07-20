package statistics.store.shapes;

import statistics.model.shape.ShapeConfiguration;

/**
 *
 * @author Andre Matos
 */
public interface IShapeConfigRepository {

    ShapeConfiguration getShapeConfiguration(int sourceId, int indicatorId, String geoLevel);
}
