
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
	},
	
	containsAttributeId: function(dimensionId, attributeId){
		var self = this;
		function compareDimensions(filterArr) {
			var d = self.getDimensionFilterById(dimensionId);
			for(var j = 0; attrId = d.attributeIds[j]; ++j)
				if(attrId == attributeId) return true;
				
			return false;
		}
		
		return compareDimensions(this.projectedDimensions) || compareDimensions(this.filteredDimensions);
	},
	
	/**
	 * @public
	 * @param {String} dimensionId
	 * @returns {DimensionFilter}
	 */
	getDimensionFilterById: function(dimensionId){
		
		return this._getFilterById(this.projectedDimensions, dimensionId) || this._getFilterById(this.filteredDimensions, dimensionId);
	},
	
/**************************************************************************************
 * ************************************************************************************
 * ************** Private methods
 * ************************************************************************************
 */	
 	
	/**
	 * @privaye
	 * @param {Statistics.Model.Filter.DimensionFilter} filter
	 * @param {String} dimensionId
	 * @returns {DimensionFilter}
	 */
 	_getFilterById: function(filter, dimensionId){
		var i, d;
		for(i = 0; d = filter[i]; ++i)
			if(d.dimensionId == dimensionId) return d;
		
		return false;
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
