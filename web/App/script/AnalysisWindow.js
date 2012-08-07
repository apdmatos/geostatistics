

Statistics.App.AnalysisWindow = {
	
	windowAnalysis: {
		BarChart: {
			mainDialog: { width: 600, height: 500, minWidth: 300, minHeight: 300 },
			tabNames: ["Dimensoes", "Projetar"],
			createAnalysis: function() {
				
				var config = Statistics.App.AnalysisWindow.createChartConfiguration();
				var PieController = 
						new Statistics.Controller.ProjectionController (
							config,
							repository,
							new Statistics.View.PieChartView('pieChart')
						);
				
				var treeConfigEditor = new Statistics.ConfigurationEditor.DimensionsConfigEditor(config, new Statistics.ConfigurationEditor.DimensionFilterUpdater(config), createLazyLoader);
				var chartConfigEditor = new Statistics.ConfigurationEditor.ChartConfigEditor(config, new Statistics.ConfigurationEditor.DimensionProjectorUpdater(config));

				
				
				createDialogForConfiguration(
					$('#pieChartConfig'), 
					$('#pieChartConfigDialog'),
					[
						{
							tab: $('#pie-chart-tabs-1'),
							config: treeConfigEditor
						},
						{
							tab: $('#pie-chart-tabs-2'),
							config: chartConfigEditor
						}
					]);
				
				return config;
			}	
		},
		PieChart: {
			mainDialog: { width: 500, height: 500, minWidth: 300, minHeight: 300 },
			tabNames: ["Dimensoes", "Projetar"],
			createAnalysis: function() {
				
			}	
		},
		ThematicMap: { 
			mainDialog: { width: 600, height: 500, minWidth: 300, minHeight: 300 },
			tabNames: ["Dimensoes", "Nível de agregação"],
			createAnalysis: function() {
				
			}	
		},
		PivotTable: {
			mainDialog: { width: 'auto', height: 'auto', minWidth: 300, minHeight: 300 },
			tabNames: ["Dimensoes", "Formato da tabela"],
			createAnalysis: function() {
				
			}	
		}
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.Result} result
	 */
	createAnalysis: function(result) {
		
		var analysisKey = Statistics.Model.Search.ViewTypeEnum.getAnalysisKey(result.viewType);
		var optionsHtml = this.createConfigDialog(this.windowAnalysisDimensions[analysisKey].tabNames);
		
		
		var dialogOptions = jQuery.extend(
			{
				position: 'center',
				title: result.indicator.nameAbbr,
				buttons: [
					{
						text: 'Opções',
						'class': 'config',
						click: function(){
							//$('#pieChartConfigDialog').dialog('open');
						}
					}
				]
			},
			this.windowAnalysisDimensions[analysisKey].mainDialog
		);
		
		$("<div></div>").dialog(dialogOptions).appendTo($(document));
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	createChartConfiguration: function() {
		
		var dimensionSelector = new Statistics.DimensionSelector.DefaultDimensionSelector();
		var config = new Statistics.Model.DimensionConfig.DimensionProjectionConfig (
			dimensionSelector,
			new Statistics.Model.DimensionConfig.DimensionFilterConfig(dimensionSelector)
		);
		
		var PieController = 
				new Statistics.Controller.ProjectionController (
					config,
					repository,
					new Statistics.View.PieChartView('pieChart')
				);
		
		var treeConfigEditor = new Statistics.ConfigurationEditor.DimensionsConfigEditor(config, new Statistics.ConfigurationEditor.DimensionFilterUpdater(config), createLazyLoader);
		var chartConfigEditor = new Statistics.ConfigurationEditor.ChartConfigEditor(config, new Statistics.ConfigurationEditor.DimensionProjectorUpdater(config));
		
		return {
			config: config,
			editors: [treeConfigEditor, chartConfigEditor]
		};
	},
	
	createMainDialog: function(options) {
		
		var dialogOptions = jQuery.extend(
			{
				position: 'center',
				title: result.indicator.nameAbbr,
				buttons: [
					{
						text: 'Opções',
						'class': 'config',
						click: function(){
							//$('#pieChartConfigDialog').dialog('open');
						}
					}
				]
			},
			options
		);
		
		return $("<div></div>").dialog(dialogOptions);
	},
	
	/**
	 * Utility method that draws html for analysis' window options
	 * @private
	 * @function
	 * @returns {JQueryElement}
	 */
	createConfigDialog: function(tabNames) {
		
//		var dialog = $("<div class='dialog'>"
//							+ "<div class='tabs'>"
//				 				+ "<ul></ul>"
//							+ "</div>"
//					 + "</div>");
//					 
//		for(var i = 0, tab; tab = tabNames[i]; ++i) {
//			
//			var randomnumber=Math.floor(Math.random()*11)
//			
//			var li = $("<li><a href='#tab-" + randomnumber + "'>" + tab + "</a></li>");
//			var content = $("<div class='tabcontent' id='" + randomnumber + "'></div>");
//			
//			dialog.find('ul').append(li);;
//			dialog.find('dialog').append(content);;
//		}
//		
//		dialog.find(".tabs").tabs();
//		
//
//		return dialog;
	}
	
	
};
