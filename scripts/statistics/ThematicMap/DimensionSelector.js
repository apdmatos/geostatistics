

Statistics.Map.DimensionsSelector = Statistics.Class(Statistics.DimensionsSelector.DefaultDimensionsSelector, {

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 * 
	 * @returns Statistics.Model.Dimension[]
	 *  returns the selected dimension
	 */
	getProjectedDimensions: function(dimensions) {

		for(var i = 0, d; d = dimensions[i]; ++i){
			if (d.type == Statistics.Model.DimensionType.Geographic)
				return [ d ];
		}
		
		return [];
	}

});