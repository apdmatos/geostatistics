


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
	}
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


