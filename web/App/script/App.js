

Statistics.App = {
	
	/**
	 * @public
	 * @property {Statistics,Repository}
	 */
	repository: null,
	
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
	}
	
	
};

jQuery(Statistics.App.init);