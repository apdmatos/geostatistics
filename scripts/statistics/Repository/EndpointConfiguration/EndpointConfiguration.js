

Statistics.Repository.EndpointConfiguration = {
	
	serviceURL: 'http://localhost:36590/Statistics.svc/',
	
	operations: {
		metadata: 'Metadata',
		dataSerie: 'DataSerie'
	},
	
	getMetadataEndpoint: function(){
		return this._getOperationURL('metadata');
	},
	
	getDataSerieEndpoint: function(){
		return this._getOperationURL('dataSerie');
	},
	
	_getOperationURL: function(op){
		return this.serviceURL + this.operations[op]
	}
	
};
