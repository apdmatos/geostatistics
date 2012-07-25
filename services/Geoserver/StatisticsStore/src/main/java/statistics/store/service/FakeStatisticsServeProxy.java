package statistics.store.service;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import statistics.model.indicator.Dimension;
import statistics.model.indicator.IndicatorConfiguration;
import statistics.model.indicator.IndicatorRangeFuture;
import statistics.model.indicator.IndicatorValue;
import statistics.model.indicator.IndicatorValuesFuture;

/**
 *
 * @author Andre Matos
 */
public class FakeStatisticsServeProxy implements IStatisticsServiceProxy {

    private double max = 2000;
    private double min = 10;
    private Random r = new Random();

    @Override
    public IndicatorValuesFuture getIndicatorValues(IndicatorConfiguration config, List<String> shapeIds) {
        return new IndicatorValuesFuture() {
            @Override
            public List<IndicatorValue> getIndicatorValues(List<Dimension> projected, String shapeId) {
                List<IndicatorValue> lst = new ArrayList<IndicatorValue>();
                lst.add(new IndicatorValue(null, projected, getValue()));
                return lst;
            }
        };
    }

    @Override
    public IndicatorRangeFuture getIndicatorRange(IndicatorConfiguration config, List<String> shapeIds) {

        Logger.getLogger(FakeStatisticsServeProxy.class.getName()).log (
            Level.INFO,
            "getIndicatorRange"
        );
        for (StackTraceElement ste : Thread.currentThread().getStackTrace()) {
            System.out.println(ste + "\n");
        }

        IndicatorValue maximun = new IndicatorValue(null, null, max);
        IndicatorValue minimun = new IndicatorValue(null, null, min);

        return new IndicatorRangeFuture(maximun, minimun);

    }

    private double getValue() {
        return (r.nextDouble() * (max - min)) + min;
    }

}
