package statistics.factory;

import java.net.MalformedURLException;
import java.util.List;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
import org.opengis.feature.simple.SimpleFeatureType;
import statistics.db.ShapeConfigRepository;
import statistics.model.indicator.IndicatorConfiguration;
import statistics.model.indicator.IndicatorRange;
import statistics.model.shape.ShapeConfiguration;
import statistics.model.shape.file.ShapefileConfiguration;
import statistics.queryparser.StatisticsRequestParameters;
import statistics.store.feature.builders.FeatureBuilder;
import statistics.store.feature.builders.LinearFactFeatureBuilder;
import statistics.store.service.FakeStatisticsServeProxy;
import statistics.store.service.IStatisticsServiceProxy;
import statistics.store.service.StatisticsServiceProxyImpl;
import statistics.store.shapes.IShapeConfigRepository;
import statistics.store.shapes.IShapeRepository;
import statistics.store.shapes.shapefile.ShapefileRepository;

/**
 *
 * @author Andre Matos
 */
public final class StatisticsFactory {

    static ThreadPoolExecutor threadpool_io;

    public static IShapeRepository getShapeRepository(ShapeConfiguration shapeConfig){

        if(shapeConfig instanceof ShapefileConfiguration)
            return new ShapefileRepository((ShapefileConfiguration)shapeConfig);

        return null;

    }

    public static IShapeConfigRepository getShapeConfigRepository() {
        return new ShapeConfigRepository();
    }

    public static IStatisticsServiceProxy getProxyService(String serviceURL, IndicatorConfiguration config, List<String> shapeIds) throws MalformedURLException {

        //return new FakeStatisticsServeProxy();
        return new StatisticsServiceProxyImpl(serviceURL, getThreadPool(), config, shapeIds);
    }

    public static FeatureBuilder getFeatureBuilder(SimpleFeatureType featureType, IndicatorRange range, StatisticsRequestParameters query) {

        return new LinearFactFeatureBuilder(featureType, range, query);
    }

    private static ThreadPoolExecutor getThreadPool() {

        synchronized(StatisticsFactory.class) {

            if(threadpool_io == null) {

                BlockingQueue<Runnable> queue = new ArrayBlockingQueue<Runnable>(100, true);
                threadpool_io = new ThreadPoolExecutor(
                    50, // core size
                    100, // max size
                    1, // keep alive time
                    TimeUnit.MINUTES, // keep alive time units
                    queue // the queue to use
                );
            }

            return threadpool_io;
        }
    }

}
