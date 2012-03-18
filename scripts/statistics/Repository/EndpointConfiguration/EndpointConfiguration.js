

Statistics.Repository.EndpointConfiguration = {
	
	/**
	 * @public
	 * @property {String}
	 * Contains the server endpoint
	 */
	serviceURL: 'http://localhost:36590/Statistics.svc/',
	
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
		dataSerie: 'DataSerie'
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
	getDataSerieEndpoint: function(){
		return this._getOperationURL('dataSerie');
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
