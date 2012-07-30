

Statistics.ThematicMap.IntervalsCalculator.Interval = Statistics.Class({
	
	/**
	 * @public
	 * @property {Float}
	 * The lower bound interval value
	 */
	min: null,

	/**
	 * @public
	 * @property {Float}
	 * The upper bound interval value
	 */	
	max: null,
	
	/**
	 * @constructor
	 * @param {Float} min
	 * @param {Float} max
	 */
	_init: function(min, max) {
		this.min = min;
		this.max = max;
	}
	
	
});
