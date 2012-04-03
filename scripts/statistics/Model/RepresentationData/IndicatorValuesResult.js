

Statistics.Model.RepresentationData.IndicatorValuesResult = Statistics.Class({
	
	location: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.RepresentationData.IndicatorValue[]}
	 * 
	 */
	values: null,
	
	_init: function(values, location) { 
		this.values = values;
	}
	
});



Statistics.Model.RepresentationData.IndicatorValuesResult.FromObject = function(obj) {
	
	var values = [];
	for(var i = 0, value; value = obj.values[i]; ++i) {
		var v = Statistics.Model.RepresentationData.IndicatorValue.FromObject(value);
		values.push(v);
	}
	
	return new Statistics.Model.RepresentationData.DataSerie(values);
}
