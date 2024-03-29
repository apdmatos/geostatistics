package statistics.store.service.extensions;

import java.util.List;
import org.datacontract.schemas._2004._07.providerdatacontracts.IndicatorValue;
import statistics.model.indicator.Dimension;

/**
 *
 * @author Andre Matos
 */
public class IndicatorValueExtension extends IndicatorValue {

    public static statistics.model.indicator.IndicatorValue toIndicatorValue(IndicatorValue value) {

        double val = value.getValue();
        List<Dimension> filters = ArrayOfDimensionFilterExtension.toDimensionList(value.getFilters().getValue());
        List<Dimension> projected = ArrayOfDimensionFilterExtension.toDimensionList(value.getProjected().getValue());

        return new statistics.model.indicator.IndicatorValue(filters, projected, val);
    }



}
