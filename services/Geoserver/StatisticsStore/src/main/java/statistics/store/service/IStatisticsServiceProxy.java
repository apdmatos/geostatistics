package statistics.store.service;

import java.util.List;
import statistics.model.indicator.IndicatorConfiguration;
import statistics.model.indicator.IndicatorValue;
import statistics.model.indicator.IndicatorRange;

/**
 *
 * @author Andre Matos
 */
public interface IStatisticsServiceProxy {

    void requestIndicatorValues(IndicatorConfiguration config, List<String> shapeIds);

    IndicatorValue getIndicatorValue(String shapeId);

    IndicatorRange getIndicatorRange();
}
