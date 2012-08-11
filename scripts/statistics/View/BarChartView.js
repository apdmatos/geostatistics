

Statistics.View.BarChartView = Statistics.Class(Statistics.View.ChartView, {
	
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
            	highlighter: { show: false },
        	}, plotOptions);
		
		Statistics.View.ChartView.prototype._init.apply(this, [div, opts]);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.DimensionConfig.PivotTableProjectionConfig} configuration
	 */
	setConfiguration: function(configuration){
		Statistics.View.ChartView.prototype.setConfiguration.apply(this, arguments);
		
		this.configuration.events.bind(
			'config::seriesDimensionChanged', 
			jQuery.proxy(function(){
				if(this.currentData)
					this.setData(this.currentData);
			}, this));
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
	_getChartSeries: function() {
		var seriesRet = [];
		
		var serie;
		if(this.configuration.getSeriesDimension)
			serie = this.configuration.getSeriesDimension();
		
		if (!serie) {
			this.plotOptions.legend = undefined;
			return undefined;
		}else 
			this.plotOptions.legend = {
				show: true,
		        placement: 'outside'
		    };
		
		for(var i= 0, attribute; attribute = serie.attributes[i]; ++i)
			seriesRet.push( {label: attribute.name} );
			
		return seriesRet;

	},

	/**
	 * @protected
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * @returns Object[][] containing the series to display
	 */
	_convertChartData2Plot: function(data) {

		if(!this.configuration.getSeriesDimension || !this.configuration.getSeriesDimension())
			return this._getFlatValues(data);
			
		return this._getGroupedValues(data);
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	 /**
	  * @private
	  * @function
	  * Convert values without grouping 
	  * @param {Statistics.Model.Values.IndicatorValue} data
	  */
	_getFlatValues: function(data){
		
		var result = [];
		for (var i = 0, value; value = data.values[i]; ++i) {

			var convertedValue = this._convertIndicatorValue(value);
			result.push( convertedValue );
		}
		
		return [result];
	},
	
	/**
	 * Group values into series
	 * @private
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValue} data
	 */
	_getGroupedValues: function(data){
		
		var seriesObj = {};
		
		for (var i = 0, value; value = data.values[i]; ++i) {

			var axisDimension = this.configuration.getAxisDimension();
			var filterDimension = value.getDimensionFilterById(axisDimension.id);
			var attribute = axisDimension.getAttributeById(filterDimension.attributeIds[0]);
		
			var convertedValue = [attribute.name, value.value];
			
			var currSerie = this._getSerieAttribute(value);
			if(!seriesObj[currSerie])seriesObj[currSerie] = [];
			seriesObj[currSerie].push( convertedValue );
		}
		
		var series = this.configuration.getSeriesDimension();
		var arr = [];
		for(var j = 0, attr; attr = series.attributes[j]; ++j)
			arr.push ( seriesObj[attr.id] )
		
		return arr;
	},
	
	/**
	 * Returns the serie attribute for this value
	 * @private
	 * @function 
	 * @param {Statistics.Model.Values.IndicatorValue} value
	 * @returns {String}
	 */
	_getSerieAttribute: function(value){

		var serie = this.configuration.getSeriesDimension();
		
		for (var i = 0, attr; attr = serie.attributes[i]; ++i) 
			if (value.containsAttributeId(serie.id, attr.id)) 
				return attr.id;
		
		return 'default';

	}
});