package statistics.store.shapes;

import com.vividsolutions.jts.geom.Geometry;
import org.opengis.feature.simple.SimpleFeature;

/**
 *
 * @author Andre Matos
 */
public class Shape implements IShapeData {

    private SimpleFeature feature;
    

    public Shape(SimpleFeature feature){
        
    }

    @Override
    public Geometry getFeatureGeometry(){
        return null;
    }

    @Override
    public String getShapeName(){
        //feature.getAttribute("name")
        return null;
    }

    @Override
    public String getShapeId(){
        return null;
    }

    @Override
    public SimpleFeature getSimpleFeature() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
