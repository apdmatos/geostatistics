


Statistics.Model.Search.Provider = Statistics.Class({
	
	/**
	 * @public
	 * @property {String}
	 */
	id: null,

	/**
	 * @public
	 * @property {String}
	 */	
	name: null,

	/**
	 * @public
	 * @property {String}
	 */	
	nameAbbr: null,

	/**
	 * @public
	 * @property {String}
	 */	
	url: null,
	
	/**
	 * @constructor
	 * @param {String} id
	 * @param {String} name
	 * @param {String} nameAbbr
	 * @param {String} url
	 */
	_init: function(id, name, nameAbbr, url) {
		this.id = id;
		this.name = name;
		this.nameAbbr = nameAbbr;
		this.url = url;
	}
	
});


Statistics.Model.Search.Provider.FromObject = function(obj) {
	return new Statistics.Model.Search.Provider(obj.ID, obj.Name, obj.NameAbbr, obj.URL);
}

