
Statistics.View.PieChartView = Statistics.Class(Statistics.ChartView, {
	
	/**
	 * @constructor 
	 * @param {jQueryElement} div
	 * @param {Object} [plotOptions]
	 */
	_init: function(div, plotOptions){
		
		var opts = 
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
					placement: 'inside',
					rendererOptions: {
                          numberRows: 5
                     },
					location: 's' 
				}
			}, plotOptions);
		
		Statistics.ChartView.prototype._init.apply(this, [div, opts]);
	},

/**********************************************************************************
 * ********************************************************************************
 * Abstract
 * Protected methods
 **********************************************************************************
 **********************************************************************************/

	/**
	 * @protected
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 */
	_convertChartData2Plot: function(data) {
		var converted = [];
		for (var i = 0, seriesValue; seriesValue = data.values[i]; ++i) {
		
			var axisDimension = seriesValue.projectedDimensions[0];
			var dimension = this.configuration.getDimensionById(axisDimension.dimensionId);
			var attribute = dimension.getAttributeById(axisDimension.attributeIds[0]);
		
			converted.push([attribute.name, seriesValue.value]);
		}
		
		return [converted];
	}

});