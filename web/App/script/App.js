

Statistics.App = {
	
	/**
	 * @public
	 * @property {Statistics,Repository}
	 */
	repository: null,
	
	/**
	 * @public
	 * @property {Statistics.Repository.LazyLoaderAttributeHierarchy}
	 */
	lazyLoader: null,
	
	/**
	 * @Initializer
	 */
	init: function() {
		
		this.repository = 
					new Statistics.Repository.StatisticsRepositoryImpl(
						Statistics.Repository.EndpointConfiguration, 
						new Statistics.Serializer.DimensionSerializer(),
						{
							newIndicatorMetadata: Statistics.Model.IndicatorMetadata.FromObject,
							newIndicatorValuesResult: Statistics.Model.Values.IndicatorValuesResult.FromObject,
							newIndicatorValuesRange: Statistics.Model.Values.IndicatorValuesRange.FromObject,
							newAttribute: Statistics.Model.Attribute.FromObject,
							newSearchResult: Statistics.Model.Search.FromObject,
	 						newIndicator: Statistics.Model.Search.Indicator.FromObject,
	 						newProvider: Statistics.Model.Search.Provider.FromObject
						});
						
		Statistics.App.Wizard.init(this.repository);
	},
	
	/**
	 * A lazy loader object to load attribute hierarchies
	 * @public
	 * @function
	 * @returns {Statistics.Repository.LazyLoaderAttributeHierarchy}
	 */
	getLazyLoader: function() {
		if(!this.lazyLoader)
			this.lazyLoader = new Statistics.Repository.LazyLoaderAttributeHierarchy(this.repository);
			
		return this.lazyLoader; 
	}
	
	
};

jQuery(jQuery.proxy(Statistics.App.init, Statistics.App));