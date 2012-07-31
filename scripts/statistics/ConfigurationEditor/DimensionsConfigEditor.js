

Statistics.ConfigurationEditor.DimensionsConfigEditor = Statistics.Class(Statistics.ConfigurationEditor, {
	
	/**
	 * @private
	 * @property {Object<string, Jquery.Plugins.Dynatree>} trees
	 */
	trees: null,
	
	/**
	 * @private
	 * @property {Boolean}
	 * Internal property to indicate that the tree is being updated.
	 * The tree change event will fire, are we should do nothing.
	 */
	updatingTree: false,
	
	/**
	 * @private
	 * @property {Function}
	 * This property contains a factory method that returns a LazyLoaderAttributeHierarchy
	 */
	lazyLoaderCreateFunc: null,
	
	/**
	 * @private
	 * @property {Statistics.Repository.LazyLoaderAttributeHierarchy}
	 * Contains a reference to lazyLoaderAttributeHierarchy to load attributes from server
	 */
	lazyLoader: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.DimensionConfig} config - The configuration to set changes on
	 * @param {Statistics.ConfigurationEditor.DimensionUpdater} updater - An object to propagate the changes to configuration.
	 * @param {Function} lazyLoaderCreateFunc - A function that returns a lazyLoaderAttributeHierarchy type
	 */
	_init: function(config, updater, lazyLoaderCreateFunc) {
		
		Statistics.ConfigurationEditor.prototype._init.apply(this, [config, updater]);
		this.lazyLoaderCreateFunc = lazyLoaderCreateFunc;
	},	
	
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
		this.trees = {};
		
		var metadata = this.configuration.getMetadata();
		this.div.append( "<h1>" + metadata.name + "</h1>" );
		for(var i = 0, d; d = metadata.dimensions[i]; ++i)
			this._drawDimension( d );
		
		// register events for listening dimension selection changes, 
		// to update the interface
		this.configuration.events.bind(
			'config::filteredDimensionsChanged', 
			$.proxy(this._updateTreeState, this));
	},
	
	/**
	 * @override
	 * Discard the changes
	 * @public
	 * @function
	 * @returns {Boolean} indicates if anything was discarded
	 */
	discardChanges: function() {
		this._updateTreeState();
		return Statistics.ConfigurationEditor.prototype.discardChanges.apply(this, arguments);
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
	_drawDimension: function(dimension) {
		
		var self = this;
		
		var treeData = [];
		for(var i = 0, attr; attr = dimension.attributes[i]; ++i)
			treeData.push( this._attributeToTreeData(attr, this.configuration.getDimensionById(dimension.id)) );
		
		this.div.append( "<h2>" + dimension.name + "</h2>" );
		this.trees[dimension.id] = 
			$("<div class='tree'></div>").dynatree({
					title: dimension.name,
      				checkbox: true,
      				selectMode: 2,
      				children: treeData,
					autoFocus: false,
      				onSelect: $.proxy(function(select, node) {
						
						if(this.updatingTree) return;
						
						if(select) this.updater.addAttribute(dimension.id, node.data.statsAttr);
						else this.updater.removeAttribute(dimension.id, node.data.statsAttr);
						
      				}, this),
      				onClick: function(node, event) {
        				// We should not toggle, if target was "checkbox", because this
        				// would result in double-toggle (i.e. no toggle)
        				if( node.getEventTargetType(event) == "title" )
          					node.toggleSelect();
      				},
					onLazyRead: function(node) {
						
						var metadata = self.configuration.getMetadata();
						var attribute = node.data.statsAttr;
						var loader = self.getLazyLoadederAttribute();
						
						var configDimension = self.configuration.getDimensionById(dimension.id);
						
						loader.loadAttributes(
							metadata.sourceid,
							metadata.id,
							dimension, 
							attribute,
							attribute.level + 1,
							function(attributes) {
								for(var i = 0, attr; attr = attributes[i]; ++i)
									node.append( self._getAttributeData(attr, configDimension) );
							}
						);
						
						
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
	 * @param {Statistics.Model.Dimension} configDimension
	 */
	_attributeToTreeData: function(attribute, configDimension) {
		
		var isHierarchical = attribute instanceof Statistics.Model.HierarchyAttribute;
		var treeData = this._getAttributeData(attribute, configDimension);
		
		if( isHierarchical ) {
			treeData.children = [];
			for(var i = 0, attr; attr = attribute.childAttributes[i]; ++i)
				treeData.children.push( this._attributeToTreeData(attr, configDimension) );
		}
		
		return treeData;
	},
	
	/**
	 * @private
	 * @param {Statistics.Model.Attribute} attribute
	 * @param {Statistics.Model.Dimension} configDimension
	 * @returns {Object}
	 */
	_getAttributeData: function(attribute, configDimension) {
		var isHierarchical = attribute instanceof Statistics.Model.HierarchyAttribute;
		return {
			title: attribute.name,
			isFolder: isHierarchical,
			key: attribute.id,
			expand: false,
			statsAttr: attribute,
			select: !!configDimension.getAttributeById(attribute.id, true),
			isLazy: isHierarchical && attribute.lazyLoad
		};
	},
	
	/**
	 * @private
	 * @function
	 * updates the tree state. Checks for new selected/unselected nodes
	 */
	_updateTreeState: function() {
		
		this.updatingTree = true;
		for(var dimensionId in this.trees){
			
			var dimension = this.configuration.getDimensionById(dimensionId);
			this.trees[dimensionId].dynatree("getRoot").visit(function(node){
				
				var select = !!dimension.getAttributeById(node.data.statsAttr.id, true);
				node.select(select);
			});
		}
		
		this.updatingTree = false;
	},
	
	/**
	 * @private
	 * @function
	 * @returns {Statistics.Repository.LazyLoaderAttribute}
	 * returns an instance of lazyloader attribute
	 */
	getLazyLoadederAttribute: function() {
		if(!this.lazyLoader)
			this.lazyLoader = this.lazyLoaderCreateFunc();
		
		return this.lazyLoader;
	}
});