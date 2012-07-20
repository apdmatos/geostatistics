package statistics.queryparser;

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
        
        this.bbox           = bbox;
        this.dimensions     = dimensions;
        this.indicatorId    = indicatorId;
        this.sourceId       = sourceId;
    }
    


}
