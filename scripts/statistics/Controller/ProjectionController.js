

Statistics.Controller.ProjectionController = Statistics.Class(Statistics.Controller, {
	
	/**
	 * @private
	 * @property {Statistics.Repository.Request}
	 * Represents the request in progress
	 */
	requestObj: null,
	
	/**
	 * abstract method. Renders the control and requests for data
	 * @protected
	 * @function
	 * @retutns {Boolean} returns true, if there's filters to request data. False otherwise
	 */
	onRenderData: function() {

		var hasData = Statistics.Controller.prototype.onRenderData.apply(this, arguments);
		if(!hasData) return false;
		
		if(this.requestObj) this.requestObj.cancelRequest();
		
		var metadata = this.configuration.getMetadata();
		this.requestObj = 
			this.repository.getIndicatorValues(
				metadata.sourceid, 
				metadata.id, 
				this.configuration.getDimensionsFilterConfig().getSelectedDimensions(),
				this.configuration.getSelectedDimensions(),
				{
					successCallback: jQuery.proxy(this._complete, this),
					errorCallback: jQuery.proxy(this._error, this)
				}
			);
			
		return true;
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.ServerData.DataSerie} data
	 * Callback function. Called when the server responds with chart data
	 */
	_complete: function(data){
		
		this.view.setData(data);
	},
	
	/**
	 * @private
	 * @function
	 * 
	 * MUST BE IMPLEMENTED...
	 */
	_fail: function(){
		/*TODO: Do something... Cannot get data from the server*/
		alert('Ups... Erro!');
	}	
	
	
});