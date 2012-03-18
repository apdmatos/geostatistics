

Statistics.Model.Dimension = Statistics.Class({
	
	/**
	 * @public
	 * @property {String} id
	 * The dimension id to call the service
	 */
	id: null,
	
	/**
	 * @public
	 * @property {String} name 
	 * The dimensions name that should be displayed
	 */
	name: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.DimensionType} type
	 * The dimension type
	 */
	type: null,
	
	/**
	 * @public
	 * @property {Array<Statistics.Model.Attribute>} 
	 * Attributes the dimension attributes
	 */
	attributes: null,
	
	/**
	 * @public
	 * @property {String} serverContextData
	 * A string for storing server context data. 
	 * This data should be sent to the server when doing a request.
	 */
	serverContextData: null,
	
	/**
	 * @constructor
	 */
	_init: function(name, id, type, attributes){
		
		this.name = name;
		this.id = id;
		this.type = type;
		this.attributes = attributes ? attributes : [];
		
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics,Model.Attribute} attribute - The attribute to dimension 
	 */
	addAttribute: function(attribute){
		this.attributes.push(attribute);
	},
	
	/**
	 * @public
	 * @function
	 * @param {string} attributeId - the attributeid to return
	 * @returns {Statistics.Model.Attribute} returns the attribute with the id. 
	 * If the attributeid, does not exist, returns null
	 */
	getAttributeById: function(attributeId){
		
		for(var i = 0, attribute; attribute = this.attributes[i]; ++i) {
			
			if(attribute.id == attributeId)
				return attribute;
				
			if(attribute instanceof Statistics.Model.HierarchyAttribute)
			{
				var attr = attribute.getAttributeById(attributeId);
				if(attr) return attr;
			}
		}
			
		
		return null;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Boolean} cloneAttributes
	 * 
	 * Indicates if the attributes should be cloned too.
	 * 
	 * @returns {Statistics.Model.Dimension}
	 */
	clone: function(cloneAttributes) {
		
		var attributes = [];
		if(cloneAttributes){
			//TODO: Should be implemented
			throw "Not implemented yet!!!";
		}
		
		return new Statistics.Model.Dimension(this.name, this.id, this.type, attributes);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension - A dimension to copy properties from
	 * @param {Boolean} [copyAttributes] - optional. Default is false
	 */
	copy: function(dimension, copyAttributes) {
		
		this.id = dimension.id;
		this.name = dimension.name;
		this.type = dimension.type;
		
		if(copyAttributes) this.attributes = dimension.attributes;
	}
	
});

/**
 * @static
 * @public
 * @function
 * @param {Object} object
 * converts this object to a Dimension object
 */
Statistics.Model.Dimension.FromObject = function(obj){
	
	var attributes = [];
	
	if (obj.attributes) { 
		for (var i = 0, attribute; attribute = obj.attributes[i]; i++) {
			
			var attr = Statistics.Model.Attribute;
			if(attribute.childAttributes) attr = Statistics.Model.HierarchyAttribute;
			
			attributes.push(
				attr.FromObject(attribute)
			);
		}
	}
	
	
	var type = Statistics.Model.DimensionType[obj.type] ? 
					Statistics.Model.DimensionType[obj.type] : 
					Statistics.Model.DimensionType.Other;
	
	return new Statistics.Model.Dimension(obj.name, obj.id, obj.type, attributes); 
	
};


