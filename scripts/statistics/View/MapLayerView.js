

Statistics.View.MapLayerView = Statistics.Class(Statistics.View, {
	
	/**
	 * @public
	 * @property
	 * @param {OpenLayers.Map} map
	 */
	map: null,
	
	/**
	 * @public
	 * @property
	 * @param {Statistics.ThematicMap.Control.LabelControl} map 
	 */
	labelControl: null,
	
	/**
	 * @public
	 * @property
	 * @param {Statistics.ThematicMap.Layer.DynamicLayer} map
	 */
	dynamicLayer: null,
	
	/**
	 * @constructor
	 * @param {OpenLayers.Map} map
	 * @param {Statistics.ThematicMap.Layer.DynamicLayer} layer
	 * @param {Statistics.ThematicMap.Control.LabelControl} labelControl
	 */
	_init: function(map, layer, labelControl) {
		Statistics.View.prototype.setData(this, [map.div]);
		
		this.map = map;
		this.dynamicLayer = layer;
		this.labelControl = labelControl;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.DimensionConfig} configuration
	 */
	setConfiguration: function(configuration) {
		Statistics.View.prototype.setConfiguration.apply( this, arguments );
		this.configuration.events.bind(
			'config::colorChanges', 
			jQuery.proxy(this._updateColors, this));
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesRange} data
	 * Sets the data to be represented
	 */
	setData: function(data){
		// update labels
	},
	
	/**
	 * @public
	 * @function
	 * This method should be called to reload layer information
	 */
	updateLayer: function() {
		var metadata = this.configuration.getMetadata();
		this.dynamicLayer.setLayerParameters(
			metadata.sourceid, 
			metadata.id,
			this.configuration.getDimensionsFilterConfig().getSelectedDimensions(),
			this.configuration.getSelectedDimensions(),
			this.configuration.aggregationLevel,
			this.configuration.colors
		);
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * Updates thematic map colors and label colors
	 */
	_updateColors: function() {
		this.dynamicLayer.setColors( this.configuration.colors );
		this.labelControl.setColors( this.configuration.colors );
	}
	
}); 