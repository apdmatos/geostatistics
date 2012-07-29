

Statistics.ThematicMap.IntervalsCalculator.LinearIntervalsCalculator = 
	Statistics.Class(Statistics.ThematicMap.IntervalsCalculator, 
{	
	/**
	 * @Override
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorValuesRange} indicatorRange
	 * @param {Integer} nrIntervals
	 * 
	 * @returns {Interval[]} the intervals
	 */
	calculate: function(indicatorRange, nrIntervals) {
		
		var intervals = [];
		var delta = (indicatorRange.minValue.value - indicatorRange.minValue.value) / nrIntervals;
		var minValue = indicatorRange.minValue.value;
		for(var i = 0; i < nrIntervals; ++i) {
			
			intervals.push( this._calculateInterval(minValue, delta) );
			minValue += delta;
		}
		
		return intervals;
	},
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/

	/**
	 * @public
	 * @function
	 * @param {Float} minValue
	 * @param {Float} value
	 */
	_calculateInterval: function(minValue, delta) {
		
		return new Statistics.ThemeticMap.IntervalsCalculator.Interval(minValue, minValue + delta);
	}
	
});

