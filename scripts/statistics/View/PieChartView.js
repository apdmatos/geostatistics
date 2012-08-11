
Statistics.View.PieChartView = Statistics.Class(Statistics.View.ChartView, {
	
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
					placement: 'outside',
//					rendererOptions: {
//                          numberRows: 5
//                     },
					location: 'e' 
				}
			}, plotOptions);
		
		Statistics.View.ChartView.prototype._init.apply(this, [div, opts]);
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
			converted.push( this._convertIndicatorValue(seriesValue) );
		}
		
		return [converted];
	}

});