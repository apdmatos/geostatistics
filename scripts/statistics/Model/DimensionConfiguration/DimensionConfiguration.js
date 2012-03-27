
Statistics.Model.DimensionConfiguration = Statistics.Class({
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::settedMetadata', 'config::filteredDimensionsSelected'],
	
	/**
	 * @protected
	 * @property {Statistics.Model.Dimension[]}
	 * The selected dimensions
	 */
	dimensions: null,
	
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
	 * @param {Statistics.DimensionSelector} dimensionSelector - Dimension selector, to select the first dimensions
	 * @param {Statistics.Events} [events] this is optional. If not passed, a new one will be instanciated
	 * @param {Object} options
	 * 	- metadata {Statistics.Model.IndicatorMetadata}
	 *  - selectedDimensions {Statistics.Model.Dimensions[]}
	 */
	_init: function(dimensionSelector, events, options) { 
		jQuery.extend(this, options);
		
		this.events = events ? events : new Statistics.Events(this);
		
		this.dimensionSelector = dimensionSelector;
		if(this.metadata) this.selectDefaultDimensions();
	},
	
	/**
	 * @public
	 * @param {Statistics.DimensionSelector} dimensionSelector
	 * Sets the a dimension selector, to select the default dimensions, at the first time
	 */
	setDimensionSelector: function(dimensionSelector){
		this.dimensionSelector = dimensionSelector;
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
		return this.dimensions;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} metadata
	 * @param {Boolean} [silent=false] optional property to silent the event
	 * sets the metadata.
	 * 
	 * When this method is called some things need to happen:
	 * 	1. trigger the event setted metadata
	 *  2. select default dimensions
	 */
	setMetadata: function(metadata, silent) {
		this.metadata = metadata;
		
		if(!silent) 
			this.events.trigger('config::settedMetadata', [this, metadata]);
		
		this.selectDefaultDimensions();
	},
	
	/**
	 * @public
	 * @function
	 * @param {String} dimensionId - The dimension Id to return
	 * 
	 * @returns {Statistics.Model.Dimension}
	 */
	getDimensionById: function(dimensionId){
		for(var i = 0, d; d = this.dimensions; ++i)
			if(d == dimensionId) return d;
			
		return null;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 * @returns {Boolean} returns true if the dimensions parameter is a subset of selected dimensions
	 */
	contains: function(dimensions){
		for(var i = 0, d; d = dimension[i]; ++i)
			if(!jQuery.inArray(d, this.dimensions)) return false;
		
		return true;	
	},
	
	/**
	 * @public
	 * @function
	 * This function will fire the event that notifies a change to filtered dimensions
	 */
	filteredDimensionsChanged: function(){
		this.events.trigger('config::filteredDimensionsChanged', [this]);
	},
	
/**********************************************
 * 
 * @protected methods
 */	
 
 	/**
	 * @protected
	 * @abstract
	 * @function
	 * @param {Boolean} [silent=false] optional property to silent the event
	 * selects the default dimensions
	 */
	selectDefaultDimensions: function(silent){ /*should be redifined by each subclass*/ },
	
	/**
	 * @protected
	 * @function
	 * @param {Statistics.Model.Dimension} dimension - The dimension to configure
	 */
	_addDimension: function(dimension){
		this.dimensions.push(dimension);
	},
	
	/**
	 * @protected
	 * @function
	 * @param {Statistics.Model.Dimension} dimension - The dimension to remove
	 */
	_removeDimension: function(dimension){
		this.dimensions = jQuery.grep(this.dimensions, function(d){
			return d.id != dimension.id;
		});
	}
	
});