package statistics.queryparser;

import java.util.HashMap;
import java.util.Map;
import org.geotools.data.Query;
import org.geotools.filter.visitor.DefaultFilterVisitor;
import org.opengis.feature.type.AttributeDescriptor;
import org.opengis.feature.type.FeatureType;
import org.opengis.filter.PropertyIsEqualTo;
import org.opengis.filter.expression.Literal;
import org.opengis.filter.expression.PropertyName;
import org.opengis.filter.spatial.BBOX;
import org.opengis.filter.expression.Expression;
import statistics.store.FeatureBuilder;

/**
 *
 * @author Andre Matos
 */
public class StatisticsQueryParser {

    public static String SOURCE_ID = "sourceId";
    public static String INDICATOR_ID = "indicatorId";
    public static String DIMENSIONS = "dimensions";

    private Query query;
    private QueryVisitor visitor;
    private final FeatureType featureType;

    private BBOX bbox;
    private Map<String, Object> queryMap;

    private class QueryVisitor extends DefaultFilterVisitor {

        @Override
        public Object visit(BBOX filter, Object data) {
            Object obj = super.visit(filter, data);
            bbox = filter;
            return obj;
        }

        @Override
        public Object visit(PropertyIsEqualTo filter, Object data) {
            Object obj = super.visit(filter, data);
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

            return obj;
        }

        @Override
        public Object visit(Literal expression, Object data) {
            Object obj = super.visit(expression, data);
            if(data != null && data instanceof String){

                queryMap.put((String)data, expression.getValue());

            }

            return obj;
        }

    }

    public StatisticsQueryParser(Query query, FeatureType featureType) {
        this.query = query;
        this.featureType = featureType;
        this.queryMap = new HashMap<String, Object>();
    }

    public String getSourceId() {
        
        parseQuery();

        //return "1";
        if(queryMap.containsKey(FeatureBuilder.SOURCEID_PROPERTY))
            return (String)queryMap.get(FeatureBuilder.SOURCEID_PROPERTY);

        return null;
    }

    public String getIndicatorId() {
        
        parseQuery();

        //return "1";
        if(queryMap.containsKey(FeatureBuilder.INDICATORID_PROPERTY))
            return (String)queryMap.get(FeatureBuilder.INDICATORID_PROPERTY);

        return null;
    }

    public String getShapeLevel() {

        parseQuery();

        return "Municipality";
    }

    public String[] getShapeIds() {

        parseQuery();

        return null;
    }

    public String getDimensions() {

        parseQuery();

        return null;
    }

    public BBOX getBoundingBox() {

        parseQuery();

        return bbox;
    }

    private void parseQuery() {
        if(visitor == null) {
            visitor = new QueryVisitor();
            query.getFilter().accept(visitor, null);
        }
    }
}
