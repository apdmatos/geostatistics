

Statistics.Model.DimensionConfiguration.DimensionProjectionConfig = Statistics.Class(Statistics.Model.DimensionConfiguration, {
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::projectedDimensionsChanged'],
	
	/**
	 * @private
	 * @property {Statistics.Model.DimensionConfiguration.DimensionFilterConfig}
	 * A dimension to filter
	 */
	dimensionsFilter: null,
	
	/**
	 * @constructor
	 * @param {Statistics.DimensionSelector} dimensionSelector
	 * @param {Statistics.Model.Configuration.DimensionConfig} dimensionsFilterConfig
	 * @param {Object} options
	 */
	_init: function(dimensionSelector, dimensionsFilterConfig, options) { 
		Statistics.Model.Configuration.prototype._init.apply(
			this, 
			[
				dimensionSelector,
				dimensionsFilterConfig.events,
				options
			]);
		
		this.dimensionsFilter = dimensionsFilterConfig;
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} metadata
	 * sets the metadata.
	 * 
	 * When this method is called some things need to happen:
	 * 	1. trigger the event setted metadata
	 *  2. select default dimensions
	 */
	setMetadata: function(metadata) { 
		this.dimensionsFilterConfig.setMetadata(metadata, true);
		Statistics.Model.Configuration.prototype.setMetadata.apply(this, arguments);
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistics.Model.Configurtion.DimensionConfig}
	 * 
	 * returns the configuration for dimensions
	 */
	getDimensionsFilterConfig: function(){
		return this.dimensionsFilterConfig;
	},
	
	/**
	 * @override
	 * @protected
	 * @function
	 * selects the default dimensions. 
	 * For chart dimension, the selectedDimensions array, only contains one position.
	 */
	selectDefaultDimensions: function(){ 
		this.dimensions = 
			this.dimensionSelector.getProjectedDimensions(this.metadata.dimensions);
		
		for(var i = 0, d; d = this.dimensions[i]; ++i)
			this.dimensionsFilterConfig._removeDimension(d);
		
		this.filteredDimensionsChanged();
	},

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 */
	projectDimensions: function(dimensions) {
		
		var i, d;
		for(i = 0, d; d = this.dimensions[i]; ++i)
			this.dimensionsFilterConfig._addDimension(d);
			
		for(i = 0, d; d = this.dimensions[i]; ++i)
			this.dimensionsFilterConfig._removeDimension(d);
			
		this.dimensions = dimensions;
		
		this.events.trigger('config::projectedDimensionsChanged', [this.dimensions]);
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * @param {String} dimensionId - The dimension Id to return
	 * 
	 * @returns {Statistics.Model.Dimension}
	 */
	getDimensionById: function(dimensionId){
		var d = Statistics.Model.Configuration.prototype.getDimensionById.apply(this, arguments);
		return d ? d : this.dimensionsFilterConfig.getDimensionById(dimensionId);
	}
});
