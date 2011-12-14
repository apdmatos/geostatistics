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
		"lib/jQuery/jquery-1.7.1.js",
		"lib/jqplot/jquery.jqplot.min.js",
		"lib/jqplot/jqplot.barRenderer.min.js",
		"lib/jqplot/jqplot.pieRenderer.min.js",
		"lib/jqplot/jqplot.donutRenderer.min.js",
		"statistics/BaseTypes/Class.js",
		"statistics/Events.js",
		"statistics/DimensionsSelector/DimensionSelector.js",
		"statistics/DimensionsSelector/DefaultDimensionSelector.js",
		"statistics/Model/Model.js",
		"statistics/Model/IndicatorMetadata.js",
		"statistics/Model/Dimension.js",
		"statistics/Model/DimensionType.js",
		"statistics/Model/Attribute.js",
		"statistics/Model/HierarchyAttribute.js",
		"statistics/Model/Configuration/Configuration.js",
		"statistics/Model/Configuration/ChartConfig.js",
		"statistics/Model/Configuration/DimensionConfig.js",
		"statistics/Model/RepresentationData/RepresentationData.js",
		"statistics/Model/RepresentationData/DataSerie.js",
		"statistics/Model/RepresentationData/DataSerieValue.js",
		"statistics/Model/RepresentationData/DimensionFilter.js",
		"statistics/Repository/Repository.js",
		"statistics/Repository/Request.js",
		"statistics/Repository/IndicatorRepositoryMock.js",
		"statistics/Repository/StatisticsRepositoryImpl.js",
		"statistics/Repository/EndpointConfiguration/EndpointConfiguration.js",
		"statistics/Representation/Representation.js",
		"statistics/Representation/Chart.js",
		"statistics/Control/Control.js",
		"statistics/Control/Chart.js",
		"statistics/Serializer/Serializer.js",
		"statistics/Serializer/DimensionSerializer.js",
		"statistics/Indicator.js"
	];
	
	var cssFiles = [
		"lib/jqplot/jquery.jqplot.min.css",
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
