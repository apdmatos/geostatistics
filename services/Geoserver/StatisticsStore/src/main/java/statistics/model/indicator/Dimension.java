package statistics.model.indicator;

import java.util.ArrayList;
import java.util.List;

public class Dimension {

    public String id;
    public List<String> dimensionAttributes;

    public Dimension(String dimensionId) {
        this.id = dimensionId;
        this.dimensionAttributes = new ArrayList<String>();
    }

    public Dimension(String dimensionId, List<String> dimensionAttributes)
    {
        this.id = dimensionId;
        this.dimensionAttributes = dimensionAttributes;
    }

    public void addAttribute(String attribute)
    {
        dimensionAttributes.add(attribute);
    }
}
