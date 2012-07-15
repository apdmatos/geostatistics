package statistics.model.indicator;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class IndicatorMetadata {

    public String indicatorId;
    public String sourceId;
    public List<Dimension> dimensions;

    public IndicatorMetadata(String indicatorId, String sourceId, List<Dimension> dimensions) {

        this.indicatorId =indicatorId;
        this.sourceId = sourceId;
        this.dimensions = dimensions;
        if(dimensions == null)
            dimensions = new ArrayList<Dimension>();
    }


    public void addDimension(Dimension d){
        dimensions.add(d);
    }

    public GeographicDimension getGeographicDimension() {

        for(int i = 0; i < dimensions.size(); ++i)
            if(dimensions.get(i) instanceof GeographicDimension)
                return (GeographicDimension) dimensions.get(i);

        return null;
    }
}
