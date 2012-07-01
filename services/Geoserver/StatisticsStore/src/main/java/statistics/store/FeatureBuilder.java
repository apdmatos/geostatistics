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

    public static String SRS = "EPSG:4326";

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
            builder.add( "shape",           MultiPolygon.class );
            builder.add( "name",           MultiPolygon.class );
            builder.add( "id",              String.class );
            //builder.add( "parentid",        String.class );
            builder.add( "dimensions",      String.class );
            builder.add( "indicatorId",     String.class );
            builder.add( "sourceId",        String.class );
            builder.add( "shapeLevel",      String.class );

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

        return featureBuilder.buildFeature( shape.getFeatureId() );
    }

}
