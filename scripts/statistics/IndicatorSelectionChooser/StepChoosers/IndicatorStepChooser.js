

Statistics.IndicatorSelectionChooser.StepChooser.IndicatorStepChooser = 
	Statistics.Class(Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser, 
{
	
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
	 * Cleans the step and sets the result to be filled on
	 * Called to turn the step visible
	 * @public
	 * @function
	 */
	setResult: function(prevResult) {
		
		if(this.result) this.result.events.unbind('search.result.providerchanged', this.reloadFunc);
		Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser.prototype.setResult.apply(this, arguments);
		
		this.result.events.bind('search.result.providerchanged', this.reloadFunc);
	},
	
	/**
	 * Returns true, if the step is valid, false otherwise
	 * @public
	 * @function
	 * @returns {Boolean}
	 */
	validateStep: function() {
		return !!this.result.indicator;
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
		
		if(!this.result.provider) return;
		
		this.repository.getIndicators(
			this.result.provider.id,
			page, 
			this.resultsPerPage, 
			{
				successCallback: $.proxy(this.renderSearchResults, this)
			});
			
	},
	
	/**
	 * called when an element in the list is selected
	 * @abstract
	 * @protected
	 * @function
	 * @param {Object} element
	 */
	elementSelected: function(element) {
		this.result.setIndicator(element);
	}
	
});