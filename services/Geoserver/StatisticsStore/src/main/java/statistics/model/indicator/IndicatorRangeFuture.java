package statistics.model.indicator;

import java.util.logging.Level;
import java.util.logging.Logger;
import statistics.utils.concurrent.ManualResetEvent;

public class IndicatorRangeFuture {

    private volatile ManualResetEvent event;
    private volatile IndicatorValue max;
    private volatile IndicatorValue min;

    public IndicatorRangeFuture() {
        event = new ManualResetEvent(false);
    }

    public IndicatorRangeFuture(IndicatorValue max, IndicatorValue min) {
        event = new ManualResetEvent(true);
        this.max = max;
        this.min = min;
    }

    public void setRange(IndicatorValue max, IndicatorValue min) {
        this.max = max;
        this.min = min;
        this.event.set();
    }

    public IndicatorValue getMaxValue() {
        try {
            event.waitOne();
        } catch (InterruptedException ex) {
            Logger.getLogger(IndicatorRangeFuture.class.getName()).log(Level.SEVERE, "Thread was interrupted while waiting for values", ex);
            return null;
        }

        return max;
    }

    public IndicatorValue getMinValue() {
        try {
            event.waitOne();
        } catch (InterruptedException ex) {
            Logger.getLogger(IndicatorRangeFuture.class.getName()).log(Level.SEVERE, "Thread was interrupted while waiting for values", ex);
            return null;
        }

        return min;
    }

    public boolean hasValues () {
        return event.isOpened();
    }
}
