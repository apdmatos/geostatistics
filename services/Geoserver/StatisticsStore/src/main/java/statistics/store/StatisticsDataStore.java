package statistics.store;

import java.io.IOException;
import java.util.Collections;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.geotools.data.Query;
import org.geotools.data.store.ContentDataStore;
import org.geotools.data.store.ContentEntry;
import org.geotools.data.store.ContentFeatureSource;
import org.geotools.feature.NameImpl;
import org.opengis.feature.type.Name;

/**
 *
 * @author Andre Matos
 */
public class StatisticsDataStore extends ContentDataStore {

    private String _statisticsServiceURL;

    public StatisticsDataStore(String statisticsServiceURL) {

        Logger.getLogger(StatisticsDataStore.class.getName()).log (
            Level.INFO,
            "StatisticsDataStore ctor: " +
                " url: " + statisticsServiceURL
        );

        _statisticsServiceURL = statisticsServiceURL;
    }

    @Override
    protected List<Name> createTypeNames() throws IOException {

        Logger.getLogger(StatisticsDataStore.class.getName()).log (
            Level.INFO,
            "createTypeNames"
        );

        Name typeName = new NameImpl( _statisticsServiceURL );
        return Collections.singletonList(typeName);
    }

    @Override
    protected ContentFeatureSource createFeatureSource(ContentEntry entry) throws IOException {

        Logger.getLogger(StatisticsDataStore.class.getName()).log (
            Level.INFO,
            "createFeatureSource"
        );

        return new StatisticsFeatureSource(_statisticsServiceURL, entry, Query.ALL);
    }

}
