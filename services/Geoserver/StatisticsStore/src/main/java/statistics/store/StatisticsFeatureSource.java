package statistics.store;

import java.io.IOException;
import org.geotools.data.FeatureReader;
import org.geotools.data.Query;
import org.geotools.data.store.ContentEntry;
import org.geotools.data.store.ContentFeatureSource;
import org.geotools.geometry.jts.ReferencedEnvelope;
import org.opengis.feature.simple.SimpleFeature;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.factory.StatisticsFactory;
import statistics.model.shape.ShapeConfiguration;
import statistics.queryparser.StatisticsQueryParser;
import statistics.store.shapes.IShapeConfigRepository;
import statistics.store.shapes.IShapeReader;
import statistics.store.shapes.IShapeRepository;

/**
 *
 * @author Andre Matos
 */
public class StatisticsFeatureSource extends ContentFeatureSource {

    private FeatureBuilder _featureBuilder;

    public StatisticsFeatureSource(ContentEntry entry, Query query) {
        super(entry, query);
        _featureBuilder = new FeatureBuilder(entry.getName());
    }

    @Override
    protected ReferencedEnvelope getBoundsInternal(Query query) throws IOException {

        StatisticsQueryParser parser = new StatisticsQueryParser( query, buildFeatureType() );
        return getShapeRepository(parser).getBounds(
                parser.getSourceId(),
                parser.getIndicatorId(),
                parser.getShapeLevel(),
                parser.getBoundingBox(),
                parser.getShapeIds()
        );
    }

    @Override
    protected int getCountInternal(Query query) throws IOException {

        StatisticsQueryParser parser = new StatisticsQueryParser( query, buildFeatureType() );
        return getShapeRepository(parser).countShapes(
                parser.getSourceId(),
                parser.getIndicatorId(),
                parser.getShapeLevel(),
                parser.getBoundingBox(),
                parser.getShapeIds()
        );
    }

    @Override
    protected FeatureReader<SimpleFeatureType, SimpleFeature> getReaderInternal(Query query) throws IOException {

        StatisticsQueryParser parser = new StatisticsQueryParser( query, buildFeatureType() );
        IShapeReader shapes = getShapeRepository(parser).getShapes(
                parser.getSourceId(),
                parser.getIndicatorId(),
                parser.getShapeLevel(),
                parser.getBoundingBox(),
                parser.getShapeIds()
        );
        
        return new StatisticsFeatureReader(entry, shapes, _featureBuilder);
    }

    @Override
    protected SimpleFeatureType buildFeatureType() throws IOException {
        return _featureBuilder.getFeatureType(  );
    }

    private IShapeRepository getShapeRepository(StatisticsQueryParser parser) {
        
        IShapeConfigRepository configShapeRepo = StatisticsFactory.getShapeConfigRepository();
        ShapeConfiguration config =  configShapeRepo.getShapeConfiguration(parser.getSourceId(), parser.getIndicatorId(), parser.getShapeLevel());
        return StatisticsFactory.getShapeRepository(config);
        
    }
}
