


Statistics.ConfigurationEditor.DimensionProjectorUpdater = Statistics.Class(
	Statistics.ConfigurationEditor.DimensionUpdater, 
{
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension[]}
	 */
	dimensions: null,

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
		if(this.dimensions) {
			this.configuration.setProjectedDimensions(this.dimensions);
			this.dimensions = null;			
		}
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * Discards the current modifications
	 * @returns {Boolean} returns true if there are anything to discard, false otherwise
	 */
	discardConfiguration: function() {
		if (this.dimensions) {
			this.dimensions = null;
			return true;
		}
		
		return false;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension[]} dimensions
	 */
	setProjectedDimensions: function(dimensions){
		this.dimensions = dimensions;
	}
});
