

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
		var delta = (indicatorRange.maxValue.value - indicatorRange.minValue.value) / nrIntervals;
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
		
		var min = this._roundNumber(minValue, 1);
		var max = this._roundNumber(minValue + delta, 1);
		
		return new Statistics.ThematicMap.IntervalsCalculator.Interval(min, max);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Float} n
	 * @param {Integer} dec
	 */
	_roundNumber: function (n,dec) {
		n = parseFloat(n);
		if(!isNaN(n)){
			if(!dec) var dec= 0;
			var factor= Math.pow(10,dec);
			return Math.floor(n*factor+((n*factor*10)%10>=5?1:0))/factor;
		}else{
			return n;
		}
	}
	
});

