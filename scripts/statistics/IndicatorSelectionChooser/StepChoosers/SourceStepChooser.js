

Statistics.IndicatorSelectionChooser.StepChooser.SourceStepChooser = 
	Statistics.Class(Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser, 
{	
	/**
	 * Returns the step
	 * @public
	 * @function
	 * @returns {Statistics.Model.StepEnum}
	 */
	getStepType: function() {
		return Statistics.Model.Search.StepEnum.Source;
	},	
	
	/**
	 * @public
	 * @abstract
	 * @function
	 */
	redraw: function() {
		
		Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser.prototype.redraw.apply(this, arguments);
		this.clearResults();
		this.requestResults(1);
	},	
	
	/**
	 * Returns the step name, to display
	 * @public
	 * @function
	 * @returns {String}
	 */
	getStepName: function() {
		return Statistics.i18n('sourceName');
	},
	
	/**
	 * If the step contains validation errors, returns a string indicating the error.
	 * If does not have errors, returns null
	 * @public
	 * @function
	 * @returns {String}
	 */
	validationError: function() {
		return Statistics.i18n('sourceNameSelectionError');
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
		
		this.repository.getProviders(
			page, 
			this.resultsPerPage, 
			{
				successCallback: $.proxy(this.renderSearchResults, this)
			});
			
	}	
});