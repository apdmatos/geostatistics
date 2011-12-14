


Statistics.Model.HierarchyAttribute = Statistics.Class(Statistics.Model.Attribute, {
	
	/**
	 * @public
	 * @property {Statistics.Model.Attribute} childAttributes
	 * The hierarchy attributes
	 */
	childAttributes: null,
	
	/**
	 * @constructor
	 * @param {String} id
	 * @param {String} name
	 * @param {Array<Statistics.Model.Attribute>} childAttributes
	 */
	_init: function(id, name, childAttributes){
		Statistics.Model.Attribute.prototype._init.apply(this, id, name);
		this.childAttributes = childAttributes ? childAttributes : [];
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Attribute} attribute
	 */
	addAttribute: function(attribute){
		this.childAttributes = attribute;
	},
	
	/**
	 * @public
	 * @function
	 * @param {string} attributeId - the attributeid to return
	 * @returns {Statistics.Model.Attribute} returns the attribute with the id. 
	 * If the attributeid, does not exist, returns null
	 */
	getAttributeById: function(attributeId){
		
		for(var i = 0, attribute; attribute = this.childAttributes[i]; ++i) {
			
			if(attribute.id = attributeId)
				return attribute;
				
			if(attribute instanceof Statistics.Model.HierarchyAttribute)
			{
				var attr = attribute.getAttributeById(attributeId);
				if(attr) return attr;
			}
		}
		
		return null;
	},
});


/**
 * @static
 * @public
 * @function
 * @param {Object} obj
 * converts this object to a Dimension object
 */
Statistics.Model.HierarchyAttribute.FromObject = function(obj) {
	
	var childAttributes = [];
	
	if (obj.childAttributes) { 
		for (var i = 0, attribute; attribute = obj.childAttributes[i]; i++) {
			
			var attr = Statistics.Model.Attribute;
			if(attribute.childAttributes) attr = Statistics.Model.HierarchyAttribute;
			
			childAttributes.push(
				attr.FromObject(attribute)
			);
		}
	}
	
	return new Statistics.Model.Attribute(obj.id, obj.name, childAttributes);
	
};


