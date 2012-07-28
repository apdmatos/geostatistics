/**
 *
 * This file is used to include all scripts for debug. When a script or a css is added should 
 * be added to this file, if you want to debug it. Scripts should be added to jsFiles, css to cssFiles.
 * 
 * This script was adapted from OpenLayers.
 * I followed the same strategy.
 */
(function(){
	
	/**
	 * The name of this script to search for.
	 */
	var scriptName = "statistics_debug.js";
	
	/**
     * Namespace: Statistics
     * This object will provide a namespace for all statistics classes 
     */
    window.Statistics = {
			
		/**
		 * @constant {Boolean} singleFile
		 * Indicates that the statistics is being included in release mode. 
		 */
		release: false,
		
		/**
		 * @constant {String} Version
		 * The current statistics lib version
		 */
		Version: 'Alpha 0.1',
				
        /**
         * Method: _getScriptLocation
         * Return the path to this script. This is also implemented in
         * OpenLayers/SingleFile.js
         *
         * Returns:
         * {String} Path to this script
         */
        _getScriptLocation: (function() {
            var r = new RegExp("(^|(.*?\\/))(" + scriptName + ")(\\?|$)"),
                s = document.getElementsByTagName('script'),
                src, m, l = "";
            for(var i=0, len=s.length; i<len; i++) {
                src = s[i].getAttribute('src');
                if(src) {
                    var m = src.match(r);
                    if(m) {
                        l = m[1];
                        break;
                    }
                }
            }
            return (function() { return l; });
        })()
    };
	
	var jsFiles = [
	
		// Extenal
		"lib/jQuery/jquery-1.7.1.js",
		"lib/jquery-ui-1.8.18/js/jquery-ui-1.8.18.custom.min.js",
		"lib/jqplot/jquery.jqplot.min.js",
		"lib/jqplot/jqplot.barRenderer.min.js",
		"lib/jqplot/jqplot.pieRenderer.min.js",
		"lib/jqplot/jqplot.donutRenderer.min.js",
		"lib/jqplot/jqplot.categoryAxisRenderer.min.js",
		"lib/jqplot/jqplot.highlighter.min.js",
		"lib/jqplot/jqplot.pointLabels.min.js",
		"lib/pivotTable/data_vortex.js",
		"lib/pivotTable/pivot_table.js",
		"lib/dynatree-1.2.0/src/jquery.dynatree.js",
		"lib/OpenLayers-2.12/OpenLayers.debug.js",

		// Internal
		"statistics/BaseTypes/Class.js",
		"statistics/BaseTypes/Object.js",
		"statistics/Events.js",
		"statistics/DimensionsSelector/DimensionSelector.js",
		"statistics/DimensionsSelector/DefaultDimensionSelector.js",
		"statistics/Model/Model.js",
		"statistics/Model/IndicatorMetadata.js",
		"statistics/Model/Dimension.js",
		"statistics/Model/DimensionType.js",
		"statistics/Model/Attribute.js",
		"statistics/Model/HierarchyAttribute.js",
		"statistics/Model/Location.js",
		"statistics/Model/AggregationLevel.js",
		"statistics/Model/DimensionsConfig/DimensionConfig.js",
		"statistics/Model/DimensionsConfig/DimensionFilterConfig.js",
		"statistics/Model/DimensionsConfig/DimensionProjectionConfig.js",
		"statistics/Model/DimensionsConfig/ChartSeriesConfig.js",
		"statistics/Model/DimensionsConfig/PivotTableProjectionConfig.js",
		"statistics/Model/DimensionsConfig/ThematicMapProjectionConfig.js",
		"statistics/Model/Filter/DimensionFilter.js",
		"statistics/Model/Values/IndicatorValue.js",
		"statistics/Model/Values/IndicatorValuesResult.js",
		"statistics/Model/Values/IndicatorValuesRange.js",
		"statistics/ConfigurationEditor/ConfigurationEditor.js",
		"statistics/ConfigurationEditor/DimensionsConfigEditor.js",
		"statistics/ConfigurationEditor/PivotTableConfigEditor.js",
		"statistics/ConfigurationEditor/ChartConfigEditor.js",
		"statistics/ConfigurationEditor/SeriesConfigEditor.js",
		"statistics/ConfigurationEditor/ThematicMapConfigEditor.js",
		"statistics/ConfigurationEditor/Updaters/DimensionUpdater.js",
		"statistics/ConfigurationEditor/Updaters/DimensionFilterUpdater.js",
		"statistics/ConfigurationEditor/Updaters/DimensionProjectorUpdater.js",
		"statistics/ConfigurationEditor/Updaters/SerieDimensionUpdater.js",
		"statistics/ConfigurationEditor/Updaters/PivotTableProjectorUpdater.js",
		"statistics/ConfigurationEditor/Updaters/ThematicMapAggregationLevelUpdater.js",
		"statistics/Repository/Repository.js",
		"statistics/Repository/Request.js",
		"statistics/Repository/IndicatorRepositoryMock.js",
		"statistics/Repository/StatisticsRepositoryImpl.js",
		"statistics/Repository/EndpointConfiguration/EndpointConfiguration.js",
		"statistics/Controller/Controller.js",
		"statistics/Controller/ProjectionController.js",
		"statistics/Controller/ThematicMapController.js",
		"statistics/View/View.js",
		"statistics/View/ChartView.js",
		"statistics/View/PieChartView.js",
		"statistics/View/BarChartView.js",
		"statistics/View/PivotTableView.js",
		"statistics/View/MapLayerView.js",
		"statistics/Serializer/Serializer.js",
		"statistics/Serializer/DimensionSerializer.js",
		"statistics/Indicator.js",
		"statistics/i18n/i18n.js",
		"statistics/i18n/pt.js",
		"statistics/ThematicMap/ThematicMap.js",
		"statistics/ThematicMap/ThematicMap.js",
		"statistics/ThematicMap/DimensionSelector.js",
		"statistics/ThematicMap/DimensionSerializer.js",
		"statistics/ThematicMap/IntervalsCalculator/IntervalsCalculator.js",
		"statistics/ThematicMap/IntervalsCalculator/LinearIntervalsCalculator.js",
		"statistics/ThematicMap/Control/Control.js",
		"statistics/ThematicMap/Control/LabelControl.js",
		"statistics/ThematicMap/Layer/Layer.js",
		"statistics/ThematicMap/Layer/DynamicLayer.js",
	];
	
	var cssFiles = [
		// External
		"lib/jqplot/jquery.jqplot.min.css",
		"lib/pivotTable/pivot_table.css",
		"lib/jquery-ui-1.8.18/css/ui-lightness/jquery-ui-1.8.18.custom.css",
		"lib/dynatree-1.2.0/src/skin/ui.dynatree.css",
		"lib/OpenLayers-2.12/theme/default/style.css"
	];
	
	var isIE = (navigator.appName=="Microsoft Internet Explorer");
	var ieVersion = navigator.appVersion;
	if(isIE){
		jsFiles = jsFiles.concat([
			"lib/jqplot/excanvas.min.js"
		]);
	}
	
	function each(array, func){
		for (var i=0, len=array.length; i<len; i++) {
	        func(array[i]); 
	    }
	}
	
	// use "parser-inserted scripts" for guaranteed execution order
    // http://hsivonen.iki.fi/script-execution/
    var includeTags = new Array();
    var host = Statistics._getScriptLocation();
	each(jsFiles, function (element){
		includeTags.push("<script src='" + host + element + "'></script>");
	});
	each(cssFiles, function (element) { 
		includeTags.push("<link rel='stylesheet' type='text/css' href='" + host + element + "'></link>"); 
	});	
		
    if (includeTags.length > 0) {
        document.write(includeTags.join(""));
    }
	
})();
