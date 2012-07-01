package statistics.store.shapes;

import statistics.model.shape.ShapeConfiguration;

/**
 *
 * @author Andre Matos
 */
public interface IShapeConfigRepository {

    ShapeConfiguration getShapeConfiguration(String sourceId, String indicatorId, String geoLevel);
}
