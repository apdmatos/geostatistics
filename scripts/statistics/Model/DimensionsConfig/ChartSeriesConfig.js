

Statistics.Model.DimensionConfig.ChartSeriesConfig = 
	Statistics.Class(Statistics.Model.DimensionConfig.DimensionProjectionConfig, {
	
	/**
	 * @constant
	 * @property {String[]}
	 * Describes the supported event types
	 */
	EVENT_TYPES: ['config::seriesDimensionChanged'],
	
	/**
	 * @private
	 * @property {Statistics.Model.Dimension}
	 * Contains the selected series for chart
	 */
	series: null,
	
	/**
	 * Selected the current series dimension
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 */
	setSeriesDimension: function(dimension) {
		if (this.series != dimension) {
			this.series = dimension;
			this.events.trigger('config::seriesDimensionChanged', [this, dimension]);
		}
	},
	
	/**
	 * returns the selected series dimension, if any.
	 * @public
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 * @returns Statistics.Model.Dimension
	 */
	getSeriesDimension: function(dimension){
		return this.series;
	}
});
