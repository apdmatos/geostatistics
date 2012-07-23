package statistics.store.service.extensions;

import java.util.ArrayList;
import java.util.List;
import org.datacontract.schemas._2004._07.providerdatacontracts.DimensionFilter;
import statistics.model.indicator.Dimension;

/**
 *
 * @author Andre Matos
 */
public class DimensionFilterExtension extends DimensionFilter {

    public DimensionFilterExtension() {
    }

    public static Dimension toDimension(DimensionFilter filter) {

        List<String> attributes = new ArrayList<String>();

        for (String attr : filter.getAttributes().getValue().getString()) {
            attributes.add(attr);
        }

        return new Dimension(filter.getDimensionId().getValue(), attributes);
    }

}
