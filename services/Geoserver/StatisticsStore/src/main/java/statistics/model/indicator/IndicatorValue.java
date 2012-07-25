package statistics.model.indicator;

import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class IndicatorValue {

    public List<Dimension> filter;
    public List<Dimension> projected;
    public double value;

    public IndicatorValue()  {
    }

    public IndicatorValue(List<Dimension> filters, List<Dimension> projected, double value) {
        this.filter = filters;
        this.projected = projected;
        this.value = value;
    }

    public boolean matchFilter(List<Dimension> projectedFilter, String shapeId) {

        for (Dimension dimension : projectedFilter) {

            Dimension d = getDimensionById(dimension.id);
            boolean contains = false;

            if (dimension instanceof GeographicDimension)
                contains = d.containsAttribute(shapeId);
            else
                contains = d.containsAnyAttribute(dimension.dimensionAttributes);

            if(!contains) return false;
        }

        return true;
    }

    public Dimension getDimensionById(String dimensionId) {

        for (Dimension dimension : filter) {
            if (dimension.id.equals(dimensionId)) return dimension;
        }

        for (Dimension dimension : projected) {
            if(dimension.id.equals(dimensionId)) return dimension;
        }

        return null;
    }

}
