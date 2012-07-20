package statistics.model.indicator;

public class IndicatorRange {

    public IndicatorValue max;
    public IndicatorValue min;

    public IndicatorRange() {

    }

    public IndicatorRange(IndicatorValue max, IndicatorValue min) {

        this.max = max;
        this.min = min;
    }
}
