

Statistics.ConfigurationEditor.PivotTableConfigEditor = Statistics.Class(Statistics.ConfigurationEditor, {
	
	/**
	 * Called to draw the configuration editor
	 * 
	 * @override
	 * @public
	 * @function
	 * @param {JQueryElement} div - The element to draw the editor on
	 */
	redraw: function() {
		Statistics.ConfigurationEditor.prototype.redraw.apply(this, arguments);
		
		var html = 
			$("<div class='stats-pivot-bag stats-pivot-filters'>" + 
	        	"<h1 class='ui-widget-header'>" + Statistics.i18n('dimensions') + "</h1>" +
	        	"<div class='stats-pivot-content ui-widget-content'>" +
					"<ul>" +
		        		"<li class='stats-pivot-placeholder'>" + Statistics.i18n('dragFiltersHere') + "</li>" +
		        	"</ul>" +
				"</div>" +
	        "</div>" +
			"<div class='stats-pivot-bag stats-pivot-columns'>" +
	        	"<h1 class='ui-widget-header'>" + Statistics.i18n('columns') + "</h1>" +
				"<div class='stats-pivot-content ui-widget-content'>" +
					"<ul>" +
		        		"<li class='stats-pivot-placeholder'>" + Statistics.i18n('dragColumnsHere') + "</li>" +
		        	"</ul>" +
				"</div>" +
	        "</div>" +
			"<div class='stats-clear'></div>" +
			"<div class='stats-pivot-bag stats-pivot-rows'>" +
				"<h1 class='ui-widget-header'>" + Statistics.i18n('rows') + "</h1>" +
				"<div class='stats-pivot-content ui-widget-content'>" +
		        	"<ul>" +
		        		"<li class='stats-pivot-placeholder'>" + Statistics.i18n('dragRowsHere') + "</li>" +
		        	"</ul>" +
				"</div>" +
	        "</div>").appendTo(this.div);
		
		this._redrawColumnsAndRows();
		
		var self = this;
		this.div.find( ".stats-pivot-bag li:not(.stats-pivot-placeholder)" ).draggable({
			appendTo: "body",
			helper: "clone",
			revert: "invalid"
		});
		this.div.find( ".stats-pivot-bag .stats-pivot-content" ).droppable({
			activeClass: "ui-state-default",
			hoverClass: "ui-state-hover",
			drop: function( event, ui ) {
				
				var ul = $( this ).find( "ul" )
				var from_ul = ui.helper.parent('ul');
				var dimension = ui.draggable[0].dimension;
				
				self._buildHtmlElement( dimension ).appendTo( ul );
				ui.draggable.remove();
				
				var timerId = window.setTimeout(function(){
					self.div.find('.stats-pivot-bag ul').each(function(idx, element){
	
						$(element).find(".stats-pivot-placeholder").hide();
						if($(element).children('.stats-dim').length == 0)
							$(element).find(".stats-pivot-placeholder").show();
					});
					
					// update the view
					self.updater.projectDimensions(
						self._getOrderedDimensions(self.div.find('.stats-pivot-rows')),
						self._getOrderedDimensions(self.div.find('.stats-pivot-columns'))
					);
					
					window.clearTimeout(timerId);
				}, 0);
			},
		}).sortable({
			items: "li:not(.stats-pivot-placeholder)",
			sort: function() {
				// gets added unintentionally by droppable interacting with sortable
				// using connectWithSortable fixes this, but doesn't allow you to customize active/hoverClass options
				$( this ).removeClass( "ui-state-default" );
			}
		});
		
		// register events for listening dimension selection changes, 
		// to update the interface
		this.configuration.events.bind(
			'config::projectedDimensionsChanged', 
			$.proxy(this._redrawColumnsAndRows, this));
		this.configuration.events.bind(
			'config::pivotConfigurationChanges', 
			$.proxy(this._redrawColumnsAndRows, this));
	},

	/**
	 * @override
	 * Discard the changes
	 * @public
	 * @function
	 * @returns {Boolean} indicates if anything was discarded
	 */
	discardChanges: function() {
		var changes = Statistics.ConfigurationEditor.prototype.discardChanges.apply(this, arguments);
		if(changes) this._redrawColumnsAndRows();
		
		return changes;
	},
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/	
	
	/**
	 * @private
	 * @function
	 * Called to draw columns and rows
	 */
	_redrawColumnsAndRows: function(){
		
		this.div.find('.stats-dim').remove();
		
		this._drawDimensions(this.div.find('.stats-pivot-filters ul'), 	this.configuration.getDimensionsFilterConfig().getSelectedDimensions());
		this._drawDimensions(this.div.find('.stats-pivot-columns ul'), 	this.configuration.columns);
		this._drawDimensions(this.div.find('.stats-pivot-rows ul'), 	this.configuration.rows);		
	},
	
	/**
	 * @private
	 * @function
	 * @param {JQueryElement} ul
	 * @param {Statistics.Model.Dimension[]} dimensions
	 */
	_drawDimensions: function(ul, dimensions){
		
		if(!dimensions || !dimensions.length) return;
		
		ul.find('.stats-pivot-placeholder').hide();
		for(var i = 0, d; d = dimensions[i]; ++i)
			ul.append( this._buildHtmlElement(d) );
	},
	
	/**
	 * Returns the html element to represent on the boxes
	 * @private
	 * @function
	 * @param {Statistics.Mode.Dimension} dimension
	 * @returns {JQUeryElement}
	 */
	_buildHtmlElement: function(dimension){
		var li = $("<li class='stats-dim'>" + dimension.nameAbbr + "</li>");
		li[0].dimension = dimension;
		return li; 
	},
	
	/**
	 * @private
	 * @function
	 * @param {JQueryElement} jqueryElement
	 * @returns {Statistics.Model.Dimension[]}
	 */
	_getOrderedDimensions: function(jqueryElement) {
		var arrDims = [];
		jqueryElement.find('.stats-dim').each(function(){
			arrDims.push( $(this)[0].dimension );
		});
		
		return arrDims;
	}

});