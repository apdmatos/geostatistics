package statistics.store.service.extensions;

import org.datacontract.schemas._2004._07.providerdatacontracts.IndicatorValueRange;
import statistics.model.indicator.IndicatorRange;

/**
 *
 * @author Andre Matos
 */
public class IndicatorValueRangeExtension extends IndicatorValueRange {


    public static IndicatorRange toIndicatorRange(IndicatorValueRange range) {

        return new IndicatorRange (
                IndicatorValueExtension.toIndicatorValue(range.getMaximum().getValue()),
                IndicatorValueExtension.toIndicatorValue(range.getMinimum().getValue())
        );
    }

}
