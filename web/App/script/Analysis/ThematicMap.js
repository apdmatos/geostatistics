

Statistics.App.Analysis.ThematicMap = Statistics.Class(Statistics.App.Analysis, {
	
	/**
	 * @public
	 * @property {OpenLayers.Map}
	 */
	map: null,
	

	/**
	 * @public
	 * @function
	 */	
	createWindow: function() {
		
		this.map = new OpenLayers.Map({
	        projection: new OpenLayers.Projection("EPSG:4326"),
	        numZoomLevels: 18,
	        controls: [
				new OpenLayers.Control.Navigation(
                    {mouseWheelOptions: {interval: 100}}
                ),
	            new OpenLayers.Control.TouchNavigation({
	                dragPanOptions: {
	                    enableKinetic: true
	                }
	            }),
	            new OpenLayers.Control.Zoom()
	        ],
	        layers: [
	            new OpenLayers.Layer.OSM("OpenStreetMap", null, {
	                transitionEffect: 'resize'
	            })
	        ]
	    });
		Statistics.App.Analysis.prototype.createWindow.apply(this, arguments);
		this.map.render(this.dialog[0]);
		this.map.setCenter(new OpenLayers.LonLat(-814637.11903987, 4806398.337903), 7);
	},
	
	/**
	 * @protected
	 * @abstract
	 * @returns {JQueryElement}
	 */
	getDialogHtml: function() {
		return $("<div class='map'></div>");
	},	

	/**
	 * Overrides default dialog options
	 * @protected
	 * @abstract
	 * @returns {Object}
	 */
	getDialogOptions: function() { 
		return { width: 500, height: 600, minWidth: 300, minHeight: 300 };
	},

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @param {Statistics.View} view
	 * @returns {Statistics.Controller}
	 */
	createController: function(config, view) {
		return new Statistics.Controller.ThematicMapController(
			config,
			this.repository,
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
		return new Statistics.View.MapLayerView(
			this.map, 
			new Statistics.ThematicMap.Layer.DynamicLayer(
				new Statistics.ThematicMap.DimensionsSerializer(),
				Statistics.Repository.EndpointConfiguration
			),
			new Statistics.ThematicMap.Control.LabelControl(
				new Statistics.ThematicMap.IntervalsCalculator.LinearIntervalsCalculator()
			)
		);
	},

	/**
	 * @protected
	 * @abstract
	 * @returns {Statistics.Model.DimensionConfig}
	 */	
	createConfiguration: function() { 
		var dimensionSelector = new Statistics.ThematicMap.DimensionsSelector(); 
		var config = new Statistics.Model.DimensionConfig.ThematicMapProjectionConfig(
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
			new Statistics.ConfigurationEditor.ThematicMapConfigEditor(
				config, 
				new Statistics.ConfigurationEditor.ThematicMapAggregationLevelUpdater(config)
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
		return ["Dimensoes", "Nível de agregação"];
	}
	
	
});