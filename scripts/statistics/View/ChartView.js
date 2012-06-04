


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
		Statistics.View.prototype.setData.apply(this, arguments);
		
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
		return undefined;
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
	},
	
	/**
	 * Given a value returns its chart model representation
	 * @protected
	 * @function
	 * @param {Statistics.Model.Value.IndicatorValue} value
	 */
	_convertIndicatorValue: function(value) {

		var axisDimension = value.projectedDimensions[0];
		var dimension = this.configuration.getDimensionById(axisDimension.dimensionId);
		var attribute = dimension.getAttributeById(axisDimension.attributeIds[0]);
	
		return [attribute.name, value.value];
	}
	
});
