
Statistics.App.Wizard = {
	
	/**
	 * @public
	 * @property {Statistics.IndicatorSelectionChooser}
	 */
	wizard: null,
	
	/**
	 * @Initializer
	 * @param {Statistics.Repository} repository
	 */
	init: function(repository) {
		
		this.wizard = new Statistics.IndicatorSelectionChooser.WizardChooser(
			$("#wizard"),
			[
				Statistics.App.AnalysisWindow.steps.provider,
				Statistics.App.AnalysisWindow.steps.indicator,
				Statistics.App.AnalysisWindow.steps.viewType
			]
		);
		
		
		var self = this;
		
		//bind events
		$(".new_indicator a").click($.proxy(Statistics.App.Wizard.showWizard, this));
		$(window).resize(jQuery.proxy(this._positionWizard, this));
		
		// bind cancel events
		$(window).keypress(function(e) {
			if(e.keyCode == Statistics.App.KEYS.ESC) self._removeWizard(); 
		});
		$(".wizardbackground").click(jQuery.proxy(this._removeWizard, this));
	},
	
	/**
	 * Opens the wizard to choose an indicator
	 * @public
	 * @function
	 */
	showWizard: function() {
		$("#wizard, .wizardbackground").show();
		this.wizard.startSelection(function(result) {
			Statistics.App.Wizard._removeWizard();
			Statistics.App.AnalysisWindow.createAnalysis(result);
		});
		this._positionWizard();
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * @private
	 * @handler
	 * @called when the window is resized, to position the wizard
	 */
	_positionWizard: function() {
		
		var left = $(window).width()/2 - $("#wizard").width()/2;
		var top = $(window).height()/2 - $("#wizard").height()/2;
		
		$("#wizard").css({ top: top, left: left });
		$(".wizardbackground").css({ 
			width: $(document).width(),
			height: $(document).height() 
		});
	},
	
	/**
	 * @private
	 * @handler
	 * @called to close wizard and cancel indicator selection
	 */
	_removeWizard: function() {
		$("#wizard, .wizardbackground").hide();
	}
	
	
};
