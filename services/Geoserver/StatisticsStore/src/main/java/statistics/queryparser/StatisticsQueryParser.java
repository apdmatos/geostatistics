package statistics.queryparser;

import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;
import org.geotools.data.Query;
import org.geotools.filter.visitor.DefaultFilterVisitor;
import org.opengis.feature.type.AttributeDescriptor;
import org.opengis.feature.type.FeatureType;
import org.opengis.filter.Filter;
import org.opengis.filter.PropertyIsEqualTo;
import org.opengis.filter.expression.Literal;
import org.opengis.filter.expression.PropertyName;
import org.opengis.filter.spatial.BBOX;
import org.opengis.filter.expression.Expression;
import statistics.model.indicator.Dimension;
import statistics.model.indicator.DimensionAttribute;
import statistics.model.indicator.IndicatorMetadata;
import statistics.store.FeatureBuilder;

/**
 *
 * @author Andre Matos
 */
public class StatisticsQueryParser {

    private Query query;
    private final FeatureType featureType;
    private StatisticsRequestParameters requestedParameters;
    private IndicatorMetadata indicator;

    private class QueryVisitor extends DefaultFilterVisitor {

        private BBOX bbox;
        private Map<String, Object> queryMap;


        public QueryVisitor() {
            queryMap = new Hashtable<String, Object>();
        }

        @Override
        public Object visit(BBOX filter, Object data) {
            Object obj = super.visit(filter, data);
            bbox = filter;
            return obj;
        }

        @Override
        public Object visit(PropertyIsEqualTo filter, Object data) {
           // Object obj = super.visit(filter, data);
            Expression left = filter.getExpression1();
            Expression right = filter.getExpression2();
            
            if (left instanceof PropertyName) {
                // aha!  It's a propertyname, we should get the name and pass it in
                // as context to the tree walker.
                AttributeDescriptor attType = (AttributeDescriptor)left.evaluate(featureType);
                if (attType != null) {
                    right.accept(this, attType.getLocalName());
                }
            }

            return null;
        }

        @Override
        public Object visit( Literal expression, Object data ) {
            

            if(data != null && data instanceof String) {
                
                queryMap.put((String)data, expression.getValue());
            }

            return null;
        }
    }

    public StatisticsQueryParser(Query query, FeatureType featureType) {
        this.query = query;
        this.featureType = featureType;
    }

    public String getSourceId() {
        
        return getParameters().sourceId;
    }

    public String getIndicatorId() {
        
        return getParameters().indicatorId;
    }

    public String getShapeLevel() {

        return parseParameters().getGeographicDimension().shapeLevel;
    }

    public List<DimensionAttribute> getShapeIds() {

        return parseParameters().getGeographicDimension().dimensionAttributes;
    }

    public List<Dimension> getDimensions() {
        return parseParameters().dimensions;
    }

    public IndicatorMetadata getIndicatorMetadata() {

        return parseParameters();
    }

    public BBOX getBoundingBox() {
        
        return getParameters().bbox;
    }


    public StatisticsRequestParameters getParameters() {

        if(requestedParameters == null) {

            QueryVisitor visitor = new QueryVisitor();
            Filter filter = query.getFilter();
            if(filter != null)
                filter.accept(visitor, null);

            requestedParameters = new StatisticsRequestParameters(
                        visitor.bbox,
                        visitor.queryMap.containsKey(FeatureBuilder.DIMENSIONS_PROPERTY)    ? (String) visitor.queryMap.get(FeatureBuilder.DIMENSIONS_PROPERTY)     : null,
                        visitor.queryMap.containsKey(FeatureBuilder.INDICATORID_PROPERTY)   ? (String) visitor.queryMap.get(FeatureBuilder.INDICATORID_PROPERTY)    : null,
                        visitor.queryMap.containsKey(FeatureBuilder.SOURCEID_PROPERTY)      ? (String) visitor.queryMap.get(FeatureBuilder.SOURCEID_PROPERTY)       : null
                    );

        }

        return requestedParameters;
    }

    private IndicatorMetadata parseParameters() {

        if(indicator == null) {

            StatisticsRequestParameters request = getParameters();




        }


        return null;
    }
}
