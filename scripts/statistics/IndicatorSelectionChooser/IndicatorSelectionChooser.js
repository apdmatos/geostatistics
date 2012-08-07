

Statistics.IndicatorSelectionChooser = Statistics.Class({

	/**
	 * Indicates if the wizard has been drawn
	 * @private
	 * @property {Boolean}
	 */
	drawn: false,
	
	/**
	 * @private
	 * @property {JQueryElement}
	 */
	div: null,
	
	/**
	 * @private
	 * @property {Statistics.IndicatorSelectionChooser.StepChooser[]}
	 */
	steps: null,
	
	/**
	 * @private
	 * @property {Statistics.Model.Search.Result}
	 */
	result: null,
	
	/**
	 * @private
	 * @property {Function}
	 * Function to call when the results are available
	 */
	doneFunc: null,
	
	/**
	 * @constructor
	 * @param {JQueryElement} div
	 * @param {Statistics.IndicatorSelectionChooser.StepChooser[]} steps
	 */
	_init: function(div, steps) {
		this.div = div;
		this.steps = steps; 
		
		for(var i = 0, step; step = this.steps[i]; ++i)
			step.setStepIndex(i);
	},

	/**
	 * @public
	 * @function
	 * @param {Function} doneFunc
	 */
	startSelection: function(doneFunc) {
		
		if(!this.drawn) this.draw();
		
		this.result = new Statistics.Model.Search.Result();
		//this.result.events.bind('search.result.completed', doneFunc);
		this.doneFunc = doneFunc;
		
		for(var i = 0, step; step = this.steps[i]; ++i)
			step.setResult(this.result);
	},
	
	/**
	 * @public
	 * @function
	 * @returns {Boolean} returns true if the chooser is already drawn, false otherwise
	 */
	isDrawn: function() {
		return this.drawn;
	},

	/**
	 * Called to draw the component
	 * @public
	 * @function
	 */
	draw: function() { 
		if(this.drawn) return;
		this.drawn = true;
		this.redraw();
	},
	
	/**
	 * @public
	 * @function
	 */
	redraw: function() {
		/*should be implemented by each specific class*/
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.StepEnum} stepEnumType
	 * @returns {Statistics.IndicatorSelectionChooser.StepChooser}
	 */
	getStepByType: function(stepEnumType) {
		for(var i = 0, step; step = this.steps[i]; ++i)
			if(step.getStepType() == stepEnumType) return step;
			
		return null;
	},

	/**
	 * @abstract
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.StepEnum} stepEnumType
	 */	
	selectStepByType: function(stepEnumType) {
		/*should be implemented by each specific class*/
	},
	
	/**
	 * @abstract
	 * @public
	 * @function
	 * @param {Statistics.IndicatorSelectionChooser.StepChooser} stepEnumType
	 */	
	selectStep: function(step) {
		/*should be implemented by each specific class*/
	}
	
	
});