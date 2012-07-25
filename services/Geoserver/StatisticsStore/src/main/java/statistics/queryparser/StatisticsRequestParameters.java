package statistics.queryparser;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public class StatisticsRequestParameters {

    public String filterDimensions;
    public String projectedDimensions;
    public int indicatorId;
    public int sourceId;
    public BBOX bbox;

    StatisticsRequestParameters(BBOX bbox, String filterDimensions, String projectedDimensions, int indicatorId, int sourceId) {

        Logger.getLogger(StatisticsRequestParameters.class.getName()).log (
            Level.INFO,
            "StatisticsRequestParameters ctor \nParameters" +
                "\n\tbbox " + (bbox != null ? bbox.toString() : "") +
                "\n\tfilterDimensions " + (filterDimensions != null ? filterDimensions : "") +
                "\n\tprojectedDimensions " + (projectedDimensions != null ? projectedDimensions : "") +
                "\n\tindicatorId " + indicatorId +
                "\n\tsourceId " + sourceId
        );

        this.bbox                   = bbox;
        this.filterDimensions       = filterDimensions;
        this.projectedDimensions    = projectedDimensions;
        this.indicatorId            = indicatorId;
        this.sourceId               = sourceId;
    }
    


}
