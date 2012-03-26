
Statistics.Repository.IndicatorRepositoryMock = Statistics.Class(Statistics.Repository, {
	
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
		
		
		var request = new Statistics.Repository.Request(
			{
				abort: function() { }
			});
		
		window.setTimeout(jQuery.proxy(function() {
			
			if(request.isCanceled()) return;
			
			var obj = {
				id: '1',
				sourceid: '1',
				sourceName: 'Fake statistics Consortium',
				sourceURL: 'http://nowhere.com',
				name: 'Fake indicator',
				dimensions: [
					{
						id: '1',
						name: 'Ano',
						type: Statistics.Model.DimensionType.Temporal,
						attributes: [ 
							{
								id: '1',
								name: '2010'
							},
							{
								id: '2',
								name: '2011'
							}
						]
					},
					{
						id: '2',
						name: 'Ano',
						type: Statistics.Model.DimensionType.Geographic,
						attributes: [ 
							{
								id: '1',
								name: 'Distrito',
								childAttributes: [
									{
										id: '1',
										name: 'Lisboa'
									},
									{
										id: '2',
										name: 'Porto'
									},
									{
										id: '2',
										name: 'Setubal'
									}
								]
							},
							{
								id: '2',
								name: 'Concelhos',
								childAttributes: []
							}
						]
					}
				]
			};
			
			var metadata = this.objectFactories.newIndicatorMetadata(obj);
			callbacks.successCallback(metadata);
			
		}, this), 1000);
		
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
		//TODO: definir objecto mock
		return null;
	}


});