package statistics.store.service;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import statistics.model.indicator.IndicatorConfiguration;
import statistics.model.indicator.IndicatorRange;
import statistics.model.indicator.IndicatorValue;

/**
 *
 * @author Andre Matos
 */
public class FakeStatisticsServeProxy implements IStatisticsServiceProxy {

    private double max = 2000;
    private double min = 10;
    private Random r = new Random();

    @Override
    public void requestIndicatorValues(IndicatorConfiguration config, List<String> shapeIds) {
        
    }

    @Override
    public List<IndicatorValue> getIndicatorValue(String shapeId) {

        Logger.getLogger(FakeStatisticsServeProxy.class.getName()).log (
            Level.INFO,
            "getIndicatorValue \tshapeid: " + shapeId
        );


        List<IndicatorValue> lst = new ArrayList<IndicatorValue>();
        lst.add(new IndicatorValue(null, getValue()));

        return lst;
    }

    @Override
    public IndicatorRange getIndicatorRange() {

        Logger.getLogger(FakeStatisticsServeProxy.class.getName()).log (
            Level.INFO,
            "getIndicatorRange"
        );
        for (StackTraceElement ste : Thread.currentThread().getStackTrace()) {
            System.out.println(ste + "\n");
        }

        IndicatorValue maximun = new IndicatorValue(null, max);
        IndicatorValue minimun = new IndicatorValue(null, min);

        return new IndicatorRange(maximun, minimun);

    }

    private double getValue() {
        return (r.nextDouble() * (max - min)) + min;
    }

}
