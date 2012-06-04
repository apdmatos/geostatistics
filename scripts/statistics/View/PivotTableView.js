

Statistics.View.PivotTableView = Statistics.Class(Statistics.View, {
	
	/**
	 * @private
	 * @property {Object<string, Statistics.View.PivotTableView.AxisHelper>}
	 * Contains an hashtable with dimension ids and Axis values, to draw the pivot table. 
	 */
	axis: null,
	
	/**
	 * @private
	 * @property {PivotTable}
	 */
	pivotTable: null,
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.DimensionConfig.PivotTableProjectionConfig} configuration
	 */
	setConfiguration: function(configuration){
		this.configuration = configuration;
		
		this.configuration.events.bind(
			'config::pivotConfigurationChanges', 
			jQuery.proxy(this.onPivotTableConfigurationChanges, this));
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * Sets the data to be represented
	 */
	setData: function(data){
		Statistics.View.prototype.setData(this, arguments);
		var axis = this._createAxis();
		var metric = new Metric("", Datatype.NUMBER);
		
		var vortex = new DataVortex(axis);
		vortex.metricList.push(metric);
		
		this._fillData(data, vortex, metric);
		
		var element = typeof(this.div) == 'string' ? this.div : $(this.div)[0]
		var display = this._getDisplayConfiguration();
		this.pivotTable = new PivotTable(
			"", 
			element, 
			vortex, 
			display[0],		// rows
			display[1]);	// columns
			
		this.pivotTable.display();
	},
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/

	/**
	 * @private
	 * @event handler
	 * @function
	 * Called when the pivot table configuration changes.
	 */
	onPivotTableConfigurationChanges: function(){
		if(!this.pivotTable) return;
		
		var display = this._getDisplayConfiguration();
		
								// rows		// columns
		this.pivotTable.display(display[0], display[1]);
	},
	
	/**
	 * Returns the configuration. 
	 * In the first array position, the rows and in the second the columns
	 * @private
	 * @function
	 * @returns {Axis[][]}
	 */
	_getDisplayConfiguration: function() {
		
		var rows = [],
			columns = [],
			i, d;
		
		for(i = 0, d; d = this.configuration.rows[i]; ++i)
			rows.push(this.axis[d.id].axis);
			
		for(i = 0, d; d = this.configuration.columns[i]; ++i)
			columns.push(this.axis[d.id].axis);
		
		return [rows, columns];
	},
	
	/**
	 * @private
	 * @function
	 * @returns {Axis[]}
	 * This function will create the axis to present on pivot table
	 */
	_createAxis: function() {
		var arr = [];
		this.axis = {};
		var dimensions = this.configuration.getSelectedDimensions(),
			axis;
		
		for (var i = 0, d; d = dimensions[i]; ++i) {
			axis = new Statistics.View.PivotTableView.AxisHelper(new Axis(d.name)); 
			this._fillAxis(axis, d);
			this.axis[d.id] = axis;
			arr.push(axis.axis);
		}
		
		return arr;
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.View.PivotTableView.AxisHelper} axisHelper
	 * @param {Statistics.Model.Dimension} dimension
	 * 
	 * Fills the axis with the dimension attributes
	 */
	_fillAxis: function(axisHelper, dimension) {

		for(var i = 0, attr; attr = dimension.attributes[i]; ++i) {
			axisHelper.buckets[attr.id] = axisHelper.axis.makeNewBucket(attr.name); 
		}
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data 
	 * @param {DataVortex} dataVortex
	 * @param {Metric} metric
	 * 
	 * Fills the data into datavortex
	 */
	_fillData: function(data, dataVortex, metric) {
		for(var i=0, value; value = data.values[i]; ++i)
			dataVortex.setValue(metric, value.value, this._getBuckets(value.projectedDimensions));
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.filter.DimensionFilter[]} dimensions
	 * Given a set of dimensions, will return the associated bucket
	 */
	_getBuckets: function(filters){
		var buckets = [],
			axis,
			bucket;
		for (var i = 0, f; f = filters[i]; ++i) {
			
			axis = this.axis[f.dimensionId];
			bucket = axis.buckets[f.attributeIds[0]];
			
			buckets.push(bucket);
		}
		
		return buckets;
	}
});




Statistics.View.PivotTableView.AxisHelper = Statistics.Class({
	
	/**
	 * @public
	 * @property {Axis}
	 */
	axis: null,
	
	/**
	 * @public
	 * @property {Object<string, AxisBucket>}
	 */
	buckets: null,
	
	_init: function(axis) {
		this.axis = axis;
		this.buckets = {};
	}	
});
