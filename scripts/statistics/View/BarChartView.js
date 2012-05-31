

Statistics.View.ChartView = Statistics.Class(Statistics.ChartView, {
	
	/**
	 * @constructor 
	 * @param {jQueryElement} div
	 * @param {Object} [plotOptions]
	 */
	_init: function(div, plotOptions){
		
		var opts =  
			jQuery.extend(true, {
	            seriesDefaults:{
	                renderer:$.jqplot.BarRenderer,
	                pointLabels: { show: true }
	            },
	            axes: {
	                xaxis: {
	                    renderer: $.jqplot.CategoryAxisRenderer
	                }
	            },
            	highlighter: { show: false }
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
	 * Returns the selected data series, if any
	 * @protected
	 * @return String[]
	 */
	_getChartSeries: function(){
		var seriesRet = [];
		
		var serie = this.configuration.getSeriesDimension();
		if(!serie) return null;
		
		for(var i= 0, attribute; attribute = serie.attributes[i]; ++i)
			seriesRet.push( {label: attribute} );
				
		return seriesRet;

	},

	/**
	 * @protected
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * @returns Object[][] containing the series to display
	 */
	_convertChartData2Plot: function(data) {

		var seriesObj = {};

		for (var i = 0, value; value = data.values[i]; ++i) {

			var axisDimension = value.projectedDimensions[0];
			var dimension = this.configuration.getDimensionById(axisDimension.dimensionId);
			var attribute = dimension.getAttributeById(axisDimension.attributeIds[0]);
			
			var currSerie = this._getSerieAttribute(value);
			seriesObj[currSerie].push( [attribute.name, value.value] );
		}
		
		var series = this.configuration.getSeriesDimension();
		var arr = [];
		if(series){
			for(var j = 0, attr; attr = series.attributes[j]; ++j)
				arr.push ( seriesObj[attr.id] )
		}else 
			arr = Statistics.Object.toArray(seriesObj);
		
		return arr;
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * Returns the serie attribute for this value
	 * @private
	 * @function 
	 * @param {Statistics.Model.Values.IndicatorValue} value
	 * @returns {String}
	 */
	_getSerieAttribute: function(value){
		
		var serie = this.configuration.getSeriesDimension();
		for(var i = 0, attr; attr = serie.attributes[i]; ++i)
			if(value.containsAttributeId(serie.id, attr.id)) 
				return attr.id;
		
		return 'default';
	}
});