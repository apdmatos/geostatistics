
Statistics.Model.Values.IndicatorValueRange = Statistics.Class({
	
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



Statistics.Model.Values.IndicatorValueRange.FromObject = function(obj) {
	
	return new Statistics.Model.Values.IndicatorValueRange(
		Statistics.Model.Values.IndicatorValue.FromObject(obj.min),
		Statistics.Model.Values.IndicatorValue.FromObject(obj.max)
	);
}
