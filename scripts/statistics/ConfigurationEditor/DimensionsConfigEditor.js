

Statistics.ConfigurationEditor.DimensionsConfigEditor = Statistics.Class(Statistics.ConfigurationEditor, {
	
	/**
	 * @private
	 * @property
	 * @param {Object<string, Jquery.Plugins.Dynatree>} trees
	 */
	trees: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.DimensionConfig} config - The configuration to set changes on
	 * @param {Boolean} autoApply[=false] - Applies the changes on the fly to configuration. Default is false
	 */
	_init: function(config, autoApply){
		Statistics.ConfigurationEditor.prototype._init.apply(this, arguments);
	},	
	
	/**
	 * Called to draw the configuration editor
	 * 
	 * @public
	 * @function
	 * @param {JQueryElement} div - The element to draw the editor on
	 */
	draw: function(div) {
		Statistics.ConfigurationEditor.prototype.draw.apply(this, arguments);
		this.trees = {};
		
		var metadata = this.configuration.getMetadata();
		div.append( "<h1>" + metadata.name + "</h1>" );
		for(var i = 0, d; d = metadata.dimensions[i]; ++i)
			this._drawDimension( d );
			
		return div;
	},
	
	/**
	 * Apply changes to configuration
	 * @public
	 * @function
	 */
	applyChanges: function(){
		alert( 'apply' );
	},
	
	/**
	 * Discard the changes
	 * @public
	 * @function
	 */
	discardChanges: function(){
		alert( 'discard' );
	},
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/	
	
	/**
	 * Draws the dimension
	 * @private
	 * @function
	 * @param {Statistics.Model.Dimension} dimension
	 */
	_drawDimension: function(dimension){
		
		var treeData = [];
		for(var i = 0, attr; attr = dimension.attributes[i]; ++i)
			treeData.push( this._attributeToTreeData(attr) );
		
		this.div.append( "<h2>" + dimension.name + "</h2>" );
		this.trees[dimension.id] = 
			$("<div class='tree'></div>").dynatree({
					title: dimension.name,
      				checkbox: true,
      				selectMode: 2,
      				children: treeData,
					autoFocus: false,
      				onSelect: function(select, node) {
						
						alert('select');
						
      				},
      				onClick: function(node, event) {
        				// We should not toggle, if target was "checkbox", because this
        				// would result in double-toggle (i.e. no toggle)
        				if( node.getEventTargetType(event) == "title" )
          					node.toggleSelect();
      				},
					onLazyRead: function(node){
						
						// TODO: ...						
						alert('lazy loaded');
					},
      				// The following options are only required, if we have more than one tree on one page:
      				idPrefix: dimension.id
			}).appendTo(this.div);
	},
	
	/**
	 * Converts a Statistics.Model.Attribute on treeData, to be displayed as a tree
	 * @private
	 * @function
	 * @param {Statistics.Model.Attribute} attribute
	 */
	_attributeToTreeData: function(attribute){
		
		var isHierarchical = attribute instanceof Statistics.Model.HierarchyAttribute;
		var treeData = {
			title: attribute.name,
			isFolder: isHierarchical,
			key: attribute.id,
			expand: false 
		};
		
		// TODO: check if it should be lazy loaded
		if( isHierarchical ) {
			treeData.children = [];
			for(var i = 0, attr; attr = attribute.childAttributes; ++i)
				treeData.children.push( this._attributeToTreeData(attr) );
		}
		
		return treeData;
	}
});