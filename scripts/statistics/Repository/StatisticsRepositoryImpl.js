
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
				sourceid: sourceid, 
				indicatorid: indicatorid
			}, 
			function(data) {
				if(request.isCanceled()) return;
				var metadata = this.objectFactories.newIndicatorMetadata(obj);
				callbacks.successCallback(metadata);
			});
			
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
				sourceid: sourceid, 
				indicatorid: indicatorid,
				axisDimension: this.serializer.serializeDimension(axisDimension),
				selectedDimensions: this.serializer.serializeDimensionsArray(selectedDimensions)
			}, 
			function(data) {
				if(request.isCanceled()) return;
				
				this.objectFactories.newChartData(currdata);
			});
			
		request = new Statistics.Repository.Request(xhr);
		return request;

	}
});