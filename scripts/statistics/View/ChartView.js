


Statistics.View.ChartView = Statistics.Class(Statistics.View, {
	
	/**
	 * @private
	 * @property {jQuery.jqplot}
	 * An object representing the plot instance
	 */
	plot: null,
	
	/**
	 * @private
	 * @property {Object}
	 * An object with options to jqplot
	 */
	plotOptions: null,
	
	/**
	 * @constructor 
	 * @param {jQueryElement} div
	 * @param {Object} [plotOptions]
	 */
	_init: function(div, plotOptions){
		Statistics.View.prototype._init.apply(this, [div]);
		
		this.plotOptions = plotOptions;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * Sets the data to be represented
	 */
	setData: function(data){
		
		if(this.plot) this.plot.destroy();
		this.plot = this._createPlot(data);
	},

/**********************************************************************************
 * ********************************************************************************
 * Abstract
 * Protected methods
 **********************************************************************************
 **********************************************************************************/

	/**
	 * @protected
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * 	The data to display on chart
	 */
	_createPlot: function(data){
		this.plotOptions.series = this._getChartSeries(); 		
		return jQuery.jqplot(this.div, this._convertChartData2Plot(data), this.plotOptions);
	},
	
	/**
	 * Returns the selected data series, if any
	 * @protected
	 * @return String[]
	 */
	_getChartSeries: function(){
		//should be redifined in each class
		return null;
	},
	
	/**
	 * @abstract
	 * @protected
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 */
	_convertChartData2Plot: function(data) {
		//should be redifined in each class
		return null;
	}
	
});
