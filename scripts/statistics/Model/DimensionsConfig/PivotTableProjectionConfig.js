

Statistics.Model.DimensionConfig.PivotTableProjectionConfig = 
	Statistics.Class(Statistics.Model.DimensionConfig.DimensionProjectionConfig, {
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::pivotConfigurationChanges'],
	
	/**
	 * @public
	 * @property {Statistics.Model.Dimension[]}
	 * Contains the dimensions to be displayed on rows
	 */
	rows: null,

	/**
	 * @public
	 * @property {Statistics.Model.Dimension[]}
	 * Contains the dimensions to be displayed on columns
	 */	
	columns: null,

	/**
	 * @override
	 * @protected
	 * @function
	 * selects the default dimensions. 
	 * For chart dimension, the selectedDimensions array, only contains one position.
	 */
	selectDefaultDimensions: function() { 
		
		var base =Statistics.Model.DimensionConfig.DimensionProjectionConfig; 
		base.prototype.selectDefaultDimensions.apply(this, [true]);
		
		this.rows = [];
		this.columns = [];
		
		for(var i = 0, d; d=this.dimensions[i]; ++i){
			var position = 
				this.dimensionSelector.getProjectionDimensionPosition(d);
				
			if(position === Statistics.DimensionSelector.Position.Rows) this.rows.push(d);
			else this.columns.push(d);
		}
		
		this.events.trigger('config::projectedDimensionsChanged', [this.dimensions]);
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.Dimensions[]} rows
	 * @param {Statistics.Model.Dimensions[]} columns
	 * 
	 * Configures the dimensions to be displayed on columns and on rows
	 */
	setDisplay: function(rows, columns){ 
	
		this.rows = rows;
		this.columns = columns;
	
		var projectedDimensions = rows.concat(columns);
		if(projectedDimensions.length != this.dimensions.length || !this.contains(projectedDimensions))
			this.setProjectedDimensions(projectedDimensions);
		else
			this.events.trigger('config::pivotConfigurationChanges', [this]);
	}
});
