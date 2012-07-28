

Statistics.Model.DimensionConfig.ThematicMapProjectionConfig = 
	Statistics.Class(Statistics.Model.DimensionConfig.DimensionProjectionConfig, {

	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::aggregationLevelConfigurationChanges', 'config::colorChanges'],
	
	/**
	 * @public
	 * @property {Statistics.Model.AttributeConfiguration}
	 * Contains for geographic dimension the selected shape level
	 */
	aggregationLevel: null,
	
	/**
	 * @public
	 * @property {String[]}
	 * Selected colors to use
	 */
	colors: null,
	
	/**
	 * @constructor
	 * @param {Statistics.DimensionSelector} dimensionSelector
	 * @param {Statistics.Model.Configuration.DimensionConfig} dimensionsFilterConfig
	 */
	_init: function(dimensionSelector, dimensionsFilterConfig) { 
		Statistics.Model.DimensionConfig.DimensionProjectionConfig.prototype._init.apply(this, arguments);
		this.colors = [
			"#e5e6f2",
			"#ccd1ff",
			"#999ecb",
			"#6676ff",
			"#3348ff",
			"#0019ff",
			"#000b7c"
		];
	},

	/**
	 * @override
	 * @protected
	 * @function
	 * selects the default dimensions. 
	 * For chart dimension, the selectedDimensions array, only contains one position.
	 */
	selectDefaultDimensions: function() { 
		
		var geographicDimension = this.metadata.getDimensionsByType(Statistics.Model.DimensionType.Geographic)[0];
		this.aggregationLevel = getDefaultAggregationLevel(geographicDimension);
		
		var base = Statistics.Model.DimensionConfig.DimensionProjectionConfig; 
		base.prototype.selectDefaultDimensions.apply(this, arguments);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.AttributeConfiguration} aggregationLevel
	 * selectes the dimension aggregationLevel
	 */
	selectedAggregationLevel: function(aggregationLevel) {
		
		if(this.aggregationLevel != aggregationLevel) {
			this.aggregationLevel = aggregationLevel;
		
			this.events.trigger('config::aggregationLevelConfigurationChanges', [this]);
		}
	},

	/**
	 * @public
	 * @function
	 * @param {String[]} colors
	 * selectes the colors to represent the layer
	 */	
	selectColors: function(colors) {
		this.colors = colors;
		this.events.trigger('config::colorChanges', [this]);
	}
	
});

