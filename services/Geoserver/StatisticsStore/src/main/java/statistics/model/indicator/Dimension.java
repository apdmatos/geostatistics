package statistics.model.indicator;

import java.util.ArrayList;
import java.util.List;

public class Dimension {

    public String id;
    public List<DimensionAttribute> dimensionAttributes;

    public Dimension() {
        this.dimensionAttributes = new ArrayList<DimensionAttribute>();
    }

    public Dimension(List<DimensionAttribute> dimensionAttributes)
    {
        this.dimensionAttributes = dimensionAttributes;
    }

    public void addAttribute(DimensionAttribute attribute)
    {
        dimensionAttributes.add(attribute);
    }
}
