


Statistics.Model.Configuration = Statistics.Class({
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::settedMetadata', 'config::dimensionsSelected'],
	
	/**
	 * @protected
	 * @property {Statistics.Model.Dimension[]}
	 * The selected dimensions
	 */
	selectedDimensions: null,
	
	/**
	 * @public
	 * @property {Statistics.Events}
	 */
	events: null,
	
	/**
	 * @protected
	 * @property {Statistics.DimensionSelector}
	 * The default dimension selector, to choose dimensions
	 */
	dimensionSelector: null,
	
	/**
	 * @protected
	 * @property
	 * The metadata to work with
	 */
	metadata: null,
	
	/**
	 * @constructor
	 * @param {Statistics.DimensionSelector} dimensionSelector
	 * @param {Statistics.Events} [events] this is optional. If not passed, a new one will be instanciated
	 * @param {Object} options
	 * 	- metadata {Statistics.Model.IndicatorMetadata}
	 *  - selectedDimensions {Statistics.Model.Dimensions[]}
	 */
	_init: function(dimensionSelector, events, options) { 
		jQuery.extend(this, options);
		
		this.events = events ? events : new Statistics.Events(this);
		
		this.dimensionSelector = dimensionSelector;
		if(metadata) this.selectDefaultDimensions();
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistics.Model.IndicatorMetadata}
	 * 
	 * Returns the metadata
	 */
	getMetadata: function(){
		return this.metadata;
	},
	
	/**
	 * @public
	 * @function
	 * @reurns {Statistics.Model.Dimension[]}
	 * 
	 * returns the current selected dimensions
	 */
	getSelectedDimensions: function() {
		return this.selectedDimensions;
	},
	
	/**
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
		this.events.trigger('config::settedMetadata', [this, metadata]);
		
		this.selectDefaultDimensions();
	},
	
	/**
	 * @protected
	 * @abstract
	 * @function
	 * selects the default dimensions
	 */
	selectDefaultDimensions: function(){ /*should be redifined by each subclass*/ }
	
});