

Statistics.ConfigurationEditor.ThematicMapAggregationLevelUpdater = Statistics.Class(
	Statistics.ConfigurationEditor.DimensionUpdater, 
{
	/**
	 * @private
	 * @property {Statistics.Model.AggregationLevel}
	 */
	aggregationLevel: null,

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
		if(this.aggregationLevel) {
			this.configuration.selectedAggregationLevel(this.aggregationLevel);
			
			this.aggregationLevel = null;		
		}
	},
	
	/**
	 * @override
	 * @public
	 * @function
	 * Discards the current modifications
	 */
	discardConfiguration: function(){
		if (this.aggregationLevel) {
			this.aggregationLevel = null;
			return true;
		}
		
		return false;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.AggregationLevel} aggregationLevel
	 */
	setAggregationLevel: function(aggregationLevel){
		this.aggregationLevel = aggregationLevel;
	}
	
});



