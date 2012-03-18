using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Metadata;
using INEProvider.ServiceConfig;
using INEProvider.Model;
using INEProvider.Helpers;

namespace INEProvider.Extensions.INE2Provider
{
    static class DimensionExtension
    {
        /// <summary>
        /// Conversts temporal Dimension and its categories to a Dimension
        /// </summary>
        /// <param name="ineDimension"></param>
        /// <returns></returns>
        public static Dimension ToDimension(this INEService.TimeDimension ineDimension)
        {
            List<DimensionAttribute> attributes = new List<DimensionAttribute>();
            foreach (var period in ineDimension.Periods)
            {
                DimensionAttribute attr = period.ToDimensionAttribute();
                attributes.Add(attr);
            }

            return new Dimension
            {
                //ID = ineDimension.Code,
                ID = Configuration.TIME_DIMENSION_ORDER.ToString(),
                DimensionType = DimensionType.Temporal,
                Name = ineDimension.Designation,
                NameAbbr = ineDimension.Abbreviation,
                //ServerContextData = Configuration.TIME_DIMENSION_ORDER,
                Attributes = attributes
            };
        }

        /// <summary>
        /// Converts a Georaphic dimension to a dimension. 
        /// Will request its attributes to convert to a DimensionAttributes with a hierarchy
        /// </summary>
        /// <param name="ineDimension"></param>
        /// <returns></returns>
        public static Dimension GeoDimensionToDimension(
            this INEService.Dimension ineDimension) 
        {
            Dimension d = ineDimension.ToDimension(Configuration.GEO_DIMENSION_ORDER, DimensionType.Geographic);
            List<DimensionAttribute> attributes = new List<DimensionAttribute>();

            // build geoAttribute configuration
            List<GeoAttributeConfiguration> configuration = new List<GeoAttributeConfiguration>();
            for (int i = 2; i <= ineDimension.LowestClassificationLevel; ++i)
			{
                GeographicLevels level = (GeographicLevels)i;

                configuration.Add(new GeoAttributeConfiguration {
                    ID = level.ToString(),
                    Name = INEServiceHepers.GetGeographicLevelName(level),
                    Level = (int)level
                });

			}

            // add attribute
            d.AddAttribute(new GeoAttributeHierarchy { 
                ID = "PT",
                Name = "Portugal",
                Configuration = configuration
            });
            return d;
        }

        /// <summary>
        /// Converts a common INE Dimension and its categories to a Dimension and DimensionAttributes.
        /// </summary>
        /// <param name="ineDimension"></param>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dimension ToDimension(this INEService.Dimension ineDimension, int order, DimensionType type = DimensionType.Other) 
        {
            // build dimensions hierarchy
            List<DimensionAttribute> attributes = new List<DimensionAttribute>();
            if (ineDimension.Categories != null) {

                // iterate through all hierarchy levels
                for (int hierarchyLevel = 1; hierarchyLevel <= ineDimension.LowestClassificationLevel; ++hierarchyLevel)
                {
                    // for each hierarchy level, get the categories from that level
                    IEnumerable<INEService.Category> categories = ineDimension.Categories.Where(c => c.Level == hierarchyLevel);
                    foreach (var category in categories)
                    {
                        // check if this category has other categories inside. check ParentCategoryId from all categories
                        bool hierarchy = ineDimension.Categories.Where(c => c.ParentCategoryCode == category.Code).FirstOrDefault() != null;
                        DimensionAttribute attribute = category.ToDimensionAttribute(hierarchy);

                        // Add categories to hierarchy. 
                        // If does not have ParentCategory its a root, otherwise, find the parent category and add it to hierarchy.
                        if (string.IsNullOrEmpty(category.ParentCategoryCode))
                            attributes.Add(attribute);
                        else
                        {
                            HierarchyAttribute attrHierarchy = (HierarchyAttribute)attributes.Where(a => a.ID == category.ParentCategoryCode).FirstOrDefault();
                            attrHierarchy.AddAttribute(attribute);
                        }
                            
                    }
                }
            }
            
            return new Dimension { 
                //ID = ineDimension.Code,
                ID = order.ToString(),
                DimensionType = type,
                Name = ineDimension.Designation,
                NameAbbr = ineDimension.Abbreviation,
                //ServerContextData = order,
                Attributes = attributes
            };
        }
    }
}