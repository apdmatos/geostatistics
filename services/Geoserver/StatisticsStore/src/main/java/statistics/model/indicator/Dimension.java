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

    public boolean containsAnyAttribute(List<String> attrs) {
        
        for (String attr : attrs) {
            if(containsAttribute(attr))
                return true;
        }

        return false;
    }

    public boolean containsAttribute(String attr) {

        return dimensionAttributes.contains(attr);
    }

    @Override
    public String toString() {
        StringBuffer b = new StringBuffer();
        toString(b);
        return b.toString();
    }

    public void toString(StringBuffer buffer) {
        buffer.append(id);
        for (String attr : dimensionAttributes) {
            buffer.append(",");
            buffer.append(attr);
        }
    }
}
