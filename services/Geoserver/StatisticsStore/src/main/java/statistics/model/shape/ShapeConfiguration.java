package statistics.model.shape;

import java.util.List;

/**
 *
 * @author Andre Matos
 */
public abstract class ShapeConfiguration {

    public List<ShapeLevel> levels;
    
    public ShapeConfiguration(List<ShapeLevel> levels){
        this.levels = levels;
    }

    public ShapeLevel getConfigurationLevel(String geoLevel){

        for (int i = 0; i < levels.size(); i++) {
            ShapeLevel shapeLevel = levels.get(i);
            if(shapeLevel.geographicLevelCode.equalsIgnoreCase(geoLevel)){
                return shapeLevel;
            }
        }

        return null;
    }
}
