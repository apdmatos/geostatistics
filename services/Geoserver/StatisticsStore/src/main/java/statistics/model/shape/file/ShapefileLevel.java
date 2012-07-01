package statistics.model.shape.file;

import statistics.model.shape.ShapeLevel;

/**
 *
 * @author Andre Matos
 */
public class ShapefileLevel extends ShapeLevel {

    public String shapefilePath;

    public ShapefileLevel(String shapeCode, String shapefilePath) {
        super(shapeCode);
        this.shapefilePath = shapefilePath;
    }
}
