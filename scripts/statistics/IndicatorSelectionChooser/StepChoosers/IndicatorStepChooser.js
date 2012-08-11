

Statistics.IndicatorSelectionChooser.StepChooser.IndicatorStepChooser = 
	Statistics.Class(Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser, 
{
	
	/**
	 * Contains the previous step state object
	 * @public
	 * @function
	 * @param {Object} previousStepState
	 */
	setPrevStepState: function(previousStepState){
		if(this.stepSelectedObject && this.stepSelectedObject.id === previousStepState.id ) return;
		Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser.prototype.setPrevStepState.apply(this, arguments);
		
		this.clearResults();
		this.requestResults(1);
	},	
	
	/**
	 * Returns the step
	 * @public
	 * @function
	 * @returns {Statistics.Model.StepEnum}
	 */
	getStepType: function() {
		return Statistics.Model.Search.StepEnum.Indicator;
	},	
	
	/**
	 * Returns the step name, to display
	 * @public
	 * @function
	 * @returns {String}
	 */
	getStepName: function() {
		return Statistics.i18n('indicator');
	},
	
	/**
	 * If the step contains validation errors, returns a string indicating the error.
	 * If does not have errors, returns null
	 * @public
	 * @function
	 * @returns {String}
	 */
	validationError: function() {
		return Statistics.i18n('indicatorSelectionError');
	},	

/**********************************************************************************
 * ********************************************************************************
 * Protected methods
 **********************************************************************************
 **********************************************************************************/	
	
	/**
	 * Requests results for the current page
	 * @abstract
	 * @protected
	 * @function
	 * @param {Integer} page
	 */
	requestResults: function(page) {
		
		if(!this.prevStepState) return;
		
		this.repository.getIndicators(
			this.prevStepState.id,
			page, 
			this.resultsPerPage, 
			{
				successCallback: $.proxy(this.renderSearchResults, this)
			});
			
	}
	
});