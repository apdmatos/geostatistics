


Statistics.Model.HierarchyAttribute = Statistics.Class(Statistics.Model.Attribute, {
	
	/**
	 * @public
	 * @property {Boolean} lazyLoad
	 * Indicates if the hierarchy should be lazy loaded.
	 */
	lazyLoad: false,
	
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
	_init: function(id, name, level, childAttributes, lazyLoad){
		Statistics.Model.Attribute.prototype._init.apply(this, [id, name, level]);
		this.childAttributes = childAttributes ? childAttributes : [];
		this.lazyLoad = !!lazyLoad;
	},
	
	/**
	 * Returns a new instance of Statistics.Model.Attribute
	 * @override
	 * @public
	 * @function
	 * @returns {Statistics.Model.Attribute}
	 */
	clone: function(){
		var childs = [];
		for(var i = 0, child; child = this.childAttributes[i]; ++i){
			childs.push(child.clone());
		}
		
		return new Statistics.Model.HierarchyAttribute(this.name, this.id, childs);
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
	 * @param {Statistics,Model.Attribute} attribute
	 * @param {Boolean} onlyRootAttributes
	 * 
	 */
	removeAttribute: function(attribute, onlyRootAttributes){
		
		this.childAttributes = jQuery.grep(this.childAttributes, function(attr) {
			
			if(!onlyRootAttributes && attr instanceof Statistics.Model.HierarchyAttribute)
				attr.removeAttribute(attribute);
			
			return attr.id != attribute.id;
      	});
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
Statistics.Model.HierarchyAttribute.FromObject = function(obj, level) {
	
	var childAttributes = [];
	
	if (obj.childAttributes) { 
		for (var i = 0, attribute; attribute = obj.childAttributes[i]; i++) {
			
			var attr = Statistics.Model.Attribute;
			if(attribute.childAttributes) attr = Statistics.Model.HierarchyAttribute;
			
			childAttributes.push(
				attr.FromObject(attribute, level + 1)
			);
		}
	}
	
	return new Statistics.Model.HierarchyAttribute(obj.id, obj.name, level, childAttributes, obj.lazyLoad);
	
};


