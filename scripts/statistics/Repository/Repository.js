

Statistics.Repository = Statistics.Class({
	
	/**
	 * @protected
	 * @property {Statistics.Repository.EndpointConfiguration}
	 * This object contains a server configuration to perform requests
	 */
	config: null,
	
	/**
	 * @protected
	 * @property {Statistics.Serializer} 
	 * An object to serialize the selected dimensions
	 */
	serializer: null,
	
	/**
	 * @protected
	 * @function
	 * 
	 */
	objectFactories: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Repository.EndpointConfiguration} configuration
	 * @param {Statistics.Serializer} serializer - The serializer object to serialize the requests, for axis dimension and selected dimensions
	 * @param {Object} objectFactories - An object with the following keys
	 * 	- newDataSerie {Object}
	 *  - newIndicatorMetadata {Object}
	 */
	_init: function(configuration, serializer, objectFactories){
		this.config = configuration;
		this.serializer = serializer;
		this.objectFactories = objectFactories;
	},
	
	/**
	 * @public
	 * @function
	 * @param {String} sourceId
	 * @param {String} indicatorId
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 *  
	 * @returns {Statistics.Repository.Request}
	 */
	getIndicatorMetadata: function(sourceId, indicatorId, callbacks){
		/*should be implemented by each request specific implementation*/	
	},

	/**
	 * @public
	 * @function
	 * @param {String} sourceId
	 * @param {String} indicatorId
	 * @param {Statistics.Model.Dimension[]} filterDimensions
	 * @param {Statistics.Model.Dimension[]} projectedDimensions
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 *  
	 * @returns {Statistics.Repository.Request}
	 */
	getIndicatorValues: function(sourceId, indicatorId, filterDimensions, projectedDimensions, callbacks){
		/*should be implemented by each request specific implementation*/	
	}

});
