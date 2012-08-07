


Statistics.IndicatorSelectionChooser.StepChooser.VisualizationStepChooser = 
	Statistics.Class(Statistics.IndicatorSelectionChooser.StepChooser, 
{
	
	/**
	 * Returns the step
	 * @abstract
	 * @public
	 * @function
	 * @returns {Statistics.Model.StepEnum}
	 */
	getStepType: function() {
		return Statistics.Model.Search.StepEnum.ViewType;
	},
	
	/**
	 * @public
	 * @abstract
	 * @function
	 */
	redraw: function() {
		
		var representation = $("<ul>"
			+ "<li class='thematicMap' data-view='ThematicMap'>Mapa</li>"
			+ "<li class='piechart' data-view='PieChart'>Gráfico circular</li>"
			+ "<li class='barchart' data-view='BarChart'>Gráfico de barras</li>"
			+ "<li class='pivotTable' data-view='PivotTable'>Tabela pivot</li>"
		+ "</ul>");
		
		this.div.append(representation);
		
		var self = this;
		representation.find('li').click(function(){
			
			$(this).parent().find('li').removeClass('statistics_visualization_selected');
			$(this).addClass('statistics_visualization_selected');
			
			var viewType = $(this).data('view');
			self.result.setViewType(Statistics.Model.Search.ViewTypeEnum[viewType]);
			
		});
		
	},	
	
	/**
	 * Returns the step name, to display
	 * @abstract
	 * @public
	 * @function
	 * @returns {String}
	 */
	getStepName: function() {
		return Statistics.i18n('visualizationType');
	},
	
	/**
	 * Returns true, if the step is valid, false otherwise
	 * @abstract
	 * @public
	 * @function
	 * @returns {Boolean}
	 */
	validateStep: function() {
		return this.result.viewType != null;
	},
	
	/**
	 * If the step contains validation errors, returns a string indicating the error.
	 * If does not have errors, returns null
	 * @abstract
	 * @public
	 * @function
	 * @returns {String}
	 */
	validationError: function() {
		return Statistics.i18n('vizualizationSelectionError');
	}	
	
});