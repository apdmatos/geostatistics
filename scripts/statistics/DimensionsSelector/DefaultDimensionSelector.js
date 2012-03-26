


Statistics.DimensionSelector.DefaultDimensionSelector = Statistics.Class(Statistics.DimensionSelector, {
	
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 * 
	 * @returns Statistics.Model.Dimension[] the selected dimensions
	 */
	getFilterDimensions: function(dimensions) {
				
		var selectedDimensions = [];
		for(var i = 0, dimension; dimension = dimensions[i]; i++) {
			
			var newDimension = dimension.clone();
			newDimension.addAttribute(dimension.attributes[0]);
			
			selectedDimensions.push(newDimension);
		}
		
		return selectedDimensions;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 * 
	 * @returns Statistics.Model.Dimension[]
	 *  returns the selected dimension
	 */
	getProjectedDimensions: function(dimensions) {

		var newDimension = dimensions[0].clone();
		return [newDimension];
	}
	
	
});
