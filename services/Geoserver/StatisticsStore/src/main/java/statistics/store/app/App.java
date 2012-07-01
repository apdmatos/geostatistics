/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package statistics.store.app;

import java.io.IOException;
import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;
import org.geotools.data.DataStore;
import org.geotools.data.DataStoreFinder;
import org.geotools.data.simple.SimpleFeatureCollection;
import org.geotools.data.simple.SimpleFeatureSource;
import org.geotools.map.FeatureLayer;
import org.geotools.map.MapContent;
import org.geotools.styling.SLD;
import org.geotools.styling.Style;
import org.geotools.swing.JMapFrame;

/**
 *
 * @author Andre Matos
 */
public class App {

    public static void main(String[] args) throws IOException{

        Map<String, Serializable> params = new HashMap<String, Serializable>();
        params.put("ServiceURL", "http://localhost:36590/Statistics.svc");
        DataStore store = DataStoreFinder.getDataStore(params);

        String[] typeNames = store.getTypeNames();
        for (int i = 0; i < typeNames.length; i++) {
            System.out.println(typeNames[i]);
        }
        String typeName = typeNames[0];

        SimpleFeatureSource featureSource = store.getFeatureSource(typeName);
        SimpleFeatureCollection collection = featureSource.getFeatures();

        System.out.println("featureType.getname() = " + featureSource.getSchema().getName());
        Style style = SLD.createSimpleStyle(featureSource.getSchema());
        MapContent map = new MapContent();
        map.addLayer(new FeatureLayer(collection, style));

        JMapFrame.showMap(map);
    }
}
