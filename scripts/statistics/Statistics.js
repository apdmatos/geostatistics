
var Statistics = {
	
	/**
	 * @constant {Boolean} release
	 * Indicates that the statistics is being included in release mode. 
	 */
	release: true,
	
	/**
	 * @constant {String} Version
	 * The current statistics lib version
	 */
	Version: 'Alpha 0.1',
	
	/**
     * Method: _getScriptLocation
     * Return the path to this script. This is also implemented in
     * statistics_debug.js
     *
     * Returns:
     * {String} Path to this script
     */
    _getScriptLocation: (function() {
        var r = new RegExp("(^|(.*?\\/))(Statistics.min\.js)(\\?|$)"),
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


