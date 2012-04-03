
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
	 * @public
	 * @property {Boolean}
	 * The server will set this to true, if this attribute will be selected by default
	 */
	selectedByDefault: false,
	
	/**
	 * @constructor
	 * @param {String} name - The attribute name
	 */
	_init: function(name, id, selectedByDefault){
		this.name = name;
		this.id = id;
		this.selectedByDefault = selectedByDefault;
	},
	
	/**
	 * Copies properties from the given attribute
	 * @public
	 * @function
	 * @param {Statistics.Model.Attribute} attribute - An attribute to copy properties from
	 */
	copy: function(attribute) {
		this.id = attribute.id;
		this.name = attribute.name;
	},
	
	/**
	 * Returns a new instance of Statistics.Model.Attribute
	 * @public
	 * @function
	 * @returns {Statistics.Model.Attribute}
	 */
	clone: function(){
		return new Statistics.Model.Attribute(this.id, this.name, this.selectedByDefault);
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
	
	return new Statistics.Model.Attribute(obj.id, obj.name, obj.selectedByDefault);
	
};

