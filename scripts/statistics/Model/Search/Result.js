

Statistics.Model.Search.Result = Statistics.Class({
	
	EVENTS: ['search.result.completed'],
	
	/**
	 * @public
	 * @property {Statistics.Model.Search.Provider}
	 */
	provider: null,

	/**
	 * @public
	 * @property {Statistics.Model.Search.Indicator}
	 */	
	indicator: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.Search.ViewTypeEnum}
	 */
	viewType: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.Search.StepEnum}
	 */
	step: null,
	
	/**
	 * @public
	 * @property {Statistics.Event}
	 */
	events: null,
	
	/**
	 * @constructor
	 */
	_init: function(events) {
		this.events = events ? events : new Statistics.Events();
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.Provider} provider
	 */
	setProvider: function(provider) {
		
		this.provider = provider;
		this.step = Statistics.Model.Search.StepEnum.Source;
		
		this._done();
	},

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.Indicator} indicator
	 */	
	setIndicator: function(indicator) {
		this.provider = indicator;
		this.step = Statistics.Model.Search.StepEnum.Indicator;
		
		this._done();
	},

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.ViewTypeEnum} viewType
	 */		
	setViewType: function(viewType) {
		this.viewType = viewType;
		this.step = Statistics.Model.Search.StepEnum.ViewType;
		
		this._done();
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	_done: function() {
		if(this.provider && this.indicator && this.viewType !== null)
			this.events.trigger('search.result.completed', [this])
	}
	
});
