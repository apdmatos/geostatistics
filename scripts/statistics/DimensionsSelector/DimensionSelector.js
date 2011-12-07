

Statistics.DimensionSelector = Statistics.Class({
	
	/**
	 * @public
	 * @function
	 * @param {Array<Statistics.Model.Dimension>} dimensions
	 * 
	 * @returns Array<Statistics.Model.Dimension> the selected dimensions
	 */
	getSelectedDimensions: function(dimensions) {
		/*Must be implemented by each class*/
	},
	
	/**
	 * @public
	 * @function
	 * @param {Array<Statistics.Model.Dimension>} dimensions
	 * 
	 * @returns Statistics.Model.Dimension
	 *  returns the selected dimension
	 */
	getAxisSelectedDimensions: function(dimensions) {
		/*Must be implemented by each class*/
	}
	
});
