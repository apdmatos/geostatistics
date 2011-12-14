
Statistics.Repository.StatisticsRepositoryImpl = Statistics.Class(Statistics.Repository, {

	/**
	 * @public
	 * @function
	 * @param {String} sourceId
	 * @param {String} indicatorId
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 */
	getIndicatorMetadata: function(sourceId, indicatorId, callbacks) {
		
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getMetadataEndpoint() + "?callback=?", 
			{
				sourceid: sourceId, 
				indicatorid: indicatorId
			}, 
			jQuery.proxy(function(data) {
				if(request.isCanceled()) return;
				var metadata = this.objectFactories.newIndicatorMetadata(data);
				callbacks.successCallback(metadata);
			}, this));
			
		request = new Statistics.Repository.Request(xhr);
		return request;
	},
	
	/**
	 * @public
	 * @function
	 * @param {String} sourceId
	 * @param {String} indicatorId
	 * @param {Object} axisDimension
	 * @param {Object} selectedDimensions
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 */
	getChartDataSerie: function(sourceId, indicatorId, axisDimension, selectedDimensions, callbacks) {
		
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getDataSerieEndpoint() + "?callback=?", 
			{
				sourceid: sourceId, 
				indicatorid: indicatorId,
				axisDimension: this.serializer.serializeDimension(axisDimension),
				selectedDimensions: this.serializer.serializeDimensionsArray(selectedDimensions)
			}, 
			jQuery.proxy(function(data) {
				if(request.isCanceled()) return;
				
				var dataSerie = this.objectFactories.newDataSerie(data);
				callbacks.successCallback(dataSerie);
				
			}, this));
			
		request = new Statistics.Repository.Request(xhr);
		return request;

	}
});