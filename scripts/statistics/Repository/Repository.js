

Statistics.Repository = Statistics.Class({
	
	/**
	 * @protected
	 * @property ...
	 * This object contains a server configuration to perform requests
	 */
	config: null,
	
	/**
	 * @protected
	 * @function
	 * 
	 */
	objectFactories: null,
	
	/**
	 * @constructor
	 * @param {Object} configuration
	 * @param {Statistics.Serializer} serializer - The serializer object to serialize the requests, for axis dimension and selected dimensions
	 * @param {Object} objectFactories - An object with the following keys
	 * 	- newChartData {Object}
	 *  - newIndicatorMetadata {Object}
	 */
	_init: function(configuration, serializer, objectFactories){
		this.config = configuration;
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
	 * @param {Object} selectedDimensions
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 *  
	 * @returns {Statistics.Repository.Request}
	 */
	getChartDataSerie: function(sourceId, indicatorId, axisDimensions, selectedDimensions, callbacks){
		/*should be implemented by each request specific implementation*/	
	}
});
