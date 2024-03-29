

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
	 * @property {String} nameAbbr
	 * The dimensions name abbreviated
	 */
	nameAbbr: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.DimensionType} type
	 * The dimension type
	 */
	type: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.Attribute[]} 
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
	 * @public
	 * @property {Boolean}
	 * The server indicates if this dimension should be projected by default
	 */
	projectedByDefault: false,
	
	/**
	 * @public
	 * @property {Statistics.Model.AggregationLevel[]}
	 */
	aggregationLevels: null, 
	//attributeConfiguration: null,
	
	/**
	 * @constructor
	 */
	_init: function(name, nameAbbr, id, type, attributes, aggregationLevels){
		
		this.name = name;
		this.nameAbbr = nameAbbr;
		this.id = id;
		this.type = type;
		this.attributes = attributes ? attributes : [];
		this.aggregationLevels = aggregationLevels;
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
	 * @param {Statistics,Model.Attribute} attribute
	 * @param {Boolean} onlyRootAttributes
	 * 
	 */
	removeAttribute: function(attribute, onlyRootAttributes){
		
		this.attributes = jQuery.grep(this.attributes, function(attr) {
			
			if(!onlyRootAttributes && attr instanceof Statistics.Model.HierarchyAttribute)
				attr.removeAttribute(attribute);
			
			return attr.id != attribute.id;
      	});
	},	

	/**
	 * Adds a set of attributes
	 * 
	 * @public
	 * @function
	 * @param {Statistics,Model.Attribute[]} attributes 
	 */
	addAttributes: function(attributes){
		for(var i = 0, attr; attr = attributes[i]; ++i)
			this.addAttribute(attr);
	},
	
	/**
	 * @public
	 * @function
	 * @param {string} attributeId - the attributeid to return
	 * @param {Boolean} onlyRootAttributes
	 * @returns {Statistics.Model.Attribute} returns the attribute with the id. 
	 * If the attributeid, does not exist, returns null
	 */
	getAttributeById: function(attributeId, onlyRootAtributes){
		
		for(var i = 0, attribute; attribute = this.attributes[i]; ++i) {
			
			if(attribute.id == attributeId)
				return attribute;
				
			if(!onlyRootAtributes && attribute instanceof Statistics.Model.HierarchyAttribute)
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
	 * @param {String} id
	 * @returns {Statistics.Model.AggregationLevel}
	 * returns an attribute configuration, with the given id, if any
	 */
	getAggregationLevelById: function(id) {
		
		if(this.aggregationLevels) {
			for (var i = 0, aggregationLevel; aggregationLevel = this.aggregationLevels[i]; ++i) {
				if(aggregationLevel.id == id)
					return aggregationLevel;
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
			for(var i = 0, attr; attr = this.attributs[i]; ++i) {
				attributes.push(attr.clone());
			}
		}
		
		return new Statistics.Model.Dimension(
			this.name, 
			this.nameAbbr, 
			this.id, 
			this.type, 
			attributes, 
			this.aggregationLevels);
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
		this.nameAbbr = dimension.nameAbbr;
		this.type = dimension.type;
		this.attributeConfiguration = dimension.aggregationLevels;
		
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
			if(attribute.childAttributes || attribute.lazyLoad) attr = Statistics.Model.HierarchyAttribute;
			
			attributes.push(
				attr.FromObject(attribute, 1)
			);
		}
	}
	
	
	var type = Statistics.Model.DimensionType[obj.type] ? 
					Statistics.Model.DimensionType[obj.type] : 
					Statistics.Model.DimensionType.Other;
	
	var aggregationLevels = [];
	if(obj.aggregationLevels) {
		for (var i = 0, level; level = obj.aggregationLevels[i]; ++i) {
			aggregationLevels.push( Statistics.Model.AggregationLevel.FromObject(level) );
		}
	}
	
	return new Statistics.Model.Dimension(
			obj.name, obj.nameAbbr, obj.id, obj.type, 
			attributes, aggregationLevels); 
	
};


