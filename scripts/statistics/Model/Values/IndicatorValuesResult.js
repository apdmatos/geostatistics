

Statistics.Model.Values.IndicatorValuesResult = Statistics.Class({
	
	/**
	 * @public
	 * @property {Statistics.Model.Location}
	 * The location to represent this value
	 */
	location: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.Values.IndicatorValue[]}
	 * 
	 */
	values: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.Values.IndicatorValue[]} values
	 * @param {} location
	 */
	_init: function(values, location) { 
		this.values = values;
	}
	
});



Statistics.Model.Values.IndicatorValuesResult.FromObject = function(obj) {
	
	var values = [];
	for(var i = 0, value; value = obj.values[i]; ++i) {
		var v = Statistics.Model.Values.IndicatorValue.FromObject(value);
		values.push(v);
	}
	
	var location = Statistics.Model.Location.FromObject(obj.location);
	return new Statistics.Model.Values.IndicatorValuesResult(values, location);
};
