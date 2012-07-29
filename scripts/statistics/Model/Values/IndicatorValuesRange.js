
Statistics.Model.Values.IndicatorValuesRange = Statistics.Class({
	
	/**
	 * @public
	 * @property {Statistics.Model.IndicatorValue}
	 * contains the minimum range value
	 */
	minValue: null,

	/**
	 * @public
	 * @property {Statistics.Model.IndicatorValue}
	 * contains the maximum range value
	 */	
	maxValue: null,
	
	_init: function(min, max){
		
		this.minValue = min;
		this.maxValue = max;
	}
	
});



Statistics.Model.Values.IndicatorValuesRange.FromObject = function(obj) {
	
	return new Statistics.Model.Values.IndicatorValuesRange(
		new Statistics.Model.Values.IndicatorValue.FromObject(obj.Minimum),
		new Statistics.Model.Values.IndicatorValue.FromObject(obj.Maximum)
	);
}
