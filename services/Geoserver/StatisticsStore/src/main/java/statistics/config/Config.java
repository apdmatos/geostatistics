package statistics.config;

import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Andre Matos
 */
public class Config {

    public static String SHAPEFILE_DIRECTORY;

    public static String SHAPEFILE_NAME_ATTR;
    public static String SHAPEFILE_ID_ATTR;
    public static String SHAPEFILE_PARENT_ID_ATTR;


    static {
        Properties prop = new Properties();
        
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
    }
}
