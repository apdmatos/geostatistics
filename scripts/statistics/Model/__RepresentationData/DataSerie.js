

Statistics.Model.RepresentationData.DataSerie = Statistics.Class({
	
	location: null,
	
	/**
	 * @public
	 * @property {DataSerieValue[]}
	 * 
	 */
	values: null,
	
	_init: function(values, location) { 
		this.values = values;
	}
	
});



Statistics.Model.RepresentationData.DataSerie.FromObject = function(obj) {
	
	var values = [];
	for(var i = 0, value; value = obj.values[i]; ++i) {
		var v = Statistics.Model.RepresentationData.DataSerieValue.FromObject(value);
		values.push(v);
	}
	
	return new Statistics.Model.RepresentationData.DataSerie(values);
}
