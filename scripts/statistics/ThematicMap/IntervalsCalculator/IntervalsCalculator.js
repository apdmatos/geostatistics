

Statistics.ThematicMap.IntervalsCalculator = Statistics.Class({
	
	_init: function() {
		
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorValuesRange} indicatorRange
	 * @param {Integer} nrIntervals
	 * 
	 * @returns {Interval[]} the intervals
	 */
	calculate: function(indicatorRange, nrIntervals) {
		// Should be implemented by each specific implementation
	}
	
	
});
