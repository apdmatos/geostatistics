

Statistics.Repository.EndpointConfiguration = {
	
	proxy: {
		
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
			valuesRange: 'GetIndicatorRange',
			attributes: 'Attributes'
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
	},
	
	management: {
		
		/**
		 * @public
		 * @property {String}
		 * Contains the service endpoint for indicator management
		 */
		serviceURL: 'http://localhost:30355/services/StatisticsManagementService.svc/rest/',
		
		/**
		 * @public
		 * @property {Object}
		 * 
		 * Contains the operation names 
		 */
		operations: {
			indicators: 'indicator/all',
			providers: 'provider/all'
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
		
	},
	
	/**
	 * @public
	 * @function
	 * @returns {String[]} returns 
	 */
	getIndicatorsEndpoint: function() {
		return this.management._getOperationURL('indicators');
	},

	/**
	 * @public
	 * @function
	 * @returns {String[]} returns 
	 */
	getProvidersEndpoint: function() {
		return this.management._getOperationURL('providers');
	},
	
	/**
	 * @public
	 * @function
	 * @returns {String[]} returns 
	 */
	getDynamicLayerURLs: function() {
		return this.proxy.dynamicLayersURL;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {String} returns the metadata endpoint to call.
	 */
	getMetadataEndpoint: function(){
		return this.proxy._getOperationURL('metadata');
	},
	
	/**
	 * @public 
	 * @function
	 * @returns {String} returns the endpoint to give dataserie.
	 */
	getValuesEndpoint: function(){
		return this.proxy._getOperationURL('values');
	},
	
	/**
	 * @public 
	 * @function
	 * @returns {String} returns the endpoint to give dataserie.
	 */
	getValuesRangeEndpoint: function(){
		return this.proxy._getOperationURL('valuesRange');
	},
	
	/**
	 * @public
	 * @function
	 * @returns {String} returns the endpoint to give dimension attributes
	 */
	getLazyLoadAttributesEndpoint: function() {
		return this.proxy._getOperationURL('attributes');
	}
	
};
