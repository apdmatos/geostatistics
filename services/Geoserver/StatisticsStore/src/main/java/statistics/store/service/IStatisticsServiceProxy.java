package statistics.store.service;

import java.util.List;
import statistics.model.indicator.Metadata;
import statistics.model.indicator.IndicatorValue;
import statistics.model.indicator.IndicatorRange;

/**
 *
 * @author Andre Matos
 */
public interface IStatisticsServiceProxy {

//    void setIndicatorMetadata(Metadata metadata);
//
//    void setShapeFilters(List<String> shapeIds);

    void requestIndicatorValues(Metadata metadata, List<String> shapeIds);

    IndicatorValue getIndicatorValue(String shapeId);

    IndicatorRange getIndicatorRange();
}
