

Statistics.Repository.Request = Statistics.Class(
{
	
	/**
	 * @property {jqXHR} _jqueryXHR
	 * The object returned by jquery.ajax 
	 */
    _jqueryXHR: null,

	/**
	 * @property {Boolean} _canceled
	 * Indicates if the ajax request was canceled or not
	 */
    _canceled: false,

	/**
	 * @constructor
	 * @param {jqXHR} jqueryXHR - The jquery.ajax returned value. Will be used to cancel the request 
	 */
    _init: function (jqueryXHR) {

        this._jqueryXHR = jqueryXHR;

    },
	
	/**
	 * @public
	 * @function
	 * This method can be used to cancel a request
	 */
    cancelRequest: function () {
        this._canceled = true;
        this._jqueryXHR.abort();
    },

	/**
	 * @public
	 * @function
	 * @returns {Boolean} true if the request was canceled or not
	 */
    isCanceled: function () {
        return this._canceled;
    },

	/**
	 * @public
	 * @function
	 * @returns {jqXHR} the xhr object used to request the resource
	 */
    getXHR: function () {
        return this._jqueryXHR;
    }

});