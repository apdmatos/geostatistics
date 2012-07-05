package statistics.config;

import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Andre Matos
 */
public class Config {

//    public static String STATISTICS_SERVICE;
//    public static String CONFIG_SERVICE;
    public static String SHAPEFILE_DIRECTORY;

    public static String SHAPEFILE_NAME_ATTR;
    public static String SHAPEFILE_ID_ATTR;
    public static String SHAPEFILE_PARENT_ID_ATTR;


    static {
        Properties prop = new Properties();
    	/*try {*/
            //load a properties file
            String pathPropertiesFile = "/config.properties";
            InputStream stream = null;

            try {
                stream = new Config().getClass().getResourceAsStream(pathPropertiesFile);
            }catch(Exception e){
                Logger.getLogger(Config.class.getName()).log(Level.SEVERE,
                        "Error getting resource stream",
                        e);
                e.printStackTrace();
            }

            DataInputStream dis = new DataInputStream(stream);
            String line;
            try {
                line = dis.readLine();
                Logger.getLogger(Config.class.getName()).log(Level.INFO, line);
            } catch (IOException ex) {
                Logger.getLogger(Config.class.getName()).log(Level.SEVERE, "Cannot read line", ex);
            }

            try {
                prop.load(stream);
            }catch(Exception e){
                Logger.getLogger(Config.class.getName()).log(Level.SEVERE,
                        "Error loading properties file",
                        e);
                e.printStackTrace();
            }

            SHAPEFILE_ID_ATTR = prop.getProperty("statistics.shapefile.idAttr");
            SHAPEFILE_NAME_ATTR = prop.getProperty("statistics.shapefile.nameAttr");
            SHAPEFILE_PARENT_ID_ATTR = prop.getProperty("statistics.shapefile.parentIdAttr");

//            STATISTICS_SERVICE = prop.getProperty("statistics.service");
//            CONFIG_SERVICE = prop.getProperty("statistics.config.service");
//            SHAPEFILE_DIRECTORY = prop.getProperty("statistics.shapefile.directory");
//
//            SHAPEFILE_LEVELS = new HashMap<String, String>();
//            String[] levels = prop.getProperty("statistics.shapefilelevels").split(",");
//            for (String level : levels) {
//                String levelPath = prop.getProperty("statistics.shapefilelevels");
//                SHAPEFILE_LEVELS.put(level, levelPath);
//            }

    	/*} catch (IOException ex) {
            ex.printStackTrace();
        }   */
    }
}
