package statistics.store;

import com.vividsolutions.jts.geom.Geometry;
import com.vividsolutions.jts.geom.GeometryCollection;
import com.vividsolutions.jts.geom.MultiPolygon;
import org.geotools.feature.simple.SimpleFeatureBuilder;
import org.geotools.feature.simple.SimpleFeatureTypeBuilder;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import org.opengis.feature.type.Name;
import statistics.store.shapes.IShapeData;

/**
 *
 * @author Andre Matos
 */
public class FeatureBuilder {

    public static String SRS                    = "EPSG:4326";
    public static String SHAPE_PROPERTY         = "shape";
    public static String NAME_PROPERTY          = "name";
    public static String ID_PROPERTY            = "id";
    public static String DIMENSIONS_PROPERTY    = "dimensions";
    public static String INDICATORID_PROPERTY   = "indicatorId";
    public static String SOURCEID_PROPERTY   = "indicatorId";
    public static String SHAPELEVEL_PROPERTY    = "shapeLevel";
    public static String VALUE_PROPERTY         = "value";


    private Name featureSchemaName;
    private SimpleFeatureType featureType;

    public FeatureBuilder(Name name){
        featureSchemaName = name;
    }


    public SimpleFeatureType getFeatureType(){

        if(featureType == null){
            SimpleFeatureTypeBuilder builder = new SimpleFeatureTypeBuilder();
            builder.setName( featureSchemaName );

            builder.setSRS( SRS );
            builder.add( SHAPELEVEL_PROPERTY,      MultiPolygon.class );
            builder.add( NAME_PROPERTY,            String.class );
            builder.add( ID_PROPERTY,              String.class );
            //builder.add( "parentid",              String.class );
            builder.add( DIMENSIONS_PROPERTY,      String.class );
            builder.add( INDICATORID_PROPERTY,     String.class );
            builder.add( SOURCEID_PROPERTY,        String.class );
            builder.add( SHAPELEVEL_PROPERTY,      String.class );
            builder.add( VALUE_PROPERTY,           Double.class );

            // build the type (it is immutable and cannot be modified)
            featureType = builder.buildFeatureType();
            
        }

        return featureType;
    }

    public SimpleFeature buildFeature(IShapeData shape) {

        SimpleFeatureBuilder featureBuilder = new SimpleFeatureBuilder( getFeatureType() );
        featureBuilder.add( shape.getFeatureGeometry() );
        featureBuilder.add( shape.getShapeName() );
        featureBuilder.add( shape.getShapeId() );
        featureBuilder.add( "" ); //TODO: must be defined
        featureBuilder.add( "" ); //TODO: must be defined
        featureBuilder.add( "" ); //TODO: must be defined
        featureBuilder.add( "" ); //TODO: must be defined
        featureBuilder.add( 0 ); //TODO: must be defined

        return featureBuilder.buildFeature( shape.getFeatureId() );
    }

}
