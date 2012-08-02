


Statistics.Model.Search.Indicator = Statistics.Class({
	
	/**
	 * @public
	 * @property {Integer}
	 * The indicator id
	 */
	id: null,

	/**
	 * @public
	 * @property {String}
	 * The indicator name
	 */	
	name: null,

	/**
	 * @public
	 * @property {String}
	 * The indicator abbreviated name
	 */	
	nameAbbr: null,

	/**
	 * @public
	 * @property {Statistics.Model.Search.Provider}
	 * The indicator provider
	 */		
	provider: null,

	/**
	 * @public
	 * @property {integer}
	 * The indicator's theme code
	 */	
	themeid: null,

	/**
	 * @public
	 * @property {integer}
	 * The indicator's sub theme code
	 */		
	subthemeid: null,
	
	/**
	 * @constructor
	 * @param {integer} id
	 * @param {String} name
	 * @param {String} nameAbbr
	 * @param {String} provider
	 * @param {Integer} themeid
	 * @param {Integer} subthemeid
	 */
	_init: function(id, name, nameAbbr, provider, themeid, subthemeid) {
		this.id = id;
		this.name = name;
		this.nameAbbr = nameAbbr;
		this.provider = provider;
		this.themeid = themeid;
		this.subthemeid = subthemeid;
	}
	
});


Statistics.Model.Search.Indicator.FromObject = function(obj) {
	
	var provider = Statistics.Model.Search.Provider.FromObject(obj.Provider);
	
	return new Statistics.Model.Search.Indicator(
		obj.ID,
		obj.Name, 
		obj.NameAbbr,
		provider,
		obj.ThemeID,
		obj,SubThemeID 
	);
}
