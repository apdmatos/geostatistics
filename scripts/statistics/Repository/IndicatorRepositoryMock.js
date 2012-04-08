
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
						name: 'Geografia',
						type: Statistics.Model.DimensionType.Geographic,
						attributes: [ 
							{
								id: 'PT',
								name: 'Portugal',
								childAttributes: [
									{
										id: '1',
										name: 'Lisboa',
										childAttributes: [
											{
												id: '11',
												name: 'Loures'
											}
										]
									},
									{
										id: '2',
										name: 'Porto'
									},
									{
										id: '3',
										name: 'Setubal'
									}
								]
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
		var request = new Statistics.Repository.Request(
			{
				abort: function() { }
			});
			
		window.setTimeout(jQuery.proxy(function() {
			
			if(request.isCanceled()) return;
			
			var obj = {
				location: null,
				values: [
					{
						value: 1,
						projectedDimensions: [
							{
								dimensionId: 1,
								attributes: [1]
							}
						],
						filteredDimensions: [
							{
								dimensionId: 2,
								attributes: ['PT']
							}
						]
					},
					{
						value: 2,
						projectedDimensions: [
							{
								dimensionId: 1,
								attributes: [2]
							}
						],
						filteredDimensions: [
							{
								dimensionId: 2,
								attributes: ['PT']
							}
						]
					}					
				]
			};
			
			var metadata = this.objectFactories.newIndicatorValuesResult(obj);
			callbacks.successCallback(metadata);
			
		}, this), 1000);
		
		return request;
	}


});