


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
		
		this.plotOptions = 
			jQuery.extend(true, {
				title: this.title, 
				seriesDefaults: {
		    		shadow: true, 
		    		renderer: jQuery.jqplot.PieRenderer, 
		    		rendererOptions: { 
						padding: 0, 
						sliceMargin: 0, 
						showDataLabels: true 
					} 
		  		}, 
				legend: { 
					show:true, 
					placement: 'outside',
					rendererOptions: {
                          numberRows: 5
                     },
					location: 'e' 
				}
			}, plotOptions);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * Sets the data to be represented
	 */
	setData: function(data){
		
		if(!this.plot) this.plot = this._createPlot(data);
		else {
			
			var data = this._convertChartData2Plot(data);
			this.plot.series[0].data = data;
			this.plot.redraw();
		}
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/

	/**
	 * @private
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * 	The data to display on chart
	 */
	_createPlot: function(data){

		return jQuery.jqplot(this.div, [this._convertChartData2Plot(data)], this.plotOptions);
	},
	
	/**
	 * @private
	 * @function
	 * @param {Statistics.Model.RepresentationData.DataSerie} data
	 */
	_convertChartData2Plot: function(data) {

//		var converted = [];
//		for(var i = 0, seriesValue; seriesValue = data.values[i]; ++i) {
//			
//			var axisDimension = seriesValue.axisDimension;
//			var dimension = this.metadata.getDimensionById(axisDimension.dimensionId);	
//			var attribute = dimension.getAttributeById(axisDimension.attributeIds[0]);
//			
//			converted.push([attribute.name, seriesValue.value]);
//		}
//		
//		return converted;



		var converted = [];
		for (var i = 0, seriesValue; seriesValue = data.values[i]; ++i) {
		
			var axisDimension = seriesValue.projectedDimensions[0];
			var dimension = this.configuration.getDimensionById(axisDimension.dimensionId);
			var attribute = dimension.getAttributeById(axisDimension.attributeIds[0]);
		
			converted.push([attribute.name, seriesValue.value]);
		}
		
		return converted;
	}
	
});
