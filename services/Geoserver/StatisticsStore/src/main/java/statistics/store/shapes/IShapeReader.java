package statistics.store.shapes;

/**
 *
 * @author Andre Matos
 */
public interface IShapeReader {

    boolean hasNext();

    IShapeData next();

    void dispose();
}
