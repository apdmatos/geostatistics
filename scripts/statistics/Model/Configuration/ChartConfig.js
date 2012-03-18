

Statistics.Model.Configuration.ChartConfig = Statistics.Class(Statistics.Model.Configuration, {
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::axisDimensionChanged'],
	
	/**
	 * @private
	 * @property {Statistics.Model.Configuration.DimensionConfig}
	 * The dimension config
	 */
	dimensionsConfig: null,
	
	/**
	 * @constructor
	 * @param {Statistics.DimensionSelector} dimensionSelector
	 * @param {Statistics.Model.Configuration.DimensionConfig} dimensionConfig
	 * @param {Object} options
	 */
	_init: function(dimensionSelector, dimensionsConfig, options) { 
		Statistics.Model.Configuration.prototype._init.apply(
			this, 
			[
				dimensionSelector,
				dimensionsConfig.events,
				options
			]);
		
		this.dimensionsConfig = dimensionsConfig;
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
	setMetadata: function(metadata){ 
		Statistics.Model.Configuration.prototype.setMetadata.apply(this, arguments);
		this.dimensionsConfig.setMetadata(metadata);
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistics.Model.Configurtion.DimensionConfig}
	 * 
	 * returns the configuration for dimensions
	 */
	getDimensionsConfig: function(){
		return this.dimensionsConfig;
	},
	
	/**
	 * @override
	 * @protected
	 * @function
	 * selects the default dimensions. 
	 * For chart dimension, the selectedDimensions array, only contains one position.
	 */
	selectDefaultDimensions: function(){ 
		this.selectedDimensions = 
			[this.dimensionSelector.getAxisSelectedDimensions(this.metadata.dimensions)];
		
		// will be fired by DimensionConfig Object. We share the same event object
		//this.events.trigger('config::dimensionsSelected', [this.selectedDimensions]);
	}
});
