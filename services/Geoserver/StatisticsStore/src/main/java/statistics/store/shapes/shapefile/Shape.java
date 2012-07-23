package statistics.store.shapes.shapefile;

import com.vividsolutions.jts.geom.Geometry;
import org.opengis.feature.simple.SimpleFeature;
import statistics.config.Config;
import statistics.store.shapes.IShapeData;

/**
 *
 * @author Andre Matos
 */
public class Shape implements IShapeData {

    private SimpleFeature feature;

    public Shape(SimpleFeature feature){
        this.feature = feature;
    }

    @Override
    public String getFeatureId() {
        return feature.getID();
    }

    @Override
    public Geometry getFeatureGeometry(){
        return (Geometry)feature.getDefaultGeometry();
    }

    @Override
    public String getShapeName(){
        return (String) feature.getAttribute(Config.SHAPEFILE_NAME_ATTR);
    }

    @Override
    public String getShapeId(){
        return (String)feature.getAttribute(Config.SHAPEFILE_ID_ATTR);
    }

    @Override
    public String getShapeParentId(){
        return (String) feature.getAttribute(Config.SHAPEFILE_PARENT_ID_ATTR);
    }
}
