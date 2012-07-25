//package statistics.store.service.extensions;
//
//import org.datacontract.schemas._2004._07.providerdatacontracts.IndicatorValueRange;
//import statistics.model.indicator.IndicatorRangeFuture;
//
///**
// *
// * @author Andre Matos
// */
//public class IndicatorValueRangeExtension extends IndicatorValueRange {
//
//
//    public static IndicatorRangeFuture toIndicatorRange(IndicatorValueRange range) {
//
//        return new IndicatorRangeFuture (
//                IndicatorValueExtension.toIndicatorValue(range.getMaximum().getValue()),
//                IndicatorValueExtension.toIndicatorValue(range.getMinimum().getValue())
//        );
//    }
//
//}
