
Statistics.Model.DimensionConfiguration.DimensionFilterConfig = Statistics.Class(Statistics.Model.DimensionConfiguration, {
	
	/**
	 * @protected
	 * @abstract
	 * @function
	 * @param {Boolean} [silent=false] optional property to silent the event
	 * selects the default dimensions
	 */
	selectDefaultDimensions: function(silent){ 
		
		if(!this.dimensions) {
		
			this.dimensions = 
				this.dimensionSelector.getFilterDimensions(this.metadata.dimensions);
			
			//fire event
			if(!silent) this.filteredDimensionsChanged();	
		}
	}
});
