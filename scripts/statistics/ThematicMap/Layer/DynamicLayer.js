

Statistics.ThematicMap.Layer.DynamicLayer = Statistics.Class(OpenLayers.Layer.WMS, {
	
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
	_init: function(serializer, endpointConfiguration, layerParams, options) {
		
		var extendedOptions = jQuery.extend({}, options, {
			buffer: 0,
	        displayOutsideMaxExtent: true,
	        isBaseLayer: false,
	        yx : {'EPSG:4326' : true},
		});
		
		var extendedParams = jQuery.extend({}, layerParams, {
			LAYERS: 'cite:StatisticsLayer',
            STYLES: 'statistics style',
            format: 'image/png',
            tiled: true,
			transparent: true
		});
		
		var bounds = new OpenLayers.Bounds(
                    -180, -90,
                    180, 90
                );
		
		OpenLayers.Layer.WMS.prototype.initialize.apply(this, 
			[
				this.LAYER_NAME,
				endpointConfiguration.getDynamicLayerURLs(),
				extendedParams,
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
			cql_filter: this._buildCQLFilter({
				sourceId: sourceid,
				indicatorId: indicatorid,
				filterdimensions: "'" + this.serializer.serializeDimensionsArray( filterDimensions ) + "'",
				projecteddimensions: "'" + this.serializer.serializeDimensionsArray( projectedDimensions ) + "'"				
			})
		});
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * @private
	 * @function
	 * @param {Object} obj
	 * @returns {String}
	 */
	_buildCQLFilter: function(obj) {
		
		var str = "";
		for(var key in obj) {
			str += key + "=" + obj[key] + " AND ";
		}
		
		return str.substring(0, str.length - 5);
	}
});
