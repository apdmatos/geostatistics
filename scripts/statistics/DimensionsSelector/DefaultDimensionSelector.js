
//TODO: this class should be changed to select the server hints
//			selectedByDefault
//			projectedByDefault

Statistics.DimensionSelector.DefaultDimensionSelector = Statistics.Class(Statistics.DimensionSelector, {
	
	/**
	 * @private
	 * @property {Object<Statistics.Model.DimensionType, Statistics.DimensionSelector.Position>}
	 * Contains the default positioning for dimensions in pivot table
	 */
	defaultPositioning: null,
		
	/**
	 * @private
	 * @property {Statistics.Model.IndicatorMetadata}
	 * Contains the original metadata
	 */
	metadata: null,

	/**
	 * @constructor
	 * @param {Statistics.Model.DimensionType[]} rows
	 * @param {Statistics.Model.DimensionType[]} columns
	 */
	_init: function(positioning) {
		
		this.defaultPositioning = jQuery.extend( 
			{
				Geographic: Statistics.DimensionSelector.Position.Rows,
				Temporal: Statistics.DimensionSelector.Position.Columns,
				Other: Statistics.DimensionSelector.Position.Columns
			}, positioning);
	},
	
	/**
	 * @public
	 * @function
	 * 
	 * @param {Statistics.Model.IndicatorMetadata} metadata
	 */
	setMetadata: function(metadata) { 
		if(this.metadata && 
			this.metadata.id == metadata.id && this.metadata.sourceid == metadata.sourceid)
		{
			return;
		}
		
		this.metadata = metadata;
	},

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimensions
	 */
	filterDimensions: function(dimensions) {
		for(var i = 0, d; d = dimensions[i]; ++i)
		{
			var attrs = [];
			var attributes = this.metadata.getDimensionById(d.id).attributes;
			
			this.flatHierarchyAttributes(arr, attributes);
			d.addAttributes(attrs);
		}
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 * 
	 * @returns Statistics.Model.Dimension[]
	 *  returns the selected dimension
	 */
	getProjectedDimensions: function(dimensions) {

		return [dimensions[0], dimensions[1]];
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 * @returns {Statistics.DimensionSelector.Position} - Indicating the default position for dimension
	 */
	getProjectionDimensionPosition: function(dimension){
		
		return this.defaultPositioning[dimension.type];
		
	},
	
/***********************************
 * Private methods
 */
	
	/**
	 * Copies attributes from Dimensions metadata, to a flat array.
	 * 
	 * @private
	 * @function
	 * @param {Statistics.Model.Attribute[]} arr - The result array
	 * @param {Statistics.Model.Attribute[]} attributes - The attributes to copy
	 */
	flatHierarchyAttributes: function(arr, attributes) {
		
		if(!attributes) return;
		
		for(var i = 0, attr; attr = attributes[i]; ++i) {
			
			arr.push(attr);
			if(attr instanceof Statistics.Model.HierarchyAttribute) 
				this.getHierarchyAttributesChilds(arr, attr.childAttributes);
				
		}
	}
	
});
