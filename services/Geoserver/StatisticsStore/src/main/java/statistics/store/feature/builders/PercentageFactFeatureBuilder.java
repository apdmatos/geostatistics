package statistics.store.feature.builders;

import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.feature.simple.SimpleFeatureBuilder;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.model.indicator.IndicatorRange;
import statistics.model.indicator.IndicatorValue;
import statistics.queryparser.StatisticsRequestParameters;
import statistics.store.shapes.IShapeData;

/**
 *
 * @author Andre Matos
 */
public class PercentageFactFeatureBuilder extends FeatureBuilder {

    public PercentageFactFeatureBuilder(
            SimpleFeatureType featureType, IndicatorRange range, StatisticsRequestParameters query) {
        super(featureType, range, query);
    }

    @Override
    public SimpleFeature buildFeature(IShapeData shape, List<IndicatorValue> values) {

        Logger.getLogger(PercentageFactFeatureBuilder.class.getName()).log (
            Level.INFO,
            "buildFeature"
        );

        String dimensions = query.dimensions != null ? query.dimensions : "";
        IndicatorValue value = values.get(0);

        double percent = value.value / (range.max.value - range.min.value);

        SimpleFeatureBuilder featureBuilder = new SimpleFeatureBuilder( featureType );
        featureBuilder.add( shape.getFeatureGeometry() );
        featureBuilder.add( shape.getShapeName() );
        featureBuilder.add( shape.getShapeId() );
        featureBuilder.add( dimensions  ); 
        featureBuilder.add( query.indicatorId ); 
        featureBuilder.add( query.sourceId ); 
        featureBuilder.add( shapeLevel ); 
        featureBuilder.add( value.value );
        featureBuilder.add( percent );

        return featureBuilder.buildFeature( shape.getFeatureId() );
    }

}
