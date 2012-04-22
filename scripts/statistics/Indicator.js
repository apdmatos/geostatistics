


Statistics.Indicator = Statistics.Class({
	
	/**
	 * @constant
	 * @property EVENT_TYPES 
	 */
	EVENT_TYPES: ['indicator::requestmetadata', 'indicator::metadataavailable'],
	
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
	 * @property {Statistics.Model.Configurations[]}
	 */
	configurations: null,
	
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
	 * @property {Statistics.Repository.Request}
	 * Contains the request state. Used to cancel requests
	 */
	request: null,
	
	/**
	 * @constructor
	 * @param {String} id
	 * @param {String} sourceid
	 * @param {Statistics.Repository} repository
	 * @param {Statistics.Model.Configuration[]} configurations
	 * @param {Object} options
	 *  - metadata {Array<Statistics.Model.IndicatorMetadata>}
	 */
	_init: function(id, sourceid, repository, configurations, options) {
		
		jQuery.extend(this, options);
		
		this.id = id;
		this.sourceid = sourceid;
		this.repository = repository;
		this.configurations = configurations;
		
		if(!this.metadata) this._loadMetadata();
		else this._setMetadataToConfiguration(metadata);
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
	 * @private
	 * @function
	 * requests the server for metadata
	 */
	_loadMetadata: function() {
		
		if(!this.repository)
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
		
		this.request = null;
		this._setMetadataToConfiguration(indicatorMetadata);
		
	},
	
	/**
	 * @private
	 * @function
	 * 
	 * TO BE DEFINED...
	 */
	_onError: function(){
		
		this.request = null;
		//TODO: implement this...
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} metadata
	 * Sets metadata to configurations
	 */
	_setMetadataToConfiguration: function(metadata) {
		
		for (var i = 0, configuration; configuration = this.configurations[i]; i++) {
			
			configuration.setMetadata(metadata);
			
		}
	}
	
});
