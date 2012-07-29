

Statistics.ThematicMap.Control.LabelControl = Statistics.Class(OpenLayers.Control, {
	
	colors: null,
	
	intervalsCalculator: null,
	
	indicatorRange: null,
	
	_init: function(intervalsCalculator) {
		this.intervalsCalculator = intervalsCalculator;
	},
	
	setIndicatorRangeValues: function(indicatorRange, colors) {
		this.indicatorRange = indicatorRange;
		this.colors = colors;
		
		// calculate colors
	},
	
	setColors: function(colors) {
		// update colors in UI
	},
	
	CLASS_NAME: 'Statistics.Map.Control.LabelControl'
});
