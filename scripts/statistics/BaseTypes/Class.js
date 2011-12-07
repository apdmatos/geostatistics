/**
*   @class
* 	@memberOf Statistics
*   @requires Statistics
*   @requires jQuery
*/


// This Class creation was adapted from OpenLayers class construction
// to support OO programing on javascript


/**
* Constructor: Statistics.Class
* Class used to construct all other classes. Includes support for 
*     multiple inheritance.<br/>
*     
* @example
* To create a new class, use the following syntax:
* var MyClass = Statistics.Class(prototype);
*
* @example
* To create a new class with multiple inheritance, use the following syntax:
* > var MyClass = Statistics.Class(Class1, Class2, prototype);
*
*/
Statistics.Class = function () {

    var Class = function () {

        if (this._init) {
            this._init.apply(this, arguments);
        }

    };

    var extended = {};
    var parent, init;
    for (var i = 0, len = arguments.length; i < len; ++i) {
        
        if (typeof arguments[i] == "function") {
            // make the class passed as the first argument the superclass
            if (i == 0 && len > 1) {
                init = arguments[i].prototype._init;
                // replace the initialize method with an empty function,
                // because we do not want to create a real instance here
                arguments[i].prototype._init = function () { };
                // the line below makes sure that the new class has a
                // superclass
                extended = new arguments[i];
                // restore the original initialize method
                if (init === undefined) {
                    delete arguments[i].prototype._init;
                } else {
                    arguments[i].prototype._init = init;
                }
            }
            // get the prototype of the superclass
            parent = arguments[i].prototype;
        } else {
            // in this case we're extending with the prototype
            parent = arguments[i];
        }

        jQuery.extend(extended, parent);
    }
    Class.prototype = extended;
    return Class;
};