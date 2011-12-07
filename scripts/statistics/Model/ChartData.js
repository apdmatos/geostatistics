



Statistics.Model.ChartData = Statistics.Class({
	
	/**
	 * @public
	 * @property {Double}
	 * Contains the value to represent on chart
	 */
	value: null,
	
	/**
	 * @public
	 * @property {String}
	 * Contains the label that represents the value
	 */
	label: null,
	
	/**
	 * 
	 * @param {Object} value
	 * @param {Object} label
	 */
	_init: function(value, label) {
		this.value = value;
		this.label = label;
	}
});


/**
 * @static
 * @public
 * @function
 * @param {Object} object
 * converts this object to a ChartData object
 */
Statistics.Model.ChartData.FromObject = function(obj){
	
	return new Statistcs.Model.ChartData(obj.value, obj.label);
};
