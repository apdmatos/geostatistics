package statistics.queryparser;

import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public class StatisticsRequestParameters {

    public String dimensions;
    public String indicatorId;
    public String sourceId;
    public BBOX bbox;

    StatisticsRequestParameters(BBOX bbox, String dimensions, String indicatorId, String sourceId) {
        
        this.bbox           = bbox;
        this.dimensions     = dimensions;
        this.indicatorId    = indicatorId;
        this.sourceId       = sourceId;
    }
    


}
