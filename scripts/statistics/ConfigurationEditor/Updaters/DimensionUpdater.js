


Statistics.ConfigurationEditor.DimensionUpdater = Statistics.Class({
	
	/**
	 * @protected
	 * @property {Statistics.Model.DimensionConfig}
	 */
	configuration: null,
	
	/**
	 * @constructor
	 */
	_init: function(config){
		this.configuration = config;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.DimensionConfig} config
	 */
	setConfiguration: function(config){
		this.configuration = config;
	},
	
	/**
	 * @abstract
	 * @public
	 * @function
	 * @returns {Boolean} returns true if it auto updates the information, on configuration.
	 * False if it is needed to call apply/discard methods
	 */
	autoUpdates: function(){
		// should be implemented by subclasses
	},
	
	/**
	 * @abstract
	 * @public
	 * @function
	 * Applies the modifications, to the configuration
	 */
	applyConfiguration: function(){
		// should be implemented by subclasses
	},
	
	/**
	 * @abstract
	 * @public
	 * @function
	 * Discards the current modifications
	 * 
	 * @returns {Boolean} returns true if there are anything to discard, false otherwise
	 */
	discardConfiguration: function(){
		// should be implemented by subclasses
	}
});
