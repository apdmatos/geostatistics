

Statistics.Model.RepresentationData.DimensionFilter = Statistics.Class({
	
	/**
	 * @public
	 * @property {string}
	 */
	dimensionId: null,

	/**
	 * @public
	 * @property {string[]}
	 */	
	attributeIds: null,
	
	/**
	 * @constructor
	 * @param {string} id
	 * @param {string[]} attrids
	 */
	_init: function(id, attrids) {
		this.dimensionId = id;
		this.attributeIds = attrids;
	}
});


Statistics.Model.RepresentationData.DimensionFilter.FromObject = function(obj){
	
	return new Statistics.Model.RepresentationData.DimensionFilter(obj.dimensionId, obj.attributes);
}
