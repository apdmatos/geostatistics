package statistics.model.indicator;

import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class GeographicDimension extends Dimension {

    public String shapeLevel;

    public GeographicDimension(String dimensionId, String shapeLevel) {
        super(dimensionId);
        this.shapeLevel = shapeLevel;
    }

    public GeographicDimension(String dimensionId, List<String> dimensionAttributes, String shapeLevel) {
        super(dimensionId, dimensionAttributes);
        this.shapeLevel = shapeLevel;
    }
}
