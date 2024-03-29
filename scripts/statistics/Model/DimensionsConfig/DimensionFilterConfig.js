
Statistics.Model.DimensionConfig.DimensionFilterConfig = 
	Statistics.Class(Statistics.Model.DimensionConfig, {
	
	/**
	 * @protected
	 * @abstract
	 * @function
	 * @param {Boolean} [silent=false] optional property to silent the event
	 * selects the default dimensions
	 */
	selectDefaultDimensions: function(silent){ 
		
		if(this.dimensionSelector) {
			this.dimensionSelector.filterDimensions(this.dimensions);	
		}
		
		//fire event
		if(!silent) this.filteredDimensionsChanged();
	}
});
