

Statistics.App.AnalysisWindow = {
	
	/**
	 * @public
	 * @property {Statistics.IndicatorSelectionChooser.StepChooser[]}
	 */
	steps: {
		provider: null,
		indicator: null,
		viewType: null
	},
	
	init: function() {
				
		this.steps.indicator 	= new Statistics.IndicatorSelectionChooser.StepChooser.IndicatorStepChooser(Statistics.App.repository),
		this.steps.provider 	= new Statistics.IndicatorSelectionChooser.StepChooser.SourceStepChooser(Statistics.App.repository, this.steps.indicator),
		this.steps.viewType 	= new Statistics.IndicatorSelectionChooser.StepChooser.VisualizationStepChooser()
	},
	
	/**
	 * @public
	 * @function
	 * @param {Object[]} result
	 */
	createAnalysis: function(result) {
		
		var provider = result[0];
		var indicator = result[1];
		var viewType = result[2];
		
		var analysisKey = Statistics.Model.Search.ViewTypeEnum.getAnalysisKey(viewType);		
		var analysis = new Statistics.App.Analysis[analysisKey](provider, indicator, Statistics.App.repository, Statistics.App.getLazyLoader());
		analysis.createWindow();
		
		
		var indicator = new Statistics.Indicator(
			indicator.id, 
			provider.id, 
			Statistics.App.repository, 
			[analysis.config]
		);
	}
	
};
