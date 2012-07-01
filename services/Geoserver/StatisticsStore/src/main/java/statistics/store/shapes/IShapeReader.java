package statistics.store.shapes;

import org.geotools.geometry.jts.ReferencedEnvelope;


/**
 *
 * @author Andre Matos
 */
public interface IShapeReader {

    boolean hasNext();

    IShapeData next();

    void dispose();
}
