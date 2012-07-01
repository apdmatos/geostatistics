package statistics.db;

import java.util.ArrayList;
import java.util.List;
import statistics.model.shape.ShapeConfiguration;
import statistics.model.shape.ShapeLevel;
import statistics.model.shape.file.ShapefileConfiguration;
import statistics.model.shape.file.ShapefileLevel;
import statistics.store.shapes.IShapeConfigRepository;

/**
 *
 * @author Andre Matos
 */
public class ShapeConfigRepository implements IShapeConfigRepository {

    public ShapeConfigRepository(){}

    public ShapeConfiguration getShapeConfiguration(String sourceId, String indicatorId, String geoLevel) {

        List<ShapeLevel> levels = new ArrayList<ShapeLevel>();
        levels.add(new ShapefileLevel("NUTS1", "NUTS1\\nuts1.shp"));
        levels.add(new ShapefileLevel("NUTS2", "NUTS2\\nuts2.shp"));
        levels.add(new ShapefileLevel("NUTS3", "NUTS3\\nuts3.shp"));
        levels.add(new ShapefileLevel("District", "Distritos\\distritos.shp"));
        levels.add(new ShapefileLevel("Municipality", "Concelhos\\concelhos.shp"));
        levels.add(new ShapefileLevel("Parish", "Freguesias\\freguesias.shp"));

        return new ShapefileConfiguration(levels, "D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\processed");
    }
}
