

Statistics.App.Analysis.PivotTable = Statistics.Class(Statistics.App.Analysis, {
	

	
	/**
	 * Overrides default dialog options
	 * @protected
	 * @abstract
	 * @returns {Object}
	 */
	getDialogOptions: function() { 
		return { width: '300', height: '300', minWidth: 300, minHeight: 300 };
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
		return new Statistics.View.PivotTableView(element.attr('id'))
	},

	/**
	 * @protected
	 * @abstract
	 * @returns {Statistics.Model.DimensionConfig}
	 */	
	createConfiguration: function() { 
		var dimensionSelector = new Statistics.DimensionSelector.DefaultDimensionSelector();
		var config = new Statistics.Model.DimensionConfig.PivotTableProjectionConfig (
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
			new Statistics.ConfigurationEditor.PivotTableConfigEditor(
				config, 
				new Statistics.ConfigurationEditor.PivotTableProjectorUpdater(config)
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
		return ["Dimensoes", "Formato da tabela"];
	}

});