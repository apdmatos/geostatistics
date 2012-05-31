

Statistics.Object = {
	
	/**
	 * Converts the object into an array
	 * @public
	 * @function
	 * @param {Object} obj
	 * @returns {Object[]}
	 */
	toArray: function(obj) {
		
		var arr = [];
		for(var p in obj) arr.push( obj[p] );
			
		return arr;
	}
	
};
