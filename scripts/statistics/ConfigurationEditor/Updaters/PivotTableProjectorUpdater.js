


Statistics.ConfigurationEditor.PivotTableProjectorUpdater = Statistics.Class(
	Statistics.ConfigurationEditor.DimensionUpdater, 
{
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension[]}
	 */
	rows: null,
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension[]}
	 */	
	columns: null,

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
		if(this.rows || this.columns) {
			this.configuration.setDisplay(this.rows, this.columns);
			
			this.rows = null;
			this.columns = null;		
		}
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * Discards the current modifications
	 */
	discardConfiguration: function(){
		if (this.rows || this.columns) {
			this.rows = null;
			this.columns = null;
			return true;
		}
		
		return false;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 */
	projectDimensions: function(rows, columns){
		this.rows = rows;
		this.columns = columns;
	}
});
