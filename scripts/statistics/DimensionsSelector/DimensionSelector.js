

Statistics.DimensionSelector = Statistics.Class({
	
	/**
	 * @public
	 * @function
	 * 
	 * @param {Statistics.Model.IndicatorMetadata} metadata
	 */
	setMetadata: function(metadata) { 
		/*Must be implemented by each class*/
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimensions
	 */
	filterDimensions: function(dimensions) {
		/*Must be implemented by each class*/
	},
	
	/**
	 * @public
	 * @function
	 * 
	 * @returns {Statistics.Model.Dimension[]}
	 *  returns the selected dimension
	 */
	getProjectedDimensions: function(dimensions) {
		/*Must be implemented by each class*/
	},
	
	/**
	 * @public
	 * @function
	 * 
	 * @returns {Statistics.DimensionSelector.Position} - Indicating the default position for dimension
	 */
	getProjectionDimensionPosition: function(dimension){
		/*Must be implemented by each class*/
	},
	
	/**
	 * @public
	 * @function
	 * Each dimension contains attribute levels, indicating the hierarchy. This function will select the
	 * default level, to represent
	 * 
	 * @returns {Statistics.DimensionSelector.AttributeLevel} - indicating the default attribute level
	 */
	getDefaultAggregationLevel: function(dimension) {
		/*Must be implemented by each class*/
	}
	
});


Statistics.DimensionSelector.Position = {
	Rows: 1,
	Columns: 2
};
