

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
	 * The next step to send state to
	 * @private
	 * @property {Statistics.IndicatorSelectionChooser.StepChooser}
	 */
	nextStep: null,
	
	/**
	 * @private
	 * @property
	 * @param {Integer} idx
	 * The step index
	 */
	idx: null,
	
	/**
	 * Contains the current step selected object
	 * @private
	 * @property {Object}
	 */
	stepSelectedObject: null,

	/**
	 * Contains the current step selected object
	 * @private
	 * @property {Object}
	 */	
	prevStepState: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Repository} repository
	 */
	_init: function(repository, nextStep) {
		this.repository = repository;
		this.nextStep = nextStep;
	},
	
	/**
	 * Contains the previous step state object
	 * @public
	 * @function
	 * @param {Object} previousStepState
	 */
	setPrevStepState: function(previousStepState){
		this.stepSelectedObject = null;
		this.prevStepState = previousStepState;
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
	 * Returns the step selection
	 * @private
	 * @function
	 * @returns {Object}
	 */
	getSelectionObject: function() {
		return this.stepSelectedObject;
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
	 * @public
	 * @function
	 * @returns {Boolean}
	 */
	validateStep: function() {
		return this.stepSelectedObject !== null;
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
	
	setStepSelectedObject: function(stepState) {
		this.stepSelectedObject = stepState;
		if(this.nextStep) this.nextStep.setPrevStepState(stepState);
	},
	
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
