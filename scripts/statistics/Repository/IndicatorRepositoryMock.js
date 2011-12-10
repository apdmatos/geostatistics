
Statistics.Repository.IndicatorRepositoryMock = Statistics.Class(Statistics.Repository, {
	
//	_init: function(configuration, objectFactories) {
//		Statistics.Repository.prototype._init.apply(this, arguments);
//	},
	
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
	 * @param {Object} axisDimensions
	 * @param {Object} selectedDimensions
	 * @param {Object} callbacks
	 * 	- successCallback {Function}
	 *  - failCallback {Function}
	 */
	getChartDataSerie: function(sourceId, indicatorId, axisDimensions, selectedDimensions, callbacks) {
		
		var request = new Statistics.Repository.Request(
			{
				abort: function() { }
			});
		
		window.setTimeout(jQuery.proxy(function(){
			
			if(request.isCanceled()) return;
			
			var data = [
				{
					value: 10,
					label: 'label 1'
				},
				{
					value: 15,
					label: 'label 2'
				},
				{
					value: 5,
					label: 'label 3'
				},
				{
					value: 20,
					label: 'label 4'
				},
				{
					value: 22,
					label: 'label 5'
				},
				{
					value: 2,
					label: 'label 6'
				},
				{
					value: 7,
					label: 'label 7'
				},
			];
			
			for(var i = 0, currdata; currdata = data[i]; i++){
				data[i] = this.objectFactories.newChartData(currdata);
			}
			
			callbacks.successCallback(data);
			
		}, this), 1000);
		
		return request;
	}
});