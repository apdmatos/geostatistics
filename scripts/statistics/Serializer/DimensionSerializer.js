

Statistics.Serializer.DimensionSerializer = Statistics.Class(Statistics.Serializer, {
	
	/**
	 * Serializes a dimension to request the server
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 * @returns {string} the serialized dimension
	 */
	serializeDimension: function(dimension){ 
		
		if(dimension.attributes.length == 0) return "";
		
		var str = dimension.id + ",";
		for(var i = 0, attr; attr = dimension.attributes[i]; ++i)
			str += attr.id + ",";
			
		return str.substring(0, str.length - 1);
	},

	/**
	 * Serializes a dimension array to request the server
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimension
	 * @returns {string} the serialized dimension array
	 */
	serializeDimensionsArray: function(dimensions) { 
		
		var str = "";
		for (var i = 0, dimension; dimension = dimensions[i]; ++i) {
			var serializedDimension = this.serializeDimension(dimension);
			if(serializedDimension)	str += serializedDimension + "#";
		}
		
		return str.substring(0, str.length - 1);
	}
});