


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
				jQuery.proxy(this.onRenderData, this));
				
		this.configuration.events.bind (
				'config::settedMetadata', 
				jQuery.proxy(this.onMetadata, this));
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
	 * abstract method. Renders the control and requests for data
	 * @protected
	 * @function
	 * @retutns {Boolean} returns true, if there's filters to request data. False otherwise
	 */
	onRenderData: function() {
		
		var hasFilters = this.configuration.hasFilters();

		if(hasFilters) this.control.setLoadingData();
		else this.control.setNoFilters();

		this.control.show();
		
		return hasFilters;
	},

	/**
	 * @protected
	 * @function
	 * abstract method. Called when metadata is available.
	 */	
	onMetadata: function(){
		this.control.setMetadata(this.configuration.getMetadata());
	}
});
