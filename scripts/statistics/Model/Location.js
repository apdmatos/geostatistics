
Statistics.Model.Location = Statistics.Class({
	
	/**
	 * @public 
	 * @property {double}
	 */
	latitude: null,

	/**
	 * @public 
	 * @property {double}
	 */	
	longitude: null,
	
	/**
	 * @constructor
	 * @param {double} lat
	 * @param {double} lon
	 */
	_init: function(lat, lon){
		this.latitude = lat;
		this.longitude = lon;
	}
});



Statistics.Model.Location.FromObject = function(obj) {
	
	if(!obj) return null;
	return new Statistics.Model.Location(obj.latitude, obj.longitude);
		
};
