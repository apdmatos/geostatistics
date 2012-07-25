package statistics.store.feature;

import com.vividsolutions.jts.geom.MultiPolygon;
import org.geotools.feature.simple.SimpleFeatureTypeBuilder;
import org.opengis.feature.simple.SimpleFeatureType;
import org.opengis.feature.type.Name;

/**
 *
 * @author Andre Matos
 */
public class FeatureSchemaBuilder {

    public static String SRS                            = "EPSG:4326";
    public static String SHAPE_PROPERTY                 = "the_geom";
    public static String NAME_PROPERTY                  = "name";
    public static String ID_PROPERTY                    = "id";
    public static String FILTER_DIMENSIONS_PROPERTY     = "filterdimensions";
    public static String PROJECTED_DIMENSIONS_PROPERTY  = "projecteddimensions";
    public static String INDICATORID_PROPERTY           = "indicatorId";
    public static String SOURCEID_PROPERTY              = "sourceId";
    public static String SHAPELEVEL_PROPERTY            = "shapeLevel";
    public static String VALUE_PROPERTY                 = "value";
    public static String PERCENTAGE                     = "percent";

    private Name featureSchemaName;
    private SimpleFeatureType featureType;

    public FeatureSchemaBuilder(Name name) {
        featureSchemaName = name;
    }

    public SimpleFeatureType getFeatureType() {

        if(featureType == null){
            SimpleFeatureTypeBuilder builder = new SimpleFeatureTypeBuilder();
            builder.setName( featureSchemaName );
            //builder.setName(featureSchemaName.getLocalPart());

            builder.setSRS( SRS );
            builder.add( SHAPE_PROPERTY,                    MultiPolygon.class );
            builder.add( NAME_PROPERTY,                     String.class );
            builder.add( ID_PROPERTY,                       String.class );
            //builder.add( "parentid",                      String.class );
            builder.add( FILTER_DIMENSIONS_PROPERTY,        String.class );
            builder.add( PROJECTED_DIMENSIONS_PROPERTY,     String.class );
            builder.add( INDICATORID_PROPERTY,              Integer.class );
            builder.add( SOURCEID_PROPERTY,                 Integer.class );
            builder.add( SHAPELEVEL_PROPERTY,               String.class );
            builder.add( VALUE_PROPERTY,                    Double.class );
            builder.add( PERCENTAGE,                        Double.class );

            // build the type (it is immutable and cannot be modified)
            featureType = builder.buildFeatureType();
        }

        return featureType;
    }

}
