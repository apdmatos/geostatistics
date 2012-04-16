

Statistics.ConfigurationEditor = Statistics.Class({
	
	/**
	 * The div containing the generated html
	 * @protected
	 * @property {JqueryElement}
	 */
	div: null,
	
	/**
	 * @protected
	 * @property {Statistics.Model.DimensionConfig}
	 */
	configuration: null,
	
	/**
	 * @protected
	 * @property {Boolean}
	 * Applies the changes on the fly to configuration. Default is false
	 */
	autoApply: false,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.DimensionConfig} config - The configuration to set changes on
	 * @param {Boolean} autoApply[=false] - Applies the changes on the fly to configuration. Default is false
	 */
	_init: function(config, autoApply){
		this.configuration = config;
		this.autoApply = autoApply;
	},
	
	/**
	 * Called to draw the configuration editor
	 * 
	 * @public
	 * @function
	 * @param {JQueryElement} div - The element to draw the editor on
	 */
	draw: function(div){
		this.div = div;
		// implement on concret classes
	},
	
	/**
	 * Apply changes to configuration
	 * @public
	 * @function
	 */
	applyChanges: function(){
		// implement on concret classes
	},
	
	/**
	 * Discard the changes
	 * @public
	 * @function
	 */
	discardChanges: function(){
		// implement on concret classes
	}
	
});
