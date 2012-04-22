

Statistics.ConfigurationEditor = Statistics.Class({
	
	/**
	 * @private
	 * @property {Statistics.ConfigurationEditor.DimensionUpdater}
	 * Updates the configuration object
	 */
	updater: null,
	
	/**
	 * The div containing the generated html
	 * @protected
	 * @property {JqueryElement}
	 */
	div: null,
	
	/**
	 * Indicates if the configurationEditor is already drawn or being drawn
	 * @private
	 * @property {Boolean} 
	 */
	drawn: false,
	
	/**
	 * @protected
	 * @property {Statistics.Model.DimensionConfig}
	 */
	configuration: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.DimensionConfig} config - The configuration to set changes on
	 * @param {Statistics.ConfigurationEditor.DimensionUpdater} updater - An object to propagate the changes to configuration.
	 */
	_init: function(config, updater){
		this.configuration = config;
		this.updater = updater;
	},
	
	/**
	 * Called to draw the configuration editor
	 * 
	 * @abstract
	 * @public
	 * @function
	 * @param {JQueryElement} div - The element to draw the editor on
	 */
	draw: function(div) {
		this.div = div;
		this.drawn = true;
		if (this.configuration.isMetadataLoaded()) 
			this.redraw();
		else {
			//TODO: show loader
			this.configuration.events.bind('config::settedMetadata', $.proxy(this.redraw, this));
		}
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Boolean} returns true if the editor is drawn or being drawn, false otherwise.
	 */
	isDrawn: function(){
		return this.drawn;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Boolean} Returns true if it auto applies choosen options, false otherwise.
	 */
	autoApplies: function(){
		return this.updater.autoUpdates();
	},
	
	/**
	 * Apply changes to configuration
	 * @public
	 * @function
	 */
	applyChanges: function(){
		this.updater.applyConfiguration();
	},
	
	/**
	 * Discard the changes
	 * @public
	 * @function
	 * @returns {Boolean} indicates if anything was discarded
	 */
	discardChanges: function(){
		return this.updater.discardConfiguration();
	},

/**********************************************************************************
 * ********************************************************************************
 * Protected methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * @protected
	 * @function
	 * Redraws the configuration
	 */
	redraw: function() {
		// should be implemented by each subclass
	}
});
