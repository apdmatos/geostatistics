

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
	 * @property {Statistics.Model.Search.Result}
	 */
	result: null,	
	
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
	 * @param {Statistics.Model.Search.Result} result
	 * @param {Statistics.Repository} repository
	 */
	_init: function(result, repository, lazyLoader) {
		this.result = result;
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
				title: this.result.indicator.nameAbbr,
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
			var randomnumber=Math.floor(Math.random() * 10000000);
			var refName = "tab-" + randomnumber;
			
			
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
		
		configDialog.appendTo($(document));
		configDialog .find(".tabs").tabs();
		configDialog.dialog({
			height: 500,
			width: 'auto',
			maxHeight: 500,
			maxWidth: 650,
			autoOpen: false,
			modal: true,
			position: 'top',
			open: function(){
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
	getDialogOptions: function() { },

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @param {Statistics.View} view
	 * @returns {Statistics.Controller}
	 */
	createController: function(config, view) {},

	/**
	 * @protected
	 * @abstract
	 * @param {JQueryElement} element
	 * @returns {Statistics.View}
	 */	
	createView: function(element) {},

	/**
	 * @protected
	 * @abstract
	 * @returns {Statistics.Model.DimensionConfig}
	 */	
	createConfiguration: function() { },

	/**
	 * @protected
	 * @abstract
	 * @param {Statistics.Model.DimensionConfig} config
	 * @returns {Statistics.ConfigurationEditor}
	 */		
	createEditors: function(config) { },
	
	/**
	 * @protected
	 * @function
	 * @abstract
	 * @returns {String[]}
	 */
	getEditorsTabNames: function() { }
});