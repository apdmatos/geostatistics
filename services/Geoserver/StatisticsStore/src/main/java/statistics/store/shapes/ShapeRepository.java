package statistics.store.shapes;

import java.io.File;
import java.io.IOException;
import java.net.MalformedURLException;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.data.DataStoreFinder;
import org.geotools.data.shapefile.ShapefileDataStore;
import org.geotools.data.simple.SimpleFeatureCollection;
import org.geotools.data.simple.SimpleFeatureSource;
import org.geotools.factory.CommonFactoryFinder;
import org.geotools.filter.text.cql2.CQL;
import org.geotools.filter.text.cql2.CQLException;
import org.opengis.filter.Filter;
import org.opengis.filter.FilterFactory;
import org.opengis.filter.spatial.BBOX;
import statistics.config.Config;
import statistics.utis.StringUtils;

/**
 *
 * @author Andre Matos
 */
public class ShapeRepository implements IShapeRepository {

    public ShapeRepository() { }

    @Override
    public IShapeReader getShapes(String indicator, String shapeLevel, BBOX bbox, String[] shapeIds) {

        Logger.getLogger(ShapeRepository.class.getName()).log (
            Level.INFO,
            "getting shapefile for indicator: " + indicator +
                "shapelevel: " + shapeLevel +
                "bbox: " + bbox.toString() +
                "shapeIds: " + StringUtils.join(shapeIds, ",")
        );

        ShapefileDataStore store;
        try {

            File shapefile = Config.getShapefile(shapeLevel);
            store = getDataStore(shapefile);
            
        } catch (IOException ex) {
            Logger.getLogger(ShapeRepository.class.getName()).log(Level.SEVERE, "Cannot get the datastore.", ex);
            return new ShapeReader(null);
        }

        SimpleFeatureCollection features = null;
        try {
            
            SimpleFeatureSource source = store.getFeatureSource(store.getTypeNames()[0]);
            Filter filter = getShapefileFilter(bbox, shapeIds);
            features = source.getFeatures(filter);

            

        } catch (IOException ex) {
            Logger.getLogger(ShapeRepository.class.getName()).log(Level.SEVERE, "Cannot get the feature source", ex);
        }

        return new ShapeReader(features);
    }

    private ShapefileDataStore getDataStore(File shapefile) throws IOException {
        
        Map<String,Object> params = new HashMap<String,Object>();
        try {
            params.put("url", shapefile.toURI().toURL());
        } catch (MalformedURLException ex) {
            Logger.getLogger(ShapeRepository.class.getName()).log(Level.SEVERE, null, ex);
        }
        params.put( "create spatial index", false );
        params.put( "memory mapped buffer", false );
        params.put( "charset", "ISO-8859-1" );

        return (ShapefileDataStore) DataStoreFinder.getDataStore(params);
    }

    private Filter getShapefileFilter(BBOX bbox, String[] shapeIds) {

        String cql = composeCQLFilter(shapeIds);
        if(cql != null)
        {
            FilterFactory ff = CommonFactoryFinder.getFilterFactory( null );
            try {
                
                return ff.and(bbox, CQL.toFilter(cql));
            } catch (CQLException ex) {
                
                Logger.getLogger(ShapeRepository.class.getName()).log(
                    Level.SEVERE,
                    "CQL is not in a correct format",
                    ex
                );
            }
        }

        return bbox;
    }

    private static String composeCQLFilter(String[] ids) {

        // TODO: implement the filter
        return null;
    }

}
