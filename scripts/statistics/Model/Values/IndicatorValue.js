
Statistics.Model.Values.IndicatorValue = Statistics.Class({
	
	/**
	 * @public
	 * @property {DimensionFilter[]}
	 */
	filteredDimensions: null,
	
	/**
	 * @public
	 * @property {DimensionFilter[]}
	 */
	projectedDimensions: null,
	
	/**
	 * @public
	 * @property {double}
	 * 
	 */
	value: null,
	
	/**
	 * @constructor
	 * @param {Dimension[]} filteredDimensions
	 * @param {Dimension[]} projectedDimensions
	 * @param {double} value
	 */
	_init: function(filteredDimensions, projectedDimensions, value) { 
		
		this.filteredDimensions = filteredDimensions;
		this.projectedDimensions = projectedDimensions;
		this.value = value;
	}
	
});



Statistics.Model.Values.IndicatorValue.FromObject = function(obj) {
	
	var filteredDimensions = [];
	for(var i = 0, filter; filter = obj.filters[i]; ++i){
		filteredDimensions.push(Statistics.Model.Filter.DimensionFilter.FromObject(filter));
	}
	
	var projectedDimensions = [];
	for(var j = 0, proj; proj = obj.projected[j]; ++j){
		projectedDimensions.push(Statistics.Model.Filter.DimensionFilter.FromObject(proj));
	}
	
	return new Statistics.Model.Values.IndicatorValue(filteredDimensions, projectedDimensions, obj.value);
}
