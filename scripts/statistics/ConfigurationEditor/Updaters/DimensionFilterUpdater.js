


Statistics.ConfigurationEditor.DimensionFilterUpdater = Statistics.Class(
	Statistics.ConfigurationEditor.DimensionUpdater, 
{
	/**
	 * @private
	 * @property {Object<string, Object<string, Dimension.Model.Attribute>>}
	 * Dimension attributes to add to configuration
	 */
	addDimensionAttributes: null,
	
	/**
	 * @private
	 * @property {Object<string, Object<string, Dimension.Model.Attribute>>}
	 * Dimension attributes to add to configuration
	 */
	removeDimensionAttributes: null,
	
	/**
	 * @constructor
	 */
	_init: function(config){
		Statistics.ConfigurationEditor.DimensionUpdater.prototype._init.apply(this, arguments);
		this.addDimensionAttributes = {};
		this.removeDimensionAttributes = {};
	},

	/**
	 * @override
	 * @public
	 * @function
	 * @returns {Boolean} returns true if it auto updates the information, on configuration.
	 * False if it is needed to call apply/discard methods
	 */
	autoUpdater: function(){
		return false;
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * Applies the modifications, to the configuration
	 */
	applyConfiguration: function() {
		
		if ( $.isEmptyObject(this.addDimensionAttributes) && 
			 $.isEmptyObject(this.removeDimensionAttributes) ) return;
		
		this.processAttributes(
			this.addDimensionAttributes, 
			function(dimension, attr) { 
				dimension.addAttribute(attr);
			});
		
		this.processAttributes(
			this.removeDimensionAttributes, 
			function(dimension, attr) { 
				dimension.removeAttribute(attr, true);
			});
		
		this.addDimensionAttributes = {};
		this.removeDimensionAttributes = {};
		
		this.configuration.filteredDimensionsChanged();
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * Discards the current modifications
	 * @returns {Boolean} returns true if there are anything to discard, false otherwise
	 */
	discardConfiguration: function(){
		
		if ( $.isEmptyObject(this.addDimensionAttributes) && 
			 $.isEmptyObject(this.removeDimensionAttributes) ) return false;
		
		this.addDimensionAttributes = {};
		this.removeDimensionAttributes = {};
		return true;
	},
	
	/**
	 * Adds the attribute to dimension configuration
	 * @public
	 * function
	 * @param {String} dimensionId
	 * @param {Statistics.Model.Attribute} attribute
	 */
	addAttribute: function(dimensionId, attribute){
		if(this.removeDimensionAttributes[dimensionId] && this.removeDimensionAttributes[dimensionId][attribute.id]){
			delete this.removeDimensionAttributes[dimensionId][attribute.id];
		}else{
			
			if(!this.addDimensionAttributes[dimensionId]) this.addDimensionAttributes[dimensionId] = {};
			if(!this.addDimensionAttributes[dimensionId][attribute.id]) 
				this.addDimensionAttributes[dimensionId][attribute.id] = attribute;
		}
	},

	/**
	 * Removes the attribute from dimension configuration
	 * @public
	 * function
	 * @param {String} dimensionId
	 * @param {Statistics.Model.Attribute} attribute
	 */	
	removeAttribute: function(dimensionId, attribute){
		if(this.addDimensionAttributes[dimensionId] && this.addDimensionAttributes[dimensionId][attribute.id]){
			delete this.addDimensionAttributes[dimensionId][attribute.id];
		}else{
			
			if(!this.removeDimensionAttributes[dimensionId]) this.removeDimensionAttributes[dimensionId] = {};
			if(!this.removeDimensionAttributes[dimensionId][attribute.id]) 
				this.removeDimensionAttributes[dimensionId][attribute.id] = attribute;
		}
	},
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * @private
	 * @function
	 * @param {Object<string, Object<string, Dimension.Model.Attribute>>} attributeCollection
	 * @param {Function(Dimension.Model.Dimension, Dimension.Model.Attribute)} func
	 */
	processAttributes: function(attributeCollection, func){
		
		for (var dimensionId in attributeCollection) {
			var dimension = this.configuration.getDimensionById(dimensionId);
			for (var attr in attributeCollection[dimensionId]) 
				func(dimension, attributeCollection[dimensionId][attr]);
		}
		
	}

	
});
