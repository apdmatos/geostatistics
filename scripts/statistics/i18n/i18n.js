
/**
 * @function
 * @param {String} key
 * @returns {String}
 * Returns the resource string on the current language
 */
Statistics.i18n = function (key) {

    return Statistics.i18n[Statistics.i18n.currentLang][key];

}

/**
 * @memberOf Statistics.i18n
 * @property {String} currentLang 
 * Represents the current language to read the resources and fill the user interface.
 */
GIS.i18n.currentLang = 'pt';