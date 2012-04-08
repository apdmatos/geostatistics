

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
	}
	
});


Statistics.DimensionSelector.Position = {
	Rows: 1,
	Columns: 2
};
