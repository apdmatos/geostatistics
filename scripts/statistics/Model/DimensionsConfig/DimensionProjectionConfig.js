

Statistics.Model.DimensionConfig.DimensionProjectionConfig = 
	Statistics.Class(Statistics.Model.DimensionConfig, {
	
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
	 */
	_init: function(dimensionSelector, dimensionsFilterConfig) { 
		Statistics.Model.DimensionConfig.prototype._init.apply(
			this, 
			[
				dimensionSelector,
				dimensionsFilterConfig.events
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
		this.metadata = metadata;
		this.dimensionsFilter.setMetadata(metadata, true);
		this.events.trigger('config::settedMetadata', [this, metadata]);
		this.selectDefaultDimensions();
//		Statistics.Model.Configuration.prototype.setMetadata.apply(this, arguments);
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistics.Model.Configurtion.DimensionConfig}
	 * 
	 * returns the configuration for dimensions
	 */
	getDimensionsFilterConfig: function(){
		return this.dimensionsFilter;
	},

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 */
	setProjectedDimensions: function(dimensions) {
		
		var i, d;
		for(i = 0, d; d = this.dimensions[i]; ++i)
			this.dimensionsFilter._addDimension(d);
			
		for(i = 0, d; d = dimensions[i]; ++i)
			this.dimensionsFilter._removeDimension(d);
			
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
		var d = Statistics.Model.DimensionConfig.prototype.getDimensionById.apply(this, arguments);
		return d ? d : this.dimensionsFilter.getDimensionById(dimensionId);
	},
		
/**********************************************
 * 
 * @protected methods
 */	
 	
	/**
	 * @override
	 * @protected
	 * @function
	 * selects the default dimensions. 
	 * For chart dimension, the selectedDimensions array, only contains one position.
	 */
	selectDefaultDimensions: function(){
		
		if(this.dimensionSelector)
			this.dimensions = 
				this.dimensionSelector.getProjectedDimensions(this.dimensionsFilter.dimensions);


		for(var i = 0, d; d = this.dimensions[i]; ++i)
			this.dimensionsFilter._removeDimension(d);
		
		this.filteredDimensionsChanged();
	}

});
