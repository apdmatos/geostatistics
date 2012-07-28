

Statistics.Map.Layer.DynamicLayer = Statistics.Class(OpenLayers.Layer.WMS, {
	
	/**
	 * @static
	 * @public
	 * @property {String}
	 * Contains the layer name to represent
	 */
	LAYER_NAME: 'dynamicLayer',
	
	/**
	 * @private
	 * @property {Statistics.Map.DimensionsSerializer}
	 */
	serializer: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Serializer} serializer
	 * @param {Statistics.Repository.EndpointConfiguration} configuration
	 * @param {Object} options - layer options
	 */
	_init: function(serializer, endpointConfiguration, options) {
		
		var extendedOptions = jQuery.extend({}, options, {
			yx : {'EPSG:4326' : true}
		});
		OpenLayers.Layer.WMS.prototype.initialize.apply(this, 
			[
				this.LAYER_NAME,
				endpointConfiguration.getDynamicLayerURLs(),
				{
					LAYERS: 'cite:StatisticsLayer',
					format: 'image/png',
					styles: 'statistics style' 
				},
				extendedOptions
			]);
			
		this.serializer = serializer;
	},
	
	/**
	 * @public
	 * @param {String[]} colors
	 */
	setColors: function(colors) {
		// must be implemented!!
	},
	
	/**
	 * @public
	 * @function
	 * @param {Integer} sourceid
	 * @param {Integer} indicatorid
	 * @param {Statistics.Model.Dimension[]} filterDimensions
	 * @param {Statistics.Model.Dimension[]} projectedDimensions
	 */
	setLayerParameters: function(sourceid, indicatorid, filterDimensions, projectedDimensions, aggregationLevel, colors) {
		
		this.serializer.setAggregationLevel(aggregationLevel);
		this.mergeNewParams({
			sourceId: sourceid,
			indicatorId: indicatorid,
			filterdimensions: "'" + this.serializer.serializeDimensionsArray( filterDimensions ) + "'",
			projecteddimensions: "'" + this.serializer.serializeDimensionsArray( projectedDimensions ) + "'"
		});
	}
});
