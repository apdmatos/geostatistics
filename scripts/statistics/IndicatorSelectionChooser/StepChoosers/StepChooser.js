

Statistics.IndicatorSelectionChooser.StepChooser = Statistics.Class({
	
	/**
	 * The div to draw the step on
	 * @private
	 * @property {JQueryElement}
	 */
	div: null,
	
	/**
	 * The repository to request information
	 * @private
	 * @property {Statistics.Repository}
	 */
	repository: null,
	
	/**
	 * The result to fill
	 * @private
	 * @property {Statistics.Model.Search.Result}
	 */
	result: null,
	
	/**
	 * @private
	 * @property
	 * @param {Integer} idx
	 * The step index
	 */
	idx: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Repository} repository
	 */
	_init: function(repository) {
		this.repository = repository;
	},
	
	/**
	 * Sets the step idx
	 * @public
	 * @function
	 * @param {Integer} idx
	 */
	setStepIndex: function(idx) {
		this.idx = idx;
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Integer}
	 * Returns the step index
	 */
	getStepIndex: function() {
		return this.idx;
	},
	
	/**
	 * @public
	 * @function
	 * @param {JQueryElement} div
	 */
	draw: function(div) {
		this.div = div;
		this.redraw();
	},
	
	/**
	 * Returns the step
	 * @abstract
	 * @public
	 * @function
	 * @returns {Statistics.Model.StepEnum}
	 */
	getStepType: function() {
		/*abstract method, should be implemented by each specific class*/
	},	
	
	/**
	 * @public
	 * @abstract
	 * @function
	 */
	redraw: function() {
		/*abstract method, should be implemented by each specific class*/
	},
	
	/**
	 * Cleans the step and sets the result to be filled on
	 * Called to turn the step visible
	 * @abstract
	 * @public
	 * @function
	 */
	setResult: function(prevResult) {
		this.result = prevResult;
		
		/*abstract method, should be implemented by each specific class*/
	},	
	
	/**
	 * Returns the step name, to display
	 * @abstract
	 * @public
	 * @function
	 * @returns {String}
	 */
	getStepName: function() {
		/*abstract method, should be implemented by each specific class*/
	},
	
	/**
	 * Returns true, if the step is valid, false otherwise
	 * @abstract
	 * @public
	 * @function
	 * @returns {Boolean}
	 */
	validateStep: function() {
		/*abstract method, should be implemented by each specific class*/
	},
	
	/**
	 * If the step contains validation errors, returns a string indicating the error.
	 * If does not have errors, returns null
	 * @abstract
	 * @public
	 * @function
	 * @returns {String}
	 */
	validationError: function() {
		/*abstract method, should be implemented by each specific class*/
	},

/**********************************************************************************
 * ********************************************************************************
 * Protected methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * Shows a loading message in the current step
	 * @protected
	 * @function
	 */
	showLoadingMessage: function(message) {
		// TODO: must be implemented here
	},
	
	/**
	 * Removes loading message
	 * @protected
	 * @function
	 */
	removeLoadingMessage: function() {
		// TODO: must be implemented here
	}
});
