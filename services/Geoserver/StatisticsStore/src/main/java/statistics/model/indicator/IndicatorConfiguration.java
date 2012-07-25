package statistics.model.indicator;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class IndicatorConfiguration {

    public int indicatorId;
    public int sourceId;
    public List<Dimension> filter;
    public List<Dimension> projected;

    public IndicatorConfiguration(int indicatorId, int sourceId, List<Dimension> filter, List<Dimension> projected) {

        this.indicatorId =indicatorId;
        this.sourceId = sourceId;
        this.filter = filter;
        this.projected = projected;
        if(filter == null)
            filter = new ArrayList<Dimension>();
        if(projected == null)
            projected = new ArrayList<Dimension>();
    }


    public void addFilterDimension(Dimension d){
        filter.add(d);
    }

    public void addProjectedDimension(Dimension d){
        projected.add(d);
    }

    public GeographicDimension getGeographicDimension() {

        for (Dimension dimension : projected) {
            if(dimension instanceof GeographicDimension) return (GeographicDimension)dimension;
        }

//        for (Dimension dimension : filter) {
//            if(dimension instanceof GeographicDimension) return (GeographicDimension)dimension;
//        }

        return null;
    }
}
