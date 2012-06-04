

Statistics.ConfigurationEditor.SeriesConfigEditor = 
	Statistics.Class(Statistics.ConfigurationEditor.ChartConfigEditor, {
	
	/**
	 * Objects to choose data series
	 * @private
	 * @property {Object<JQueryElement>}
	 */
	elements: {
		addSerieLink: null,
		removeSerirLink: null,
		selectSerie: null
	},
	
	/**
	 * @override
	 * Called to draw the configuration editor
	 * 
	 * @public
	 * @function
	 * @param {JQueryElement} div - The element to draw the editor on
	 */
	redraw: function() {

		Statistics.ConfigurationEditor.ChartConfigEditor.prototype.redraw.apply(this, arguments);
		var serieElements = 
			$("<div>"
				+ "<hr/>"
				+ "<a href='#' class='addserie stats-series-action'>" + Statistics.i18n('addSerie') + "</a>"
				+ "<label class='hide'>Série:</label>" 
				+ "<select class='hide stats-dim-select'>"
				+ 	"<option class='stats-dim-dummy' value='none'>" + Statistics.i18n('selectDataSerie') + "</option>" 
				+ "</select>"
				+ "<a href='#' class='remserie hide stats-series-action'>" + Statistics.i18n('removeSerie') + "</a>"
			+ "</div>").appendTo(this.div);
		
		
		this.elements = {
			addSerieLink: 	 serieElements.find('a.addserie'),
			label: 			 serieElements.find('label'),
			selectSerie: 	 serieElements.find('select'),
			removeSerirLink: serieElements.find('a.remserie')
		};
		
		// fill series options
		var metadata = this.configuration.getMetadata();
		for(var i = 0, d; d = metadata.dimensions[i]; ++i)
			this.elements.selectSerie.append("<option class='stats-dim' value='" + d.id + "'>" + d.nameAbbr + "</option>");
		
		
		var self = this;
		this.elements.addSerieLink.click(function(){
			self.elements.addSerieLink.hide();
			self.elements.label.show();
			self.elements.selectSerie.show();
			self.elements.removeSerirLink.show();
		});
		
		this.elements.selectSerie.change(function(){
			if(!$(this).hasClass('.stats-dim-dummy')) {
				
				var d = self.configuration.getDimensionById($(this).val())
				self.updater.setSerieDimension( d );
			}
		});
		
		this.elements.removeSerirLink.click(function(){
			self.elements.addSerieLink.show();
			self.elements.label.hide();
			self.elements.selectSerie.hide();
			self.elements.removeSerirLink.hide();
			
			//reset all
			self.elements.selectSerie.val( 'none' );
		});
		
		//TODO: handle serie selection
	},

	/**
	 * @override
	 * Discard the changes
	 * @public
	 * @function
	 * @returns {Boolean} indicates if anything was discarded
	 */
	discardChanges: function() {
//		var changes = Statistics.ConfigurationEditor.prototype.discardChanges.apply(this, arguments);
//		if(changes) this._selectSelectedDimension();
//		
//		return changes;		
	}
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/	
	


});