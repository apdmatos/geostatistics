

Statistics.IndicatorSelectionChooser.StepChooser.PaginationStepChooser = 
	Statistics.Class(Statistics.IndicatorSelectionChooser.StepChooser, 
{

	/**
	 * Contains the number of records to present in each page
	 * @private
	 * @property {Integer}
	 */
	resultsPerPage: 10,
	
	/**
	 * The number of pages to being shown at the same time
	 * @private
	 * @property {Integer}
	 */
	pagesToShow: 5,
	
	/**
	 * @private
	 * @property {Statistics.Model.Search}
	 */
	searchResult: null,

	/**
	 * @private
	 * @property {Function}
	 */	
	reloadFunc: null,

	/**
	 * @constructor
	 * @param {Statistics.Repository} repository
	 */
	_init: function(repository) {
		Statistics.IndicatorSelectionChooser.StepChooser.prototype._init.apply(this, arguments);
		this.reloadFunc = jQuery.proxy(this.reload, this);
	},
	
	/**
	 * Cleans the step and sets the result to be filled on
	 * Called to turn the step visible
	 * @public
	 * @function
	 */
	setResult: function(prevResult) {
		Statistics.IndicatorSelectionChooser.StepChooser.prototype.setResult.apply(this, arguments);
		this.clearResults();
		this.requestResults(1);
	},	


/**********************************************************************************
 * ********************************************************************************
 * Protected methods
 **********************************************************************************
 **********************************************************************************/	
	
	/**
	 * @private
	 * @function
	 * @param {Integer} page
	 */
	reload: function() {
		this.clearResults();
		this.requestResults(1);
	},
	
	/**
	 * Requests results for the current page
	 * @abstract
	 * @protected
	 * @function
	 * @param {Integer} page
	 */
	requestResults: function(page) {
		/*must be defined by each subclass*/	
	},
	
	/**
	 * called when an element in the list is selected
	 * @abstract
	 * @protected
	 * @function
	 * @param {Object} element
	 */
	elementSelected: function(element) {
		/*must be defined by each subclass*/
	},
	
	/**
	 * Renders the results here
	 * @protected
	 * @function
	 * @param {Statistics.Model.Search} searchResult
	 */
	renderSearchResults: function(searchResult) {
		
		this.searchResult = searchResult;
		this.clearResults();
		
		var ul = $("<ul></ul>"); 
		this.div.append(ul);
		
		for(var i = 0, elem; elem = searchResult.elements[i]; ++i) {
			this.drawElement(ul, elem);
		}
		
		this.drawPages();
	},
	
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/	
	
	/**
	 * Draws
	 * @public
	 * @function
	 * @param {JQueryElement} ul
	 * @param {Statistics.Model.Search.Result} element
	 */
	drawElement: function(ul, element) {
		var self = this;
		var elem = $("<li>" + element.getText() + "</li>");
		ul.append(elem);
		elem.click(function() { 
			elem.parent().find('li').removeClass('statistics_search_item_selected');
			elem.addClass('statistics_search_item_selected');
			self.elementSelected(element);
		});
	},
	
	/**
	 * Draws html page links and write them into the div placeholder
	 * @private
	 * @function
	 */
	drawPages: function() {
		
		var totalPages 	= this.searchResult.getNumberOfPages();
		var startPage 	= this.searchResult.page - Math.floor(this.pagesToShow / 2);
		var endPage 	= this.searchResult.page + Math.floor(this.pagesToShow / 2);
		
		if (endPage > totalPages) endPage = totalPages;
		if(startPage < 1) startPage = 1;
		
		if((endPage - startPage + 1) < this.pagesToShow && totalPages >= this.pagesToShow){
			if(startPage <= Math.floor(this.pagesToShow / 2)){
				endPage += this.pagesToShow - endPage;
			}else if(endPage >= totalPages - Math.floor(this.pagesToShow / 2)){
				startPage -= this.pagesToShow - (endPage - startPage + 1);
			}
		}
		
		var pagesElem = $("<div class='pagination'></div>");
		this.div.append(pagesElem);
		for(var i = startPage; i <= endPage; ++i) 
			this.drawPage(pagesElem, i);
		
	},
	
	/**
	 * @private
	 * @function
	 * @param {JQueryElement} pagesDiv
	 * @param {Integer} page
	 */
	drawPage: function(pagesDiv, page) {
		
		var self = this;
		
		var pageElement = $("<span class='page'>" + page + "</span>")
		pagesDiv.append(pageElement);
		pageElement.click(function() {
			self.requestResults(page);
		});
	},
	
	/**
	 * Removes all results from the panel
	 * @private
	 * @function
	 */
	clearResults: function() {
		this.div.empty();
	}
});