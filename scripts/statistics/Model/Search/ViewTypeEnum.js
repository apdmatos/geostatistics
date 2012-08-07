

Statistics.Model.Search.ViewTypeEnum = {
	
	BarChart: 0,
	
	PieChart: 1,
	
	ThematicMap: 2,
	
	PivotTable: 3,
	
	/**
	 * @public
	 * @function
	 * @param {Integer} analysis
	 */
	getAnalysisKey: function(analysis) {
		
		for(var p in this) {
			if(this[p] == analysis) return p;
		}
		
		return null;
		
	}
	
};
