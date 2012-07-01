package statistics.factory;

import statistics.db.ShapeConfigRepository;
import statistics.model.shape.ShapeConfiguration;
import statistics.model.shape.file.ShapefileConfiguration;
import statistics.store.shapes.IShapeConfigRepository;
import statistics.store.shapes.IShapeRepository;
import statistics.store.shapes.shapefile.ShapefileRepository;

/**
 *
 * @author Andre Matos
 */
public final class StatisticsFactory {

    public static IShapeRepository getShapeRepository(ShapeConfiguration shapeConfig){

        if(shapeConfig instanceof ShapefileConfiguration)
            return new ShapefileRepository((ShapefileConfiguration)shapeConfig);

        return null;

    }

    public static IShapeConfigRepository getShapeConfigRepository() {
        return new ShapeConfigRepository();
    }

}
