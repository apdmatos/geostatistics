package statistics.model.indicator;

import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class GeographicDimension extends Dimension {

    public String shapeLevel;

    public GeographicDimension(String shapeLevel) {
        super();
        this.shapeLevel = shapeLevel;
    }

    public GeographicDimension(List<DimensionAttribute> dimensionAttributes, String shapeLevel) {
        super(dimensionAttributes);
        this.shapeLevel = shapeLevel;
    }
}
