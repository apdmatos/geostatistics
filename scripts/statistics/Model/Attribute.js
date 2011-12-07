


Statistics.Model.Attribute = Statistics.Class({
	
	/**
	 * @public
	 * @property {String} id
	 * The attributeId to call the service
	 */
	id: null,
	
	/**
	 * @public
	 * @property {String} name 
	 * The Attributte name to be displayed
	 */
	name: null,
	
	/**
	 * @constructor
	 * @param {String} name - The attribute name
	 */
	_init: function(name, id){
		this.name = name;
		this.id = id;
	}
	
});

/**
 * @static
 * @public
 * @function
 * @param {Object} obj
 * converts this object to a Dimension object
 */
Statistics.Model.Attribute.FromObject = function(obj) {
	
	return new Statistics.Model.Attribute(obj.id, obj.name);
	
};

