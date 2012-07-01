package statistics.model.shape.file;

import java.io.File;
import java.util.List;
import statistics.model.shape.ShapeConfiguration;
import statistics.model.shape.ShapeLevel;

/**
 *
 * @author Andre Matos
 */
public class ShapefileConfiguration extends ShapeConfiguration {

    public String shapefileBasePath;

    public ShapefileConfiguration(List<ShapeLevel> levels, String shapefilePath) {
        super(levels);
        this.shapefileBasePath = shapefilePath;
    }

    public File getShapefilePath(String geoLevel) {

        ShapeLevel level = super.getConfigurationLevel(geoLevel);
        if(level != null && level instanceof ShapefileLevel) {
            
            String fileName = ((ShapefileLevel)level).shapefilePath;
            return new File(shapefileBasePath, fileName);
        }

        return null;
    }

}
