

Statistics.Serializer = Statistics.Class({
	
	/**
	 * Serializes a dimension to request the server
	 * @public
	 * @function
	 * @param {Dimension} dimension
	 * @returns {string} the serialized dimension
	 */
	serializeDimension: function(dimension){ 
		/*Must be implemented by each subclass*/
	},

	/**
	 * Serializes a dimension array to request the server
	 * @public
	 * @function
	 * @param {Dimension[]} dimension
	 * @returns {string} the serialized dimension array
	 */
	serializeDimensionsArray: function(dimension){ 
		/*Must be implemented by each subclass*/
	}	
});
