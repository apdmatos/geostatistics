
Statistics.Model.RepresentationData.DataSerieValue = Statistics.Class({
	
	/**
	 * @public
	 * @property {DimensionFilter[]}
	 */
	selectedDimensions: null,
	
	/**
	 * @public
	 * @property {DimensionFilter}
	 */
	axisDimension: null,
	
	/**
	 * @public
	 * @property {double}
	 * 
	 */
	value: null,
	
	/**
	 * @constructor
	 * @param {Dimension[]} selectedDimensions
	 * @param {Dimension} axisDimension
	 * @param {double} value
	 */
	_init: function(selectedDimensions, axisDimension, value) { 
		
		this.selectedDimensions = selectedDimensions;
		this.axisDimension = axisDimension;
		this.value = value;
	}
	
});



Statistics.Model.RepresentationData.DataSerieValue.FromObject = function(obj) {
	
	var dimensions = [];
	for(var i = 0, selected; selected = obj.selectedDimensions[i]; ++i){
		dimensions.push(Statistics.Model.RepresentationData.DimensionFilter.FromObject(selected));
	}
	
	var axis = Statistics.Model.RepresentationData.DimensionFilter.FromObject(obj.axisDimension);
	return new Statistics.Model.RepresentationData.DataSerieValue(dimensions, axis, obj.value);
}
