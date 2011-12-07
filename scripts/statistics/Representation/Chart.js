


Statistics.Representation.Chart = Statistics.Class(Statistics.Representation, {
	
	/**
	 * @private
	 * @property {Statistics.Repository.Request}
	 * Represents the request in progress
	 */
	requestObj: null,
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension}
	 * The selected dimension to present on axis
	 */
	axisDimension: null,
	
	/**
	 * @private
	 * @property {Statistics.DimensionSelector}
	 * The dimension selector to extract the default selected axis
	 */
	dimensionSelector: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Repository} indicatorMetadata
	 * @param {Statistics.Repository} repository
	 * @param {Array<Statistics.Model.Dimension>} selectedDimensions
	 * @param {Array<Statistics.Model.Dimension>} axisDimension
	 * @param {Statistics.Control} control - The view/control to represent this controller/representation
	 */
	_init: function(indicatorMetadata, repository, selectedDimensions, axisDimension, control) {
		Statistics.Representation.prototype._init.apply(
			this, 
			[ 
			  	indicatorMetadata, 
			  	repository, 
			  	selectedDimensions, 
			  	axisDimension, 
			  	control
			 ]);
		this.axisDimension = axisDimension;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statuistics.Model.Dimension} axisDimension
	 * 
	 * Sets the dimension to be present on axis
	 */
	setSelectedAxisDimension: function(axisDimension){
		this.axisDimension = axisDimension;
		if(this.dimensions) this.renderData();
	},
	
	/**
	 * @protected
	 * @function
	 * abstract method. Renders the control and requests for data
	 */
	renderData: function() {
		Statistics.Representation.prototype.renderData.apply(this, arguments);
		if(this.requestObj) this.requestObj.cancelRequest();
		
		this.requestObj = 
			this.repository.getChartDataSerie(
				this.indicatorMetadata.sourceid, 
				this.indicatorMetadata.id, 
				this.axisDimension, 
				this.selectedDimensions,
				{
					successCallback: jQuery.proxy(this._complete, this),
					errorCallback: jQuery.proxy(this._error, this)
				}
			);
	},
	
	/**
	 * @private
	 * @function
	 * @param {Array<Statistics.Model.ChartValue>} data
	 * Callback function. Called when the server responds with chart data
	 */
	_complete: function(data){
		
		this.control.setData(data);
		this.show();
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
	}
	
});
