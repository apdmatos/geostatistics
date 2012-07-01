package statistics.config;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.Properties;

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

//    // temporary. Should be obtained by the config service
//    public static HashMap<String, String> SHAPEFILE_LEVELS;


    static {
        Properties prop = new Properties();
    	try {
            //load a properties file
            String pathPropertiesFile = "/config.properties";
            InputStream stream = pathPropertiesFile.getClass().getResourceAsStream(pathPropertiesFile);
            prop.load(stream);

            SHAPEFILE_ID_ATTR = prop.getProperty("statistics.shapefile.nameAttr");
            SHAPEFILE_NAME_ATTR = prop.getProperty("statistics.shapefile.idAttr");
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

    	} catch (IOException ex) {
            ex.printStackTrace();
        }   
    }
}
