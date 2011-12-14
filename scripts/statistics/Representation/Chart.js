


Statistics.Representation.Chart = Statistics.Class(Statistics.Representation, {
	
	/**
	 * @private
	 * @property {Statistics.Repository.Request}
	 * Represents the request in progress
	 */
	requestObj: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.ChartConfig} configuration
	 * @param {Statistics.Repository} repository
	 * @param {Statistics.Control} control - The view/control to represent this controller/representation
	 */
	_init: function(configuration, repository, control) {
		Statistics.Representation.prototype._init.apply(
			this, 
			[ 
			  	configuration, 
			  	repository, 
			  	control
			 ]);
	},
	
	/**
	 * @protected
	 * @function
	 * abstract method. Renders the control and requests for data
	 */
	renderData: function() {
		Statistics.Representation.prototype.renderData.apply(this, arguments);
		if(this.requestObj) this.requestObj.cancelRequest();
		
		var metadata = this.configuration.getMetadata();
		
		this.requestObj = 
			this.repository.getChartDataSerie(
				metadata.sourceid, 
				metadata.id, 
				this.configuration.getSelectedDimensions()[0],
				this.configuration.getDimensionsConfig().getSelectedDimensions(),
				{
					successCallback: jQuery.proxy(this._complete, this),
					errorCallback: jQuery.proxy(this._error, this)
				}
			);
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.ServerData.DataSerie} data
	 * Callback function. Called when the server responds with chart data
	 */
	_complete: function(data){
		
//		// complete information
//		var axisDimension = this.configuration.getSelectedDimensions()[0];
//		
//		for(var i = 0, value; value = data.values[i]; ++i) {
//			
//			// copy values to axisDimension
//			this._completeDimensionInfo(axisDimension, value.axisDimension);
//			
//			// copy values to selected dimensions
//			for(var j = 0, selected; selected = value.selectedDimensions[j]; ++j)
//				this._completeDimensionInfo(
//					this.configuration.metadata.getDimensionById(selected.id),
//					dimension
//				);
//		}
		
		
		this.control.setData(data);
		this.control.show();
	},
	
	/**
	 * @private
	 * @function
	 * 
	 * MUST BE IMPLEMENTED...
	 */
	_fail: function(){
		/*Do something... Cannot get data from the server*/
		alert('Ups... Erro!');
	},
	
//	/**
//	 * @private
//	 * @function
//	 * @param {Statistics.Model.Dimension} originalDimension
//	 * @param {Statistics.Model.Dimension} dimension
//	 */
//	_completeDimensionInfo: function(originalDimension, dimension) {
//		
//		dimension.copy(originalDimension);
//		var axisAttr = dimension.attributes[0];
//		axisAttr.copy(axisDimension.getAttributeById(axisAttr.id));
//	}
	
});
