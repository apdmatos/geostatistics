
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
	 * @param {Statistics.Model.Dimension[]} filterDimensions
	 * @param {Statistics.Model.Dimension[]} projectedDimensions
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 *  
	 * @returns {Statistics.Repository.Request}
	 */
	getIndicatorValues: function(sourceId, indicatorId, filterDimensions, projectedDimensions, callbacks){
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getDataSerieEndpoint() + "?callback=?", 
			{
				sourceid: sourceId, 
				indicatorid: indicatorId,
				filterDimensions: this.serializer.serializeDimensionsArray(filterDimensions),
				projectedDimensions: this.serializer.serializeDimensionsArray(projectedDimensions)
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