using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Metadata;
using INEProvider.ServiceConfig;

namespace INEProvider.Extensions.INE2Provider 
{
    static class MetadataExtensions
    {
        public static IndicatorMetadata ToIndicatorMetadata(
            this INEProvider.INEService.Metadata metadata, string indicatorId) 
        {
            if(metadata == null) return null;

            List<Dimension> dimensions = new List<Dimension>();

            // temporal and geographic dimensions
            dimensions.Add(metadata.TimeDimension.ToDimension());
            dimensions.Add(metadata.GeoDimension.GeoDimensionToDimension());


            // other dimensions
            int order = Configuration.OTHER_DIMENSIONS_START_ORDER;
            if(metadata.Dimensions != null)
                foreach (var d in metadata.Dimensions)
                    dimensions.Add(d.ToDimension(order++));

            return new IndicatorMetadata
            {
                IndicatorName = metadata.Designation,
                IndicatorNameAbbr = metadata.Abbreviation,
                Dimensions = dimensions,
                SourceURL = metadata.IndicatorUrl,
                LastUpdate = DateTime.Parse(metadata.DataLastUpdate),
                SourceName = Configuration.SOURCE_NAME,
                SourceNameAbbr = Configuration.SOURCE_NAME_ABBR,
                ID = indicatorId
            };
        }

        public static INEService.Dimension GetDimension(this INEProvider.INEService.Metadata metadata, string dimensionId)
        {
            int order = int.Parse(dimensionId);
            if (order == Configuration.GEO_DIMENSION_ORDER)
                return metadata.GeoDimension;

            return metadata.Dimensions[order - Configuration.OTHER_DIMENSIONS_START_ORDER];
        }

    }
}