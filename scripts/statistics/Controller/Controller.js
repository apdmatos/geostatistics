


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
	 * @property {Statistics.View}
	 * A control/view to represent this representation
	 */
	view: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.Configuration} configuration
	 * @param {Statistics.Repository} repository
	 * @param {Statistics.View} control - The view/control to represent this controller/representation
	 */
	_init: function(configuration, repository, view) {
		this.configuration = configuration;
		this.repository = repository;
		this.view = view
		
		this.view.setConfiguration(configuration);
		
		// Check if the configuration has the metadata
		if(this.configuration.getSelectedDimensions()) this.renderData();
		
		// Register some events to configuration
		this.configuration.events.bind (
				'config::filteredDimensionsChanged', 
				jQuery.proxy(this.onRenderData, this));
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
		
		var hasFilters = this.configuration.hasActiveFilters();

		if(hasFilters) this.view.setLoadingData();
		else this.view.setNoFilters();

		this.view.show();
		
		return hasFilters;
	}

});
