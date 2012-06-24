package statistics.store;

import java.awt.RenderingHints.Key;
import java.io.IOException;
import java.io.Serializable;
import java.util.Collections;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.data.DataStore;
import org.geotools.data.DataStoreFactorySpi;

/**
 *
 * @author Andre Matos
 */
public class StatisticsStoreFactory implements DataStoreFactorySpi {

    public static final Param STATISTICS_URL = new Param(
            "ServiceURL", String.class,
            "The statistics service to obtain the statistical data from",true);

    @Override
    public DataStore createDataStore(Map<String, Serializable> params) throws IOException {
        String url = (String) STATISTICS_URL.lookUp(params);
        return new StatisticsDataStore(url);
    }

    @Override
    public DataStore createNewDataStore(Map<String, Serializable> params) throws IOException {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getDisplayName() {
        return "Statistics store";
    }

    @Override
    public String getDescription() {
        return "Statistics store to generate tematic map images";
    }

    /**
     * @see #DIRECTORY
     * @see StatisticsStoreFactory#NAMESPACE
     */
    @Override
    public Param[] getParametersInfo() {
        return new Param[] { STATISTICS_URL };
    }

    /**
     * Works for a file directory or property file
     *
     * @param params Connection parameters
     * @return true for connection parameters indicating a directory or property
     *         file
     */
    @Override
    public boolean canProcess(Map<String, Serializable> params) {

        String url = null;
        try {
            url = (String) STATISTICS_URL.lookUp(params);
            
        } catch (IOException ex) {
            Logger.getLogger(StatisticsStoreFactory.class.getName()).log(Level.SEVERE, null, ex);
        }
        return url != null;
    }

    /**
     * Test to see if this datastore is available, if it has all the appropriate
     * libraries to construct a datastore. This datastore just returns true for
     * now. This method is used for interactive applications, so as to not
     * advertise data store capabilities they don't actually have.
     *
     * @return <tt>true</tt> if and only if this factory is available to create
     *         DataStores.
     * @task <code>true</code> property datastore is always available
     */
    @Override
    public boolean isAvailable() {
        return true;
    }

    /**
     * No implementation hints are provided at this time.
     */
    @Override
    public Map<Key, ?> getImplementationHints() {
        return Collections.emptyMap();
    }

}
