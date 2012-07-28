



Statistics.ConfigurationEditor.ThematicMapConfigEditor = Statistics.Class(Statistics.ConfigurationEditor, {
	
	/**
	 * @private
	 * @property {JQueryElement}
	 * Contains the element to choose the aggregation element to show data from
	 */
	aggregationLevelSelect: null,
	
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
		
		var self = this;
		this.aggregationLevelSelect = 
			$("<select class='stats-dim-select'>"
				+ "<option class='stats-dim-dummy' value='none'>" + Statistics.i18n('selectAggregationLevel') + "</option>" 
			+ "</select>").appendTo(this.div);
		
		var geoDimension = this.configuration.getMetadata().getDimensionsByType( Statistics.Model.DimensionType.Geographic )[0];
		for(var i = 0, attrConf; attrConf = geoDimension.attributeConfiguration[i]; ++i)
			this.aggregationLevelSelect.append(
				"<option class='stats-dim' value='" + attrConf.id + "'>" + attrConf.name + "</option>"
			);
		
		this.dimensionSelect.change(function(){
			if(!$(this).hasClass('.stats-dim-dummy')) {
				
//				var metadata = self.configuration.getMetadata();
//				var geoDimension = metadata.getDimensionsByType( Statistics.Model.DimensionType.Geographic );
				var aggregationLevel = geoDimension.getAttributeConfigurationById( $(this).val() );
				
				self.updater.setAggregationLevel( aggregationLevel );
			}
		});	
		
		// register events for listening aggregation level selection changes, 
		// to update the interface
		this.configuration.events.bind(
			'config::aggregationLevelConfigurationChanges', 
			$.proxy(this._selectSelectedDimension, this));
		
		this._selectSelectedAggregationLevel();
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
		if(changes) this._selectSelectedAggregationLevel();
		
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
	 * Called to update selected aggregation level
	 */
	_selectSelectedAggregationLevel: function() {
		
		var aggregationLevel = this.configuration.aggregationLevel;
		var value = 'none';
		if(aggregationLevel) value = aggregationLevel.id;
		
		aggregationLevelSelect.val( value );
	}
	
});


