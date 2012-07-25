package statistics.cache;

import java.lang.ref.WeakReference;
import java.util.Hashtable;

/**
 *
 * @author Andre Matos
 */
public final class InProcessCache implements IResourceCache {

    /**
     * Resource cahce
     * Hashtable<WeakReference, Object>
     */
    private static final Hashtable _cache;

    static {
        _cache = new Hashtable();
    }

    /**
     * Methods to add resources to the cahe. If reourcekey already
     * exists in the cache, do nothing
     * @param resourceKey
     * @param resource
     */
    @Override
    public void addResource(String resourceKey, Object resource)
    {
        synchronized(InProcessCache.class) {
            if(!hasResource(resourceKey)) {
                WeakReference weak = new WeakReference(resource);
                _cache.put(resourceKey, weak);
            }
        }
    }

    /**
     * Method to remove resource with resourcekey, from the cache.
     * If the resourcekey does not exist, do nothing
     * @param resourceKey
     */
    @Override
    public void removeResource(String resourceKey)
    {
        synchronized(InProcessCache.class) {
            if(hasResource(resourceKey)) {
               _cache.remove(resourceKey);
            }
        }
    }

    /**
     * Method to get resource from cache. If resourcekey does not exist, returns null
     * @param resourceKey
     * @return
     */
    @Override
    public Object getResource(String resourceKey)
    {
        synchronized(InProcessCache.class) {
            if(!hasResource(resourceKey)) {
                return null;
            }

            WeakReference reference = (WeakReference)_cache.get(resourceKey);
            return reference.get();
        }
    }

    /**
     * Method to check if the resource is in cache, and it's
     * not garbage collected
     * @param resourceKey
     * @return
     */
    @Override
    public boolean hasResource(String resourceKey)
    {
        synchronized(InProcessCache.class) {
            WeakReference reference = (WeakReference)_cache.get(resourceKey);
            //check if the reference is not null
            if(reference != null){
                    // if the reference is not null, check if the object was not
                    // garbage collected. If it was, remove the reference from the cache,
                    // otherwise, return true
                    if(reference.get() != null) return true;
                    else _cache.remove(resourceKey);
            }

            // The reference is not in cache
            return false;
        }
    }

}
