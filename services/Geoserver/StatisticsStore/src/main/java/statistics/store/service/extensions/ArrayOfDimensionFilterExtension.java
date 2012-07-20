package statistics.store.service.extensions;

import com.microsoft.schemas._2003._10.serialization.arrays.ArrayOfstring;
import java.util.ArrayList;
import java.util.List;
import org.datacontract.schemas._2004._07.providerdatacontracts.ArrayOfDimensionFilter;
import org.datacontract.schemas._2004._07.providerdatacontracts.DimensionFilter;
import org.datacontract.schemas._2004._07.providerdatacontracts.ObjectFactory;
import statistics.model.indicator.Dimension;

/**
 *
 * @author Andre Matos
 */
public class ArrayOfDimensionFilterExtension extends ArrayOfDimensionFilter {

    private ObjectFactory factory;

    public ArrayOfDimensionFilterExtension() {
        dimensionFilter = new ArrayList<DimensionFilter>();
        factory = new ObjectFactory();
    }

    public void addDimension(Dimension d) {

        addDimension(d.id, d.dimensionAttributes);
    }

    public void addDimension(String dimensionId, List<String> attributeIds) {

        DimensionFilter filter = new DimensionFilter();
        filter.setDimensionId(factory.createDimensionFilterDimensionId(dimensionId));

        ArrayOfStringExtensions attributes = new ArrayOfStringExtensions();
        for (String attribute : attributeIds)
            attributes.add(attribute);

        filter.setAttributes(factory.createDimensionFilterAttributes(attributes));

        dimensionFilter.add(filter);
    }

    public static List<Dimension> toDimensionList(ArrayOfDimensionFilter filters) {

        List<Dimension> dimensions = new ArrayList<Dimension>();
        for (DimensionFilter dimensionFilter : filters.getDimensionFilter()) {
            dimensions.add( DimensionFilterExtension.toDimension(dimensionFilter) );
        }

        return dimensions;
    }

}
