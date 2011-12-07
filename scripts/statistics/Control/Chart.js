


Statistics.Control.Chart = Statistics.Class(Statistics.Control, {
	
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
	 * @param {String} title
	 * @param {Object} plotOptions
	 */
	_init: function(div, title, plotOptions){
		Statistics.Control.prototype._init(this, arguments);
		
		this.plotOptions = 
			jQuery.extend(true, {
				title: this.title,
				seriesDefaults: {
					shadow: false,
					renderer: jQuery.jqplot.PieRenderer, 
		    		rendererOptions: { 
						padding: 2, 
						sliceMargin: 2, 
						showDataLabels: false 
					},
					legend: {
						show:true, 
						placement: 'outside',
						rendererOptions: {
		                      numberRows: 2
		                 },
						location: 'e'					
					}
				}
			}, plotOptions);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.ChartData} data
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
	
	_createPlot: function(data){
		
//		var data = [['Verwerkende FruedenStunde Companaziert Eine industrie', 9],
//							['Primaire producent', 7], ['Out of home', 6], 
//							['Groothandel', 5], ['Consument', 3],  
//							['Grondstof', 4], ['Retail', 8],
//							['Bewerkende industrie', 2]];
//				jQuery.jqplot.config.enablePlugins = true;
//				plot1 = jQuery.jqplot('chartdiv', 
//					[data], 
//					{
//						title: ' ', 
//						seriesDefaults: {
//				    		shadow: true, 
//				    		renderer: jQuery.jqplot.PieRenderer, 
//				    		rendererOptions: { padding: 2, sliceMargin: 2, showDataLabels: false } 
//				  		}, 
//						legend: { 
//							show:true, 
//							placement: 'outside',
//							rendererOptions: {
//		                          numberRows: 2
//		                     },
//							location: 'e' 
//						}
//					});
		
		return jQuery.jqplot(this.div, [this._convertChartData2Plot(data)], this.plotOptions);
	},
	
	_convertChartData2Plot: function(data){
		
		var converted = [];
		for(var i = 0, d; d = data[i]; i++)
			converted.push([data.label, data.value]);
		
		return converted;	
	}
	
});
