

Statistics.Model.Search = Statistics.Class({
	
	/**
	 * @public
	 * @property {Object[]}
	 */
	elements: null,

	/**
	 * @public
	 * @property {Integer}
	 */	
	page: null,

	/**
	 * @public
	 * @property {Integer}
	 */	
	recordsPerPage: null,

	/**
	 * @public
	 * @property {Integer}
	 */		
	total: null,
	
	/**
	 * @constructor
	 * @param {Object[]} providers
	 * @param {Integer} page
	 * @param {Integer} total
	 */
	_init: function(elements, page, recordsPerPage, total) {
		this.elements = elements;
		this.page = page;
		this.recordsPerPage = recordsPerPage;
		this.total = total;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Integer}
	 * 
	 * Returns the number of total pages
	 */
	getNumberOfPages: function() {
		return Math.ceil(this.total / this.recordsPerPage);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Integer} id
	 * @returns {Object} the object with the given id. Null, if does not exist.
	 */
	getElementById: function(id) {
		for(var i = 0, elem; elem = this.elements[i]; ++i) {
			if(elem.id == id) return elem;
		}
		
		return null;
	}
	
});

Statistics.Model.Search.FromObject = function(obj, objFactory) {
	
	var elements = [];
	for(var i = 0, elem; elem= obj.Elements[i]; ++i){
		elements.push( objFactory(elem) );
	}
	
	return new Statistics.Model.Search(elements, obj.Page, obj.RecordsPerPage, obj.Total);
};










