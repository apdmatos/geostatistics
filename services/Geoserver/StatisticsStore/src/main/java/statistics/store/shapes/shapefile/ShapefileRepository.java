package statistics.store.shapes.shapefile;

import java.io.File;
import java.io.IOException;
import java.net.MalformedURLException;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.data.DataStoreFinder;
import org.geotools.data.DefaultQuery;
import org.geotools.data.shapefile.ShapefileDataStore;
import org.geotools.data.simple.SimpleFeatureCollection;
import org.geotools.data.simple.SimpleFeatureSource;
import org.geotools.factory.CommonFactoryFinder;
import org.geotools.filter.text.cql2.CQL;
import org.geotools.filter.text.cql2.CQLException;
import org.geotools.geometry.jts.ReferencedEnvelope;
import org.opengis.filter.Filter;
import org.opengis.filter.FilterFactory;
import org.opengis.filter.spatial.BBOX;
import statistics.model.shape.file.ShapefileConfiguration;
import statistics.store.shapes.IShapeReader;
import statistics.store.shapes.IShapeRepository;
import statistics.utis.StringUtils;

/**
 *
 * @author Andre Matos
 */
public class ShapefileRepository implements IShapeRepository {

    private ShapefileConfiguration shapefileConfig;
    private Map<String, SimpleFeatureSource> featureSources;

    public ShapefileRepository(ShapefileConfiguration shapefileConfig) {
        this.shapefileConfig = shapefileConfig;
        this.featureSources = new HashMap<String, SimpleFeatureSource>();
    }

    @Override
    public IShapeReader getShapes(String sourceId, String indicatorId, String shapeLevel, BBOX bbox, String[] shapeIds) {

        String bboxStr = bbox != null ? bbox.toString() : "";
        Logger.getLogger(ShapefileRepository.class.getName()).log (
            Level.INFO,
            "getting shapefile for sourceid: " + sourceId +
                " indicator: " + indicatorId +
                " shapelevel: " + shapeLevel +
                " bbox: " + bboxStr +
                " shapeIds: " + StringUtils.join(shapeIds, ",")
        );

        SimpleFeatureSource source = getFeatureSource(shapeLevel);
        SimpleFeatureCollection features = null;
        if(source != null) {

            Filter filter = getShapefileFilter(bbox, shapeIds);
            try {
                features = source.getFeatures(filter);
            } catch (IOException ex) {
                Logger.getLogger(
                        ShapefileRepository.class.getName()).log(Level.SEVERE,
                        "Cannot count get feature collection from source",
                        ex);
            }
        }

        return new ShapefileReader(features);
    }

    @Override
    public int countShapes(String sourceId, String indicatorId, String shapeLevel, BBOX bbox, String[] shapeIds) {

        String bboxStr = bbox != null ? bbox.toString() : "";
        Logger.getLogger(ShapefileRepository.class.getName()).log (
            Level.INFO,
            "counting shapes for sourceid: " + sourceId +
                " indicator: " + indicatorId +
                " shapelevel: " + shapeLevel +
                " bbox: " + bboxStr +
                " shapeIds: " + StringUtils.join(shapeIds, ",")
        );

        SimpleFeatureSource source = getFeatureSource(shapeLevel);
        if(source != null) {

            Filter filter = getShapefileFilter(bbox, shapeIds);
            DefaultQuery query = new DefaultQuery(source.getSchema().getTypeName(), filter);
            
            try {
                return source.getCount(query);
            } catch (IOException ex) {
                Logger.getLogger(
                        ShapefileRepository.class.getName()).log(Level.SEVERE,
                        "Cannot count feature number",
                        ex);
            }
        }

        return 0;
    }

    @Override
    public ReferencedEnvelope getBounds(String sourceId, String indicatorId, String shapeLevel, BBOX bbox, String[] shapeIds) {

        String bboxStr = bbox != null ? bbox.toString() : "";
        Logger.getLogger(ShapefileRepository.class.getName()).log (
            Level.INFO,
            "getting shapes bounds: " + sourceId +
                " indicator: " + indicatorId +
                " shapelevel: " + shapeLevel +
                " bbox: " + bboxStr +
                " shapeIds: " + StringUtils.join(shapeIds, ",")
        );

        SimpleFeatureSource source = getFeatureSource(shapeLevel);
        if(source != null) {

            Filter filter = getShapefileFilter(bbox, shapeIds);
            DefaultQuery query = new DefaultQuery(source.getSchema().getTypeName(), filter);

            try {
                return source.getBounds(query);
            } catch (IOException ex) {
                Logger.getLogger(
                        ShapefileRepository.class.getName()).log(Level.SEVERE,
                        "Cannot get feature bounds",
                        ex);
            }
        }

        return null;
    }

    private SimpleFeatureSource getFeatureSource(String shapeLevel){


        if(featureSources.containsKey(shapeLevel))
            return featureSources.get(shapeLevel);

        ShapefileDataStore store;
        try {

            File shapefile = shapefileConfig.getShapefilePath(shapeLevel);
            store = getDataStore(shapefile);

        } catch (IOException ex) {
            Logger.getLogger(ShapefileRepository.class.getName()).log(Level.SEVERE, "Cannot get the datastore.", ex);
            return null;
        }
        
        try {
            SimpleFeatureSource source = store.getFeatureSource(store.getTypeNames()[0]);
            featureSources.put(shapeLevel, source);
            return source;
        } catch (IOException ex) {
            Logger.getLogger(
                    ShapefileRepository.class.getName()).log(Level.SEVERE,
                    "Cannot get the feature source",
                    ex);            
        }

        return null;
    }

    private ShapefileDataStore getDataStore(File shapefile) throws IOException {

        Logger.getLogger(ShapefileRepository.class.getName()).log(
                    Level.INFO,
                    "Gettinh shapefile datastore for file: " + shapefile.getAbsolutePath()
                );

        Map<String,Object> params = new HashMap<String,Object>();
        try {
            params.put("url", shapefile.toURI().toURL());
        } catch (MalformedURLException ex) {
            Logger.getLogger(ShapefileRepository.class.getName()).log(Level.SEVERE, null, ex);
        }
        params.put( "create spatial index", true );
        params.put( "memory mapped buffer", true );
        params.put( "charset", "ISO-8859-1" );

        return (ShapefileDataStore) DataStoreFinder.getDataStore(params);
    }

    private Filter getShapefileFilter(BBOX bbox, String[] shapeIds) {

        Filter bboxFilter = Filter.INCLUDE;
        if(bbox != null)
            bboxFilter = bbox;

        String cql = composeCQLFilter(shapeIds);
        if(cql != null)
        {
            FilterFactory ff = CommonFactoryFinder.getFilterFactory( null );
            try {
                
                return ff.and(bboxFilter, CQL.toFilter(cql));
            } catch (CQLException ex) {
                
                Logger.getLogger(ShapefileRepository.class.getName()).log(
                    Level.SEVERE,
                    "CQL is not in a correct format",
                    ex
                );
            }
        }
        
        return bboxFilter;
    }

    private static String composeCQLFilter(String[] ids) {

        // TODO: implement the filter
        return null;
    }
}
