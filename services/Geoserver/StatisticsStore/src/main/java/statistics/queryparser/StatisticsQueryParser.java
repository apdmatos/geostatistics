package statistics.queryparser;

import org.geotools.data.Query;
import org.opengis.filter.spatial.BBOX;

/**
 *
 * @author Andre Matos
 */
public class StatisticsQueryParser {

    private Query query;

    public StatisticsQueryParser(Query query) {
        this.query = query;
    }

    public String getSourceId() {
        return "1";
    }

    public String getIndicatorId() {
        return "1";
    }

    public String getShapeLevel() {
        return "Municipality";
    }

    public String[] getShapeIds(){
        return null;
    }

    public String getDimensions() {
        return null;
    }

    public BBOX getBoundingBox() {
        return null;
    }
}
