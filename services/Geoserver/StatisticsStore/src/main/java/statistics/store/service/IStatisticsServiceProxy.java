package statistics.store.service;

import java.util.List;
import statistics.model.indicator.IndicatorConfiguration;
import statistics.model.indicator.IndicatorRangeFuture;
import statistics.model.indicator.IndicatorValuesFuture;

/**
 *
 * @author Andre Matos
 */
public interface IStatisticsServiceProxy {

    IndicatorValuesFuture getIndicatorValues(IndicatorConfiguration config, List<String> shapeIds);

    IndicatorRangeFuture getIndicatorRange(IndicatorConfiguration config, List<String> shapeIds);
}
