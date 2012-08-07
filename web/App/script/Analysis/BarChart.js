

Statistics.App.Analysis.BarChart = Statistics.Class(Statistics.App.Analysis, {
	
	
	
	/**
	 * Overrides default dialog options
	 * @protected
	 * @abstract
	 * @returns {Object}
	 */
	getDialogOptions: function() { 
		return { width: 600, height: 500, minWidth: 300, minHeight: 300 };
	},

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @param {Statistics.View} view
	 * @returns {Statistics.Controller}
	 */
	createController: function(config, view) {
		return new Statistics.Controller.ProjectionController (
			config,
			Statistics.App.repository,
			view
		);
	},

	/**
	 * @protected
	 * @abstract
	 * @param {JQueryElement} element
	 * @returns {Statistics.View}
	 */	
	createView: function(element) {
		if(!element.attr('id')) {
			var id = Math.floor(Math.random()*11);
			element.attr('id', id)
		}
		return new Statistics.View.BarChartView(element.attr('id'))
	},

	/**
	 * @protected
	 * @abstract
	 * @returns {Statistics.Model.DimensionConfig}
	 */	
	createConfiguration: function() {
		var dimensionSelector = new Statistics.DimensionSelector.DefaultDimensionSelector();
		var config = new Statistics.Model.DimensionConfig.ChartSeriesConfig (
			dimensionSelector,
			new Statistics.Model.DimensionConfig.DimensionFilterConfig(dimensionSelector)
		);				
		return config;
	},

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @returns {Statistics.ConfigurationEditor}
	 */		
	createEditors: function(config) { 
		return [
			new Statistics.ConfigurationEditor.DimensionsConfigEditor(
				config, 
				new Statistics.ConfigurationEditor.DimensionFilterUpdater(config), 
				$.proxy(this.getLazyLoader, this)
			),
			new Statistics.ConfigurationEditor.SeriesConfigEditor(
				config, 
				new Statistics.ConfigurationEditor.SerieDimensionUpdater(config)
			)
		];
	},
	
	/**
	 * @protected
	 * @function
	 * @abstract
	 * @returns {String[]}
	 */
	getEditorsTabNames: function() { 
		return ["Dimensoes", "Projetar"];
	}
	
	
});
