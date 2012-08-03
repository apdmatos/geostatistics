
Statistics.App.Wizard = {
	
	/**
	 * @public
	 * @property {Statistics.IndicatorSelectionChooser}
	 */
	wizard: null,
	
	init: function(repository) {
		
		
		this.wizard = new Statistics.IndicatorSelectionChooser.WizardChooser(
			$("#wizard"),
			[
				new Statistics.IndicatorSelectionChooser.StepChooser.SourceStepChooser(this.repository),
				new Statistics.IndicatorSelectionChooser.StepChooser.IndicatorStepChooser(this.repository),
				new Statistics.IndicatorSelectionChooser.StepChooser.VisualizationStepChooser()
			]
		);
		
		
		//bind events
		$(".new_indicator a").click($.proxy(Statistics.App.Wizard.showWizard, this));
	},
	
	/**
	 * Opens the wizard to choose an indicator
	 * @public
	 * @function
	 */
	showWizard: function() {
		$("#wizard").show();
		this.wizard.startSelection();
	}
	
	
};
