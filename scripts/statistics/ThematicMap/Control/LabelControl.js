

Statistics.ThematicMap.Control.LabelControl = Statistics.Class(OpenLayers.Control, {
	
	/**
	 * The colors to represent
	 * @private
	 * @property {String[]}
	 */
	colors: null,
	
	/**
	 * Contains the calculator, to define interval boundaries
	 * @private
	 * @property {Statistics.ThematicMap.IntervalsCalculator}
	 */
	intervalsCalculator: null,
	
	/**
	 * Contains the 
	 * @private
	 * @property {Statistics.Model.Values.IndicatorValuesRange}
	 */
	indicatorRange: null,
	
	/**
	 * @constructor
	 * @param {Statistics.ThematicMap.IntervalsCalculator} intervalsCalculator
	 */
	_init: function(intervalsCalculator) {
		this.intervalsCalculator = intervalsCalculator;
	},
	
	/**
	 * @Override
	 * @protected
	 * @function
	 * @param {OpenLayers.Pixel} px
	 */
	draw: function(px) {
		OpenLayers.Control.prototype.draw.apply(this, arguments);
		if(this.indicatorRange) {
			this.redraw();
		}
		
		this.div.style.position = 'absolute';
		this.div.style.right = '0';
		this.div.style.bottom = '0';
		return this.div;
	},
	
	/**
	 * redraws the label
	 * @private
	 * @function
	 */
	redraw: function() {
		
		this.div.empty();
		
		var intervals = this.intervalsCalculator.calculate(this.indicatorRange, this.colors.length);
		for (var i = 0, interval; interval = intervals[i]; ++i) {
			$("<div>" + 
				"<span style='backgound:" + this.colors[i] + "'></span>" + 
				interval.min + " - " + interval.max + 
			  "</div>"
			).appendTo(this.div);
		}
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Values.IndicatorValuesRange} indicatorRange
	 * @param {String[]} colors
	 */
	setIndicatorRangeValues: function(indicatorRange, colors) {
		this.indicatorRange = indicatorRange;
		this.colors = colors;
		
		if(this.div) {
			this.redraw();
		}
	},
	
	/**
	 * @public
	 * @function
	 * @param {String[]} colors
	 */
	setColors: function(colors) {
		this.colors = colors;
		if( this.div ) {
			this.redraw();
		}
	},
	
	CLASS_NAME: 'Statistics.Map.Control.LabelControl'
});
