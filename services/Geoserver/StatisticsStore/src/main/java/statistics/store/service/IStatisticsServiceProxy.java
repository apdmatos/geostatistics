package statistics.store.service;

import java.util.List;
import statistics.model.indicator.IndicatorMetadata;
import statistics.model.indicator.IndicatorValue;

/**
 *
 * @author Andre Matos
 */
public interface IStatisticsServiceProxy {

    void setIndicatorMetadata(IndicatorMetadata metadata);

    void setShapeFilters(List<String> shapeIds);

    IndicatorValue getIndicatorValue(String shapeId);
}
