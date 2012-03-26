


Statistics.Controller = Statistics.Class({
	
	/**
	 * @protected
	 * @property {Statistics.Repository}
	 * Contains a repository inplementation to request for statistic data
	 */
	repository: null,
	
	/**
	 * @protected
	 * @property {Statistics.Model.Configuration}
	 */
	configuration: null,
	
	/**
	 * @protected
	 * @property {Statistics.Control}
	 * A control/view to represent this representation
	 */
	control: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.Configuration} configuration
	 * @param {Statistics.Repository} repository
	 * @param {Statistics.Control} control - The view/control to represent this controller/representation
	 */
	_init: function(configuration, repository, control) {
		this.configuration = configuration;
		this.repository = repository;
		this.control = control
		
		// Check if the configuration has the metadata
		if(this.configuration.getSelectedDimensions()) this.renderData();
		
		// Register some events to configuration
		this.configuration.events.bind (
				'config::dimensionsSelected', 
				jQuery.proxy(this.renderData, this));
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistics.Model.Configuration}
	 */
	getConfiguration: function() {
		return this.configuration;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} metadata 
	 */
	setMetadata: function(metadata) {
		this.configuration.setMetadata(metadata);
	},
	
	/**
	 * @protected
	 * @function
	 * abstract method. Renders the control and requests for data
	 */
	renderData: function() {
		this.control.setMetadata(this.configuration.getMetadata());
		this.control.setLoadingData();
		
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
	}
	
	
});