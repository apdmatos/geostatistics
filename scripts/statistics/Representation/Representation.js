

Statistics.Representation = Statistics.Class({
	
	/**
	 * @protected
	 * @property {Statistics.Model.IndicatorMetadata}
	 * A reference to indicator metadata, that is being represented
	 */
	indicatorMetadata: null,
	
	/**
	 * @protected
	 * @property {Statistics.Repository}
	 * Contains a repository inplementation to request for statistic data
	 */
	repository: null,
	
	/**
	 * @protected
	 * @property {Array<Statistics.Model.Dimension>}
	 * An array of selected dimensions to request for
	 */
	selectedDimensions: null,
	
	/**
	 * @protected
	 * @property {Statistics.Control}
	 * A control/view to represent this representation
	 */
	control: null,
	
	/**
	 * @constructor
	 * @param {Statistics.Model.IndicatorMetadata} indicatorMetadata
	 * @param {Statistics.Repository} repository
	 * @param {Array<Statistics.Model.Dimension>} selectedDimensions
	 * @param {Statistics.Control} control - The view/control to represent this controller/representation
	 */
	_init: function(indicatorMetadata, repository, selectedDimensions, control) {
		this.indicatorMetadata = indicatorMetadata;
		this.repository = repository;
		this.selectedDimensions = selectedDimensions;
		this.control = control
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.IndicatorMetadata} indicatorMetadata
	 */
	setIndicatorMetadata: function(indicatorMetadata){
		this.indicatorMetadata = indicatorMetadata;
	},
	
	/**
	 * @public
	 * @function
	 * @param {Array<Statistics.Dimension>} dimensions - The selected dimensions
	 */
	setSelectedDimensions: function(dimensions){
		this.selectedDimensions = dimensions;
		this.renderData();
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statuistics.Model.Dimension} axisDimension
	 * 
	 * Sets the dimension to be present on axis
	 */
	setSelectedAxisDimension: function(axisDimension){
		/*Must be implemented by the subclass if needed*/
	},
	
	/**
	 * @public
	 * @function
	 * returns the current selected dimensions
	 */
	getSelectedDimensions: function() {
		return this.selectedDimensions;
	},
	
	/**
	 * @protected
	 * @function
	 * abstract method. Renders the control and requests for data
	 */
	renderData: function() {
		this.control.setLoadingData();
	}
});
