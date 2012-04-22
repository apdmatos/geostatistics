

Statistics.ConfigurationEditor.ChartConfigEditor = Statistics.Class(Statistics.ConfigurationEditor, {
	
	/**
	 * @override
	 * Called to draw the configuration editor
	 * 
	 * @public
	 * @function
	 * @param {JQueryElement} div - The element to draw the editor on
	 */
	redraw: function() {
		Statistics.ConfigurationEditor.prototype.redraw.apply(this, arguments);
		
		var self = this;
		var select = 
			$("<select class='stats-dim-select'>"
				+ "<option class='stats-dim-dummy' value='none'>" + Statistics.i18n('selectDimension') + "</option>" 
			+ "</select>").appendTo(this.div);
		
		var metadata = this.configuration.getMetadata();
		for(var i = 0, d; d = metadata.dimensions[i]; ++i)
			select.append("<option class='stats-dim' value='" + d.id + "'>" + d.nameAbbr + "</option>");
		
		select.change(function(){
			if(!$(this).hasClass('.stats-dim-dummy')){
				
				var d = self.configuration.getDimensionById($(this).val())
				self.updater.setProjectedDimensions( [d] );
			}
		});	
		
		// register events for listening dimension selection changes, 
		// to update the interface
		this.configuration.events.bind(
			'config::projectedDimensionsChanged', 
			$.proxy(this._selectSelectedDimension, this));
		
		this._selectSelectedDimension();
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
		if(changes) this._selectSelectedDimension();
		
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
	_selectSelectedDimension: function(){
		var dimensions = this.configuration.getSelectedDimensions();
		var value = 'none';
		if(dimensions.length > 0) value = dimensions[0].id;
		this.div.find('select').val( value );
	}

});