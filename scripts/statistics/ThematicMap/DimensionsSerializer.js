

Statistics.Map.DimensionsSerializer = Statistics.Class(Statistics.Serializer.DimensionSerializer, {
	
	/**
	 * @private
	 * @property {Statistics.Model.AggregationLevel}
	 */
	_aggregationLevel: null,
	
	/**
	 * @public
	 * @function 
	 * @param {Statistics.Model.AggregationLevel} aggregationLevel
	 */
	setAggregationLevel: function(aggregationLevel) {
		this.aggregationLevel = aggregationLevel;
	},
	
	/**
	 * Serializes a dimension to request the server
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 * @returns {string} the serialized dimension
	 */
	serializeDimension: function(dimension){ 
		
		if(dimension.type == Statistics.Model.DimensionType.Geographic)
			return this._serializeGeographicDimension( dimension );
		
		return Statistics.Serializer.DimensionSerializer.prototype.serializeDimension.apply( this, arguments );
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 * @returns {string} the serialized geographic dimension
	 */
	_serializeGeographicDimension: function(dimension) {
		return dimension.id + "-" + this.aggregationLevel.id;
	}
});
