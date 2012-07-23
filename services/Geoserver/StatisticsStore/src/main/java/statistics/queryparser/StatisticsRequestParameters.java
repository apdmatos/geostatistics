package statistics.queryparser;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public class StatisticsRequestParameters {

    public String dimensions;
    public int indicatorId;
    public int sourceId;
    public BBOX bbox;

    StatisticsRequestParameters(BBOX bbox, String dimensions, int indicatorId, int sourceId) {

        Logger.getLogger(StatisticsRequestParameters.class.getName()).log (
            Level.INFO,
            "StatisticsRequestParameters ctor \nParameters" +
                "\n\tbbox " + (bbox != null ? bbox.toString() : "") +
                "\n\tdimensions " + (dimensions != null ? dimensions : "") +
                "\n\tindicatorId " + indicatorId +
                "\n\tsourceId " + sourceId
        );

        this.bbox           = bbox;
        this.dimensions     = dimensions;
        this.indicatorId    = indicatorId;
        this.sourceId       = sourceId;
    }
    


}
