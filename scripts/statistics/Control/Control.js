

Statistics.Control = Statistics.Class({
	
	/**
	 * @public
	 * @property {jQueryElement} div 
	 * Place holder to receive the control content
	 */
	div: null,
	
//	/**
//	 * @public
//	 * @property {String} title
//	 * The indicator name to display on control
//	 */
//	title: null,
	
	/**
	 * @public
	 * @property {Statistics.Model.IndicatorMetadata}
	 * The metadata to represent
	 */
	metadata: null,
	
	/**
	 * @protected
	 * @property
	 * should be setted by each control.
	 */
	_controlContent: null,
	
	/**
	 * @constructor
	 * @param {jQueryElement} div - The div element to render the control to
	 * @param {String} [options] - Some optional parameters to override in this instance
	 * 	- title {String}
	 */
	_init: function(div, options){
		jQuery.extend(this, options);
		
		this.div = div;
	},
	
//	/**
//	 * @public
//	 * @function
//	 * @param {String} title - The indicator title to display
//	 */
//	setTitle: function(title){
//		this.title = title;
//	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} metadata
	 */
	setMetadata: function(metadata){
		this.metadata = metadata;
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
	 * @param {Statistics.Model.Data} data
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