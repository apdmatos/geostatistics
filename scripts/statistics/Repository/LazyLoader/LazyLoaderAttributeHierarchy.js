

Statistics.Repository.LazyLoaderAttributeHierarchy = Statistics.Class({
	
	/**
	 * @private
	 * @property
	 * @param {Statistics.Repository} repository
	 */
	repository: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Repository} repository
	 */
	_init: function(repository) {
		this.repository = repository;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Object} sourceid
	 * @param {Object} indicatorid
	 * @param {Object} dimension
	 * @param {Object} attribute
	 * @param {Function} completed
	 */
	loadAttributes: function(sourceid, indicatorid, dimension, attribute, level, completed){
				
		this.repository.getDimensionAttributes(
			sourceid, 
			indicatorid, 
			dimension.id, 
			attribute.id, 
			level, 
			{
				successCallback: function(attributes) {
					attribute.addAttributes(attributes);
					completed(attributes);
					// fire an event on dimension object
					// dimension.event...
				}
			}
		);
	}
	
});
