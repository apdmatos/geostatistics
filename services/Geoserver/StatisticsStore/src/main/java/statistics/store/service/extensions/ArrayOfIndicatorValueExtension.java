package statistics.store.service.extensions;

import java.util.ArrayList;
import java.util.List;
import org.datacontract.schemas._2004._07.providerdatacontracts.ArrayOfIndicatorValue;
import org.datacontract.schemas._2004._07.providerdatacontracts.DimensionFilter;
import org.datacontract.schemas._2004._07.providerdatacontracts.IndicatorValue;

/**
 *
 * @author Andre Matos
 */
public class ArrayOfIndicatorValueExtension extends IndicatorValue {


    public static List<statistics.model.indicator.IndicatorValue> getIndicatorValues(ArrayOfIndicatorValue value, String dimensionId, String attributeId) {

        List<statistics.model.indicator.IndicatorValue> list =
                new ArrayList<statistics.model.indicator.IndicatorValue>();

        for (IndicatorValue indicatorValue : value.getIndicatorValue()) {

            List<DimensionFilter> projected = indicatorValue.getProjected().isNil() == true ?
                null :
                indicatorValue.getProjected().getValue().getDimensionFilter();

            List<DimensionFilter> filters = indicatorValue.getFilters().isNil() == true ?
                null :
                indicatorValue.getFilters().getValue().getDimensionFilter();

            boolean inProjected = false;
            if(filters != null)
                inProjected = appendIndicatorValueIfMatch(list, projected, dimensionId, attributeId, indicatorValue);

            if (!inProjected && filters != null)
                appendIndicatorValueIfMatch(list, filters, dimensionId, attributeId, indicatorValue);
        }

        return list;
    }

    private static boolean appendIndicatorValueIfMatch (
            List<statistics.model.indicator.IndicatorValue> list,
            List<DimensionFilter> filters,
            String dimensionId,
            String attributeId,
            IndicatorValue value) {


        for (DimensionFilter dimensionFilter : filters) {

            if(dimensionId.equals( dimensionFilter.getDimensionId().getValue() )) {
                if(dimensionFilter.getAttributes().getValue().getString().contains(attributeId) == true) {
                    list.add(IndicatorValueExtension.toIndicatorValue(value));
                    return true;
                }
            }
        }

        return false;
    }

}
