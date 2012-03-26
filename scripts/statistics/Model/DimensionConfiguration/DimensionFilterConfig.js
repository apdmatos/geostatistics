

Statistics.Model.DimensionConfiguration.DimensionFilterConfig = Statistics.Class(Statistics.Model.DimensionConfiguration, {
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::dimensionsChanged'],
	
	/**
	 * @protected
	 * @abstract
	 * @function
	 * selects the default dimensions
	 */
	selectDefaultDimensions: function(){ 
		
		if(!this.selectedDimensions) {
		
			this.selectedDimensions = 
				this.dimensionSelector.getSelectedDimensions(this.metadata.dimensions);
			
			//fire event
			this.events.trigger('config::dimensionsSelected', [this.selectedDimensions]);	
		}
	}
	
});
