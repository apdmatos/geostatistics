

Statistics.Serializer.DimensionSerializer = Statistics.Class(Statistics.Serializer, {
	
	/**
	 * Serializes a dimension to request the server
	 * @public
	 * @function
	 * @param {Dimension} dimension
	 * @returns {string} the serialized dimension
	 */
	serializeDimension: function(dimension){ 
		var str = dimension.id + ",";
		for(var i = 0, attr; attr = dimension.attributes[i]; ++i)
			str += attr + ",";
			
		return str.substring(0, str.length - 1);
	},

	/**
	 * Serializes a dimension array to request the server
	 * @public
	 * @function
	 * @param {Dimension[]} dimension
	 * @returns {string} the serialized dimension array
	 */
	serializeDimensionsArray: function(dimensions) { 
		
		var str = "";
		for(var i = 0, dimension; dimension = dimensions[i]; ++i)
			str += this.serializeDimension(dimension) + "#";
		
		return str.substring(0, str.length - 1);
	}	
});