package statistics.model.indicator;

import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class IndicatorValue {

    public List<Dimension> dimensionFilter;
    public double value;

    public IndicatorValue()  {
    }

    public IndicatorValue(List<Dimension> filters, double value) {
        this.dimensionFilter = filters;
        this.value = value;
    }

}
