

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
	 * Contains the dimension to be setted on axis
	 */
	axis: null,
	
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
	setSeriesDimension: function(axisDimension, serieDimension) {
		
		this.axis = axisDimension ? axisDimension : this.axis;
		this.series = serieDimension;
		
		var projected = [axisDimension];
		if(serieDimension) projected.push( serieDimension );
		
		if (!this.contains(projected))
			this.setProjectedDimensions( projected );
		else this.events.trigger('config::seriesDimensionChanged', [this, axisDimension, serieDimension]);
		
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Statistic.Model.Dimension}
	 */
	getAxisDimension: function(){
		return this.axis;
	},
	
	/**
	 * returns the selected series dimension, if any.
	 * @public
	 * @function
	 * @returns {Statistics.Model.Dimension}
	 */
	getSeriesDimension: function(dimension){
		return this.series;
	},
	
/*****************************************************************************************
 * ***************************************************************************************
 * ********** Private methods
 * ***************************************************************************************
 * ***************************************************************************************
 */

	/**
	 * @override
	 * @protected
	 * @function
	 * selects the default dimensions. 
	 * For chart dimension, the selectedDimensions array, only contains one position.
	 */
	selectDefaultDimensions: function(silent){
		
		Statistics.Model.DimensionConfig.DimensionProjectionConfig.prototype.selectDefaultDimensions.apply(this, arguments);
		this.axis = this.getSelectedDimensions()[0];
	}	
});
