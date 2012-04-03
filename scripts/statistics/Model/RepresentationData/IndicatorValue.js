
Statistics.Model.RepresentationData.IndicatorValue = Statistics.Class({
	
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
		
		this.filteredDimensions = selectedDimensions;
		this.projectedDimensions = axisDimension;
		this.value = value;
	}
	
});



Statistics.Model.RepresentationData.IndicatorValue.FromObject = function(obj) {
	
	var filteredDimensions = [];
	for(var i = 0, filter; filter = obj.filteredDimensions[i]; ++i){
		dimensions.push(Statistics.Model.RepresentationData.DimensionFilter.FromObject(filter));
	}
	
	var projectedDimensions = [];
	for(var j = 0, proj; proj = obj.filteredDimensions[j]; ++j){
		dimensions.push(Statistics.Model.RepresentationData.DimensionFilter.FromObject(proj));
	}
	
	return new Statistics.Model.RepresentationData.DataSerieValue(filteredDimensions, projectedDimensions, obj.value);
}
