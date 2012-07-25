package statistics.model.indicator;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import statistics.utils.concurrent.ManualResetEvent;

/**
 *
 * @author Andre Matos
 */
public class IndicatorValuesFuture {

    private volatile ManualResetEvent event;
    private volatile List<IndicatorValue> values;

    public IndicatorValuesFuture() {
        event = new ManualResetEvent(false);
    }

    public IndicatorValuesFuture(List<IndicatorValue> values, boolean open) {
        this.values = values;
        event = new ManualResetEvent(open);
    }

    public void addValues(List<IndicatorValue> values) {
        this.values = values;
        event.set();
    }

    public List<IndicatorValue> getIndicatorValues (List<Dimension> projected, String shapeId) {
        
        try {
            event.waitOne();
        } catch (InterruptedException ex) {
            Logger.getLogger(IndicatorValuesFuture.class.getName()).log(Level.SEVERE, "Thread was interrupted while waiting for values", ex);
            return null;
        }

        List<statistics.model.indicator.IndicatorValue> list =
                new ArrayList<statistics.model.indicator.IndicatorValue>();

        if(values != null) {
            for (IndicatorValue indicatorValue : values) {

                if(indicatorValue.matchFilter(projected, shapeId))
                    list.add(indicatorValue);
            }
        }


        return list;
    }

    public boolean hasValues () {
        return event.isOpened();
    }
}
