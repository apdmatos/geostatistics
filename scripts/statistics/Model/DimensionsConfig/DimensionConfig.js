
Statistics.Model.DimensionConfig = Statistics.Class({
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: [
		'config::settedMetadata',  
		'config::filteredDimensionsChanged'],
	
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
	 */
	_init: function(dimensionSelector, events) { 
		this.events = events ? events : new Statistics.Events(this);
		
		this.dimensionSelector = dimensionSelector;
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
	getMetadata: function() {
		return this.metadata;
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
		
		this.dimensions = [];
		// copy dimensions
		for(var i = 0, d; d = metadata.dimensions[i]; ++i)
			this.dimensions.push(d.clone());
		
		if(this.dimensionSelector)
			this.dimensionSelector.setMetadata(metadata);
		
		this.selectDefaultDimensions(silent);
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
	 * @param {String} dimensionId - The dimension Id to return
	 * 
	 * @returns {Statistics.Model.Dimension}
	 */
	getDimensionById: function(dimensionId){
		for(var i = 0, d; d = this.dimensions[i]; ++i)
			if(d.id == dimensionId) return d;
			
		return null;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Boolean}
	 * 
	 * Returns true if there are any active filters. False otherwise
	 */
	hasActiveFilters: function() {
		
		if(!this.dimensions) return false;
		
		for(var i = 0, d; d = this.dimensions[i]; ++i)
			if(d.attributes.length > 0) return true;
			
		return false;
	},
	
	/**
	 * Checks if this configuration contains all the dimensions parameter. 
	 * Returns true if they are contained 
	 * 
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 * @returns {Boolean}
	 */
	contains: function(dimensions){
		
		for(var i = 0, d; d = dimensions[i]; ++i)
			if(jQuery.contains(this.dimensions, d)) return true;
			
		return false;
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