
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
			this.config.getValuesEndpoint() + "?callback=?", 
			{
				sourceid: sourceId, 
				indicatorid: indicatorId,
				filterDimensions: this.serializer.serializeDimensionsArray(filterDimensions),
				projectedDimensions: this.serializer.serializeDimensionsArray(projectedDimensions)
			}, 
			jQuery.proxy(function(data) {
				if(request.isCanceled()) return;
				
				var dataSerie = this.objectFactories.newIndicatorValuesResult(data);
				callbacks.successCallback(dataSerie);
				
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
	 * @param {String} shapeAggregationLevel
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 *  
	 * @returns {Statistics.Repository.Request}
	 */
	getIndicatorValuesRange: function(sourceId, indicatorId, filterDimensions, projectedDimensions, shapeAggregationLevel, callbacks) {
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getValuesRangeEndpoint() + "?callback=?", 
			{
				sourceid: sourceId, 
				indicatorid: indicatorId,
				filterDimensions: this.serializer.serializeDimensionsArray(filterDimensions),
				projectedDimensions: this.serializer.serializeDimensionsArray(projectedDimensions),
				shapeLevel: shapeAggregationLevel
			}, 
			jQuery.proxy(function(data) {
				if(request.isCanceled()) return;
				
				var dataSerie = this.objectFactories.newIndicatorValuesRange(data);
				callbacks.successCallback(dataSerie);
				
			}, this));
			
		request = new Statistics.Repository.Request(xhr);
		return request;
	},
	
	/**
	 * @public
	 * @function
	 * @param {String} sourceId
	 * @param {String} indicatorId
	 * @param {String} dimensionId
	 * @param {String} parentId
	 * @param {Integer} level
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 */
	getDimensionAttributes: function(sourceId, indicatorId, dimensionId, parentId, level, callbacks) {
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getLazyLoadAttributesEndpoint() + "?callback=?", 
			{
				sourceid: sourceId, 
				indicatorid: indicatorId,
				dimensionid: dimensionId,
				attributeRootid: parentId,
				level: level
			}, 
			jQuery.proxy(function(data) {
				
				var ret = [];
				for (var i = 0, attr; attr = data[i]; ++i)
					ret.push( this.objectFactories.newAttribute(attr, level) );
				
				callbacks.successCallback(ret);
				
			}, this));
			
		request = new Statistics.Repository.Request(xhr);
		return request;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Integer} pageNumber
	 * @param {Integer} recordsPerPage
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 */
	getProviders: function(pageNumber, recordsPerPage, callbacks) {
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getProvidersEndpoint() + "?callback=?", 
			{
				pageNumber: pageNumber, 
				recordsPerPage: recordsPerPage
			}, 
			jQuery.proxy(function(data) {
				
				var result = this.objectFactories.newSearchResult(data, this.objectFactories.newProvider);
				callbacks.successCallback(result);
				
			}, this));
			
		request = new Statistics.Repository.Request(xhr);
		return request;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Integer} providerid	 
	 * @param {Integer} pageNumber
	 * @param {Integer} recordsPerPage
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 */	
	getIndicators: function(providerid, pageNumber, recordsPerPage, callbacks) {
		var request = null;
		
		//TODO: register and call the fail callback!
		var xhr = jQuery.getJSON(
			this.config.getIndicatorsEndpoint() + "?callback=?", 
			{
				providerid: providerid, 
				pageNumber: pageNumber,
				recordsPerPage: recordsPerPage
			}, 
			jQuery.proxy(function(data) {
				
				var result = this.objectFactories.newSearchResult(data, this.objectFactories.newIndicator);
				callbacks.successCallback(result);
				
			}, this));
			
		request = new Statistics.Repository.Request(xhr);
		return request;
	}	

});