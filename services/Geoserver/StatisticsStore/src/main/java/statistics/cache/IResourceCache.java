package statistics.cache;

/**
 *
 * @author Andre Matos
 */
public interface IResourceCache {

    /**
     * Methods to add resources to the cahe. If reourcekey already
     * exists in the cache, do nothing
     * @param resourceKey
     * @param resource
     */
    void addResource(String resourceKey, Object resource);

    /**
     * Method to get resource from cache. If resourcekey does not exist, returns null
     * @param resourceKey
     * @return
     */
    Object getResource(String resourceKey);

    /**
     * Method to check if the resource is in cache, and it's
     * not garbage collected
     * @param resourceKey
     * @return
     */
    boolean hasResource(String resourceKey);

    /**
     * Method to remove resource with resourcekey, from the cache.
     * If the resourcekey does not exist, do nothing
     * @param resourceKey
     */
    void removeResource(String resourceKey);

}
