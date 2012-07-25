package statistics.store.feature.builders;

import java.util.List;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.model.indicator.IndicatorRangeFuture;
import statistics.model.indicator.IndicatorValue;
import statistics.queryparser.StatisticsRequestParameters;
import statistics.store.shapes.IShapeData;

/**
 *
 * @author Andre Matos
 */
public abstract class FeatureBuilder  {

    protected IndicatorRangeFuture range;
    protected SimpleFeatureType featureType;
    protected StatisticsRequestParameters query;
    protected String shapeLevel;

    public FeatureBuilder(SimpleFeatureType featureType) {
        this.featureType = featureType;
    }

    public FeatureBuilder(SimpleFeatureType featureType, IndicatorRangeFuture range, StatisticsRequestParameters query, String shapeLevel) {
        this.featureType    = featureType;
        this.range          = range;
        this.query          = query;
        this.shapeLevel     = shapeLevel;
    }

    public void setFeatureType(SimpleFeatureType featureType) {
        this.featureType = featureType;
    }

    public SimpleFeatureType getFeatureType() {
        return featureType;
    }

    public void setIndicatorRange(IndicatorRangeFuture range) {
        this.range = range;
    }

    public IndicatorRangeFuture getIndicatorRange() {
        return range;
    }

    public void setRequestParameters(StatisticsRequestParameters query) {
        this.query = query;
    }

    public StatisticsRequestParameters getRequestParameters() {
        return query;
    }

    public void setShapeLevel(String shapeLevel) {
        this.shapeLevel = shapeLevel;
    }

    public String getShapeLevel() {
        return shapeLevel;
    }

    public abstract SimpleFeature buildFeature(IShapeData shape, List<IndicatorValue> value);

}
