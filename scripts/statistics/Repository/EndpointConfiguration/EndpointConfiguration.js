

Statistics.Repository.EndpointConfiguration = {
	
	/**
	 * @public 
	 * @property {String[]}
	 * Contains all layer urls
	 */
	dynamicLayersURL: [
		'http://localhost:8080/geoserver/cite/wms'
	],
	
	/**
	 * @public
	 * @property {String}
	 * Contains the server endpoint
	 */
	serviceURL: 'http://localhost:30355/services/RestService.svc/',
	
	/**
	 * @public
	 * @property {Object}
	 * 	 - metadata {String}
	 * 	 - dataSerie {String}
	 * 
	 * Contains the operation names 
	 */
	operations: {
		metadata: 'Metadata',
		values: 'GetIndicatorValues',
		valuesRange: 'GetIndicatorRange'
	},
	
	/**
	 * @public
	 * @function
	 * @returns {String[]} returns 
	 */
	getDynamicLayerURLs: function() {
		return this.dynamicLayersURL;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {String} returns the metadata endpoint to call.
	 */
	getMetadataEndpoint: function(){
		return this._getOperationURL('metadata');
	},
	
	/**
	 * @public 
	 * @function
	 * @returns {String} returns the endpoint to give dataserie.
	 */
	getValuesEndpoint: function(){
		return this._getOperationURL('values');
	},
	
	/**
	 * @public 
	 * @function
	 * @returns {String} returns the endpoint to give dataserie.
	 */
	getValuesRangeEndpoint: function(){
		return this._getOperationURL('valuesRange');
	},	
	
	/**
	 * @private
	 * @function
	 * @param {String} op - The operation key in the operations property.
	 * 
	 * @returns {String} builds and returns the url to call
	 */
	_getOperationURL: function(op){
		return this.serviceURL + this.operations[op]
	}
	
};
