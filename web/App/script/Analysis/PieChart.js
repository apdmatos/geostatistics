

Statistics.App.Analysis.PieChart = Statistics.Class(Statistics.App.Analysis, {
	
	
	
	
	/**
	 * Overrides default dialog options
	 * @protected
	 * @abstract
	 * @returns {Object}
	 */
	getDialogOptions: function() { 
		return { width: 400, height: 500, minWidth: 300, minHeight: 300 };
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
			var id = Statistics.Util.createUniqueID();
			element.attr('id', id)
		}
		return new Statistics.View.PieChartView(element.attr('id'))
	},

	/**
	 * @protected
	 * @abstract
	 * @returns {Statistics.Model.DimensionConfig}
	 */	
	createConfiguration: function() { 
		var dimensionSelector = new Statistics.DimensionSelector.DefaultDimensionSelector();
		var config = new Statistics.Model.DimensionConfig.DimensionProjectionConfig (
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
			new Statistics.ConfigurationEditor.ChartConfigEditor(
				config, 
				new Statistics.ConfigurationEditor.DimensionProjectorUpdater(config)
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