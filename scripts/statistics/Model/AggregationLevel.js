


Statistics.Model.AggregationLevel = Statistics.Class({
	
	/**
	 * Property that contains attribute id
	 * @public
	 * @property {String} id
	 */
	id: null,

	/**
	 * Property that contains attribute name
	 * @public
	 * @property {String} id
	 */
	name: null,

	/**
	 * Property that contains attribute level
	 * @public
	 * @property {Integer} id
	 */	
	level: null,
	
	/**
	 * @constructor
	 * @param {String} id
	 * @param {String} name
	 * @param {Integer} level
	 */
	_init: function(id, name, level) {
		this.id = id;
		this.name = name;
		this.level = level;
	}
	
});

/**
 * @static
 * @public
 * @function
 * @param {Object} object
 * converts this object to an AttributeConfiguration object
 */
Statistics.Model.AggregationLevel.FromObject = function(obj) {
	
	return new Statistics.Model.AggregationLevel(obj.id, obj.name, obj.level);
	
};






