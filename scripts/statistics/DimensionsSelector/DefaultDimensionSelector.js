


Statistics.DimensionSelector.DefaultDimensionSelector = Statistics.Class(Statistics.DimensionSelector, {
	
	
	/**
	 * @public
	 * @function
	 * @param {Array<Statistics.Model.Dimension>} dimensions
	 * 
	 * @returns Array<Statistics.Model.Dimension> the selected dimensions
	 */
	getSelectedDimensions: function(dimensions) {
				
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
	 * @param {Array<Statistics.Model.Dimension>} dimensions
	 * 
	 * @returns Statistics.Model.Dimension
	 *  returns the selected dimension
	 */
	getAxisSelectedDimensions: function(dimensions) {
		
		var newDimension = dimensions[0].clone();
		
		var attributes = dimensions[0].attributes;
		for (var i = 0, attribute; (attribute = attributes[i]) && i < 2; i++) {
						
			newDimension.addAttribute(attribute);
					
		}
		
		return newDimension;
	}
	
	
});
