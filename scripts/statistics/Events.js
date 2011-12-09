
/**
*    @class Wraps a JQuery events manager
* 	 @memberOf Statistics 
*    @requires Statistics
*    @requires JQuery
*/
Statistics.Events = Statistics.Class ({
	
	/**
	 * @private
	 * @protected
	 * @param {Object} obj
	 * 
	 * The element to register elements on this instance
	 */
	element: null,
	
	_init: function(obj) {
		this.element = obj || document;
	},
	
    /**
     *   Attach a handler to an event for the elements.
     *   @function 
     *   @param {string} eventType A string containing one or more space-separated JavaScript event types.
     *   @param {function} handler A function to execute each time the event is triggered.
     */
    bind: function (eventType, handler) {
        Statistics.Events.bind(eventType, handler, this.element);
    },

    /**
     *   Remove a previously-attached event handler to an event from the elements.
     *   @function 
     *   @param {string} eventType A string containing a JavaScript event type.
     *   @param {function} [handler] The function that is to be no longer executed.
     */
    unbind: function (eventType, handler) {
		Statistics.Events.unbind(eventType, handler, this.element);
    },
   
    /**
     *   Execute all handlers and behaviors attached to the matched elements for the given event type.
     *   @function 
     *   @param {string} eventType A string containing a JavaScript event type.
     *   @param {Object[]} [params='[]'] An array of additional parameters to pass along to the event handler. 
     */
    trigger: function (eventType, params) {
        return Statistics.Events.trigger(eventType, params, this.element);
    },

    /**
     *   Execute all handlers attached to an element for an event.
     *   @p This method does not cause the default behavior of an event to occur.
     *   @p Only affects the first matched element.
     *   @p The event do not bubble up the DOM hierarchy.
     *   @function 
     *   @param {string} eventType A string containing a JavaScript event type.
     *   @param {Object[]} [params='[]'] An array of additional parameters to pass along to the event handler. 
     */
    triggerhandler: function (eventType, params) {	
		return Statistics.Events.triggerhandler(eventType, params, this.element);
    }
});

/**
 * @static
 * @function
 * @param {string} eventType A string containing one or more space-separated JavaScript event types.
 * @param {function} handler A function to execute each time the event is triggered.
 * @param {Object} [context='document'] The object to attach the event.
 * 
 * Attach a handler to an event for the elements.
 */
Statistics.Events.bind = function (eventType, handler, context) {
	context = context || document;
    $(context).bind(eventType, handler);
};

/**
 * @static
 * @function 
 * @param {string} eventType A string containing a JavaScript event type.
 * @param {function} [handler] The function that is to be no longer executed.
 * @param {object} [context='document'] The object to unbind.
 * 
 * Remove a previously-attached event handler to an event from the elements.
 * 
 */
Statistics.Events.unbind = function (eventType, handler, context) {
    context = context || document;
    $(context).unbind(eventType, handler);
};

/**
 * @static
 * @function 
 * @param {string} eventType A string containing a JavaScript event type.
 * @param {Object[]} [params='[]'] An array of additional parameters to pass along to the event handler.
 * @param {object} [context='document'] The object to trigger the event.
 * 
 *  Execute all handlers and behaviors attached to the matched elements for the given event type.
 */
Statistics.Events.trigger = function (eventType, params, context) {
    params = params || [];
    context = context || document;
    $(context).trigger(eventType, params);
    if (context != document) {
        $(document).trigger(eventType, params);
    }
    return $(context);
};

/**
 * @static
 * @function 
 * @param {string} eventType A string containing a JavaScript event type.
 * @param {Object[]} [params='[]'] An array of additional parameters to pass along to the event handler.
 * @param {object} [context='document'] The object to trigger the event.
 * 
 * @p This method does not cause the default behavior of an event to occur.
 * @p Only affects the first matched element.
 * @p The event do not bubble up the DOM hierarchy.
 * 
 *  Execute all handlers attached to an element for an event.
 */
Statistics.Events.triggerhandler = function (eventType, params, context) {
    params = params || [];
    context = context || document;
    $(context).triggerhandler(eventType, params);
    if (context != document) 
        $(document).triggerhandler(eventType, params);
};


