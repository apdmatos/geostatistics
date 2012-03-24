


Statistics.Model.IndicatorMetadata = Statistics.Class(Statistics.Model.Attribute, {
	
	/**
	 * @public
	 * @property {string} id
	 * The indicator id to call the service
	 */
	id: null,
	
	/**
	 * @public
	 * @property {string} sourceid
	 * The indicator source id
	 */
	sourceid: null,
	
	/**
	 * @public
	 * @property {string} sourceName
	 * The source that provides this data
	 */
	sourceName: null,
	
	/**
	 * @public
	 * @property {string} sourceURL
	 * The source URL to see the indicator displayed in an official site
	 */
	sourceURL: null,
	
	/**
	 * @public 
	 * @property {string} name
	 * The indicator name
	 */
	name: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.Dimension[]}
	 * The indicator availlable dimensions
	 */
	dimensions: null,
	
	/**
	 * @constructor
	 * @param {string} id - Indicator id
	 * @param {string} name - Indicator name
	 * @param {Object} options - This object contains some optional parameters. Has the following format:
	 * 	- sourceURL {string}
	 *  - sourceName {string} 
	 */
	_init: function(id, sourceid, name, dimensions, options){
		jQuery.extend(this, options);
		
		this.id = id;
		this.sourceid = sourceid;
		this.name = name;
		this.dimensions = dimensions ? dimensions : [];
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension - The dimension to add to this indicator
	 */
	addDimension: function(dimension){
		this.dimensions.push(dimension);
	},
	
	/**
	 * @public
	 * @function
	 * @param {string} dimensionId - A dimension id key
	 * 
	 * @returns {Dimension} if the dimensionid does not exist, returns null
	 */
	getDimensionById: function(dimensionId){
		
		for(var i = 0, dimension; dimension = this.dimensions[i]; ++i)
			if(dimension.id == dimensionId) 
				return dimension;
			
		return null;
	}
	
});

/**
 * @static
 * @public
 * @function
 * @param {Object} object
 * converts this object to a IndicatorMetadata object
 */
Statistics.Model.IndicatorMetadata.FromObject = function(obj){

	var dimensions = [];
	
	if (obj.dimensions) { 
		for (var i = 0, dimension; dimension = obj.dimensions[i]; i++) 
			dimensions.push(
				Statistics.Model.Dimension.FromObject(dimension)
			);
	}
	
	return new Statistics.Model.IndicatorMetadata(
		obj.id, 
		obj.sourceid,
		obj.name, 
		dimensions, 
		{
			sourceURL: obj.sourceURL,
			sourceName: obj.sourceName
		}); 
};


