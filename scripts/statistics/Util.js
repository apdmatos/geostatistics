

/**
 * Property: lastSeqID
 * {Integer} The ever-incrementing count variable.
 *           Used for generating unique ids.
 */
Statistics.Util.lastSeqID = 0;

/**
 * Function: createUniqueID
 * Create a unique identifier for this session.  Each time this function
 *     is called, a counter is incremented.  The return will be the optional
 *     prefix (defaults to "id_") appended with the counter value.
 * 
 * Parameters:
 * prefix - {String} Optional string to prefix unique id. Default is "id_".
 * 
 * Returns:
 * {String} A unique id string, built on the passed in prefix.
 */
Statistics.Util.createUniqueID = function(prefix) {
    if (prefix == null) {
        prefix = "id_";
    }
    Statistics.Util.lastSeqID += 1; 
    return prefix + Statistics.Util.lastSeqID;        
};