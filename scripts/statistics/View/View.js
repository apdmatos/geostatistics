

Statistics.View = Statistics.Class({
	
	/**
	 * @public
	 * @property {jQueryElement} div 
	 * Place holder to receive the control content
	 */
	div: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.DimensionConfig}
	 * The metadata to represent
	 */
	configuration: null,
	
	/**
	 * @protected
	 * @property
	 * should be setted by each control.
	 */
	_controlContent: null,
	
	/**
	 * @constructor
	 * @param {jQueryElement} div - The div element to render the control to
	 */
	_init: function(div){
		
		this.div = div;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.DimensionConfig} configuration
	 */
	setConfiguration: function(configuration){
		this.configuration = configuration;
	},
	
	/**
	 * @public
	 * @function
	 * puts a loading message on the div
	 */
	setLoadingData: function(){
		/*MUST BE IMPLEMENTED!!!*/
	},
	
	/**
	 * @public
	 * @function
	 * puts a message on the screen, indicating that there's no filters selected
	 */
	setNoFilters: function(){
		/*MUST BE IMPLEMENTED!!!*/
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesResult} data
	 * Sets the data to be represented
	 */
	setData: function(data){
		// this method should be redefined by each specific class
	},
	
	/**
	 * @public
	 * @function
	 * Abstract method. Should be redifined by each specific control
	 */
	show: function() {
		if(this._controlContent) this._controlContent.show();
	},
	
	/**
	 * @public
	 * @function
	 * Abstract method. Should be redefined
	 */
	hide: function() {
		if(this._controlContent) this._controlContent.hide(); 
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Boolean} returns true if is visible, false otherwise.
	 */
	isShown: function(){
		return !this._controlContent.is(':visible');
	}
});