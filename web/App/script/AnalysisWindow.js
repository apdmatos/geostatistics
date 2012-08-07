

Statistics.App.AnalysisWindow = {
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.Result} result
	 */
	createAnalysis: function(result) {
		
		var analysisKey = Statistics.Model.Search.ViewTypeEnum.getAnalysisKey(result.viewType);		
		var analysis = new Statistics.App.Analysis[analysisKey](result, Statistics.App.repository, Statistics.App.getLazyLoader());
		analysis.createWindow();
		
		
		var indicator = new Statistics.Indicator(
			result.indicator.id, 
			result.provider.id, 
			Statistics.App.repository, 
			[analysis.config]
		);
	}
	
};
