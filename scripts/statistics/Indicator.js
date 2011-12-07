


Statistics.Indicator = Statistics.Class({
	
	/**
	 * @constant
	 * @property EVENT_TYPES 
	 */
	EVENT_TYPES: ['indicator:requestmetadata', 'indicator:metadataavailable'],
	
	/**
	 * @private
	 * @property {String}
	 * the indicator id, to request the service
	 */
	id: null,
	
	/**
	 * @private
	 * @property {String}
	 * The source id to request the server
	 */
	sourceid: null,
	
	/**
	 * @private
	 * @property {Array<Statistics.Representation>}
	 */
	representations: null,
	
	/**
	 * @private
	 * @property {Statistics.Repository}
	 * A repository to get data
	 */
	repository: null,
	
	/**
	 * @private
	 * @property {Statistics.Model.IndicatorMetadata}
	 * The metadata for the indicator
	 */
	metadata: null,
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension}
	 */
	selectedDimensions: null,
	
	/**
	 * @private
	 * @property {Statistics.DimensionsSelector}
	 * A dimension selector to select the dimension when the server responds with metadata
	 */
	dimensionSelector: null,
	
	/**
	 * @private
	 * @property {Statistics.Repository.Request}
	 */
	request: null,
	
	/**
	 * @constructor
	 * @param {String} id
	 * @param {String} sourceid
	 * @param {Statistics.Repository} repository
	 * @param {Array<Statistics.Representation>} representations
	 * @param {Statistics.DimensionsSelector} dimensionSelector
	 * @param {Object} options
	 * 	- selectedDimensions {Array<Statistics.Model.Dimension>}
	 *  - metadata {Array<Statistics.Model.IndicatorMetadata>}
	 */
	_init: function(id, sourceid, repository, representations, dimensionSelector, options) {
		
		jQuery.extend(this, options);
		
		this.id = id;
		this.sourceid = sourceid;
		this.repository = repository;
		this.representations = representations;
		
		if(!metadata) this._loadMetadata();
		else this.chooseSelectedDimensions();
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistics.Model.IndicatorMetadata}
	 */
	getMetadata: function() {
		return this.metadata;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Array<Statistics.Model.Dimension>}
	 */
	getSelectedDimensions: function(){
		return this.selectedDimensions;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} selectedDimensions
	 */
	setSelectedDimensions: function(selectedDimensions) {
		
		this.selectedDimensions = dimensionSelector;
		for(var i = 0, representation; representation = this.representations[i]; i++)
			representation.setSelectedDimensions(selectedDimensions);
	},
	
	/**
	 * @private
	 * @function
	 * requests the server for metadata
	 */
	_loadMetadata: function() {
		
		if(!repository)
			throw "Cannot request for indicator metadata, with no repository";
		
		if(this.request) this.request.cancelRequest();
		
		this.request = 	
			this.repository.getIndicatorMetadata(
				this.sourceid, 
				this.id, 
				{
					successCallback: jQuery.proxy(this._onComplete, this),
					errorCallback: jQuery.proxy(this._onError, this)
				});
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} indicatorMetadata
	 */
	_onComplete: function(indicatorMetadata){
		
		this.selectedDimensions = this.dimensionSelector.getSelectedDimensions(indicatorMetadata.dimensions);
		var defaultAxisSelected = this.dimensionSelector.getAxisSelectedDimensions(indicatorMetadata.dimensions);
		
		for (var i = 0, representation; representation = this.representations[i]; i++) {
			
			representation.setIndicatorMetadata(indicatorMetadata);
			representation.setSelectedDimensions(this.selectedDimensions);
			representation.setSelectedAxisDimension(defaultAxisSelected);
		}
		
	},
	
	/**
	 * @private
	 * @function
	 * 
	 * TO BE DEFINED...
	 */
	_onError: function(){
		//TODO: implement this...
	}
	
});
