


Statistics.ConfigurationEditor.SerieDimensionUpdater = Statistics.Class(
	Statistics.ConfigurationEditor.DimensionProjectorUpdater, 
{
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension}
	 */
	serieDimension: null,
	
	/**
	 * A flag indicating if the configuration should be updated or not
	 * @private
	 * @property {Boolean} 
	 */
	update: false,

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
		if (this.update) {
			var axis = this.dimensions ? this.dimensions[0] : this.configuration.getAxisDimension();
			this.configuration.setSeriesDimension(axis, this.serieDimension);
			this.serieDimension = null;
			this.dimensions = null;
			this.update = false;
		}else {
			Statistics.ConfigurationEditor.DimensionProjectorUpdater.prototype.applyConfiguration.apply(this, arguments);
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
		Statistics.ConfigurationEditor.DimensionProjectorUpdater.prototype.discardConfiguration.apply(this, arguments);
		if (this.serieDimension) {
			this.serieDimension = null;
			return true;
		}
		
		return false;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 */
	setSerieDimension: function(dimension){
		this.serieDimension = dimension;
		this.update = true;
	}
});
