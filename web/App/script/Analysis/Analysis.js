

Statistics.App.Analysis = Statistics.Class({
	
	/**
	 * The view
	 * @public
	 * @property {Statistics.View}
	 */
	view: null,

	/**
	 * The controller
	 * @public
	 * @property {Statistics.Controller}
	 */	
	controller: null,
	
	/**
	 * The configuration editors
	 * @public
	 * @property {Statistics.ConfigurationEditor[]}
	 */	
	editors: null,
	
	/**
	 * The view configuration
	 * @public
	 * @property {Statistics.Model.DimensionConfig}
	 */
	config: null,
	
	/**
	 * The repository to request data from
	 * @public
	 * @property {Statistics.Repository}
	 */
	repository: null,
	
	/**
	 * @public
	 * @property {Statistics.Repository.LazyLoader}
	 */
	lazyLoader: null,

	/**
	 * @public 
	 * @property {Statistics.Model.Provider}
	 */
	provider: null,
	
	/**
	 * @public 
	 * @property {Statistics.Model.Indicator}
	 */
	indicator: null,	
	
	/**
	 * @public
	 * @property
	 * @param {JQueryElement} dialog
	 */
	dialog: null,

	/**
	 * @public
	 * @property
	 * @param {JQueryElement} dialog
	 */	
	optionsDialog: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.Provider} provider
	 * @param {Statistics.Model.Indicator} indicator
	 * @param {Statistics.Repository} repository
	 * @param {Statistics.Repository.LazyLoaderAttributeHierarchy} repository
	 */
	_init: function(provider, indicator, repository, lazyLoader) {
		this.provider = provider;
		this.indicator = indicator;
		this.repository = repository;
		this.lazyLoader = lazyLoader;
	},
	
	/**
	 * @public
	 * @function
	 */	
	createWindow: function() {
		
		var representationElement = this.getDialogHtml();
		
		this.config = this.createConfiguration();
		this.editors = this.createEditors( this.config );
		this.view = this.createView( representationElement );
		this.controller = this.createController( this.config, this.view );
		
		this._createConfigurationDialog(this.editors);
		this._createMainDialog(representationElement, this.optionsDialog);
	},

/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * returns the lazy loader instance
	 * @private
	 * @function
	 * @returns {Statistics.Repository.LazyLoaderAttributeHierarchy}
	 */
	getLazyLoader: function() {
		return this.lazyLoader;
	},
	
	/**
	 * @private
	 * @function
	 * @param {JQueryElement} dialogHtml
	 * @param {JQueryElement} configurationDialog
	 */
	_createMainDialog: function(dialogHtml, configurationDialog) {
		
		// main dialog
		var dialogOptions = jQuery.extend(
			{
				position: 'center',
				height: 500,
				width: 400,
				minWidth: 300,
				minHeight: 300,
				title: this.indicator.nameAbbr,
				buttons: [
					{
						text: 'Opções',
						'class': 'config',
						click: function(){
							configurationDialog.dialog('open');
						}
					}
				]
			},
			this.getDialogOptions()
		);
		dialogHtml.dialog(dialogOptions);
		this.dialog = dialogHtml;
	},
	
	/**
	 * Draws the configuration modal box
	 * @private
	 * @function
	 * @param {Statistics.ConfigurationEditor[]} editors
	 */
	_createConfigurationDialog: function(editors) {

		var configDialog = $("<div class='config dialog hide'>"
							+ "<div class='tabs'>"
				 				+ "<ul></ul>"
							+ "</div>"
					 + "</div>");
		this.optionsDialog = configDialog;
		var tabNames = this.getEditorsTabNames();
		var editorObjs = [];
		
		for(var i = 0, tab; tab = tabNames[i]; ++i) {
			var id = Statistics.Util.createUniqueID();
			var refName = "tab-" + id;
			
			
			var li = $("<li><a href='#" + refName + "'>" + tab + "</a></li>");
			var content = $("<div class='tabcontent' id='" + refName + "'></div>");
			
			editorObjs.push({
				tabContent: content,
				editor: editors[i],
				tabName: tabNames[i]			
			});
			
			configDialog .find('ul').append(li);
			configDialog .find('.tabs').append(content);
		}
		
		
		function resizeTabContent(configElement) {
			var h = $(configElement).height() - 
					$(configElement).find('.tabcontent').filter(':visible').position().top - 
					$(configElement).find('ul').position().top - 
					$(configElement).find('ul').height();
					
			var w = $(configElement).width() - 
					$(configElement).find('.tabcontent').filter(':visible').position().left - 
					$(configElement).find('ul').position().left - 
					$(configElement).find('ul').position().right;		
			
			$(configElement).find('.tabcontent').filter(':visible').css({
				width: w,
				height: h
			});
		}
		
		configDialog.appendTo($(document));
		configDialog .find(".tabs").tabs({
			select: function(event, ui) {
				resizeTabContent($(this).parent());
			}
		});
		configDialog.dialog({
			height: 500,
			width: 630,
			minWidth: 630,
			minHeight: 200,
			autoOpen: false,
			modal: true,
			position: 'top',
			resize: function(event, ui) {
				resizeTabContent(this);
			},
			open: function(){
				resizeTabContent(configDialog);
				$(editorObjs).each(function(idx, tabObj){
					if(!tabObj.editor.isDrawn())
						tabObj.editor.draw(tabObj.tabContent);
				});
			},
			close: function(){
				$(editorObjs).each(function(idx, tabObj){
					tabObj.editor.discardChanges();
				});
			},
			buttons: [
				{
					text: "Ok",
					click: function() {
						
						$(editorObjs).each(function(idx, tabObj){
							tabObj.editor.applyChanges();
						});

						configDialog.dialog('close');
					}
				},
				{
					text: "Cancelar",
					click: function(){
						$(editorObjs).each(function(idx, tabObj){
							tabObj.editor.discardChanges();
						});
						configDialog.dialog('close');
					}
				}
			]
		});
		
		return configDialog;
	},

/**********************************************************************************
 * ********************************************************************************
 * Protected methods
 **********************************************************************************
 **********************************************************************************/
	
	/**
	 * @protected
	 * @abstract
	 * @returns {JQueryElement}
	 */
	getDialogHtml: function() {
		return $("<div></div>");
	},

	/**
	 * Overrides default dialog options
	 * @protected
	 * @abstract
	 * @returns {Object}
	 */
	getDialogOptions: function() { /* abstract method. should be defined by each subclass */ },

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @param {Statistics.View} view
	 * @returns {Statistics.Controller}
	 */
	createController: function(config, view) { /* abstract method. should be defined by each subclass */ },

	/**
	 * @protected
	 * @abstract
	 * @param {JQueryElement} element
	 * @returns {Statistics.View}
	 */	
	createView: function(element) { /* abstract method. should be defined by each subclass */ },

	/**
	 * @protected
	 * @abstract
	 * @returns {Statistics.Model.DimensionConfig}
	 */	
	createConfiguration: function() { /* abstract method. should be defined by each subclass */ },

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @returns {Statistics.ConfigurationEditor}
	 */		
	createEditors: function(config) { /* abstract method. should be defined by each subclass */ },
	
	/**
	 * @protected
	 * @function
	 * @abstract
	 * @returns {String[]}
	 */
	getEditorsTabNames: function() { /* abstract method. should be defined by each subclass */ }
});