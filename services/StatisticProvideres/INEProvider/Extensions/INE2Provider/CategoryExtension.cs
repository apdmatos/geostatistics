using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Metadata;

namespace INEProvider.Extensions.INE2Provider
{
    delegate DimensionAttribute CategoryFunc<T>(T category);

    static class CategoryExtension
    {
        public static IEnumerable<DimensionAttribute> ToDimensionAttributeEnumerable<T>(this IEnumerable<T> categories, CategoryFunc<T> func)
        {
            foreach (var category in categories)
            {
                yield return func(category);
            }

            yield break;
        }

        public static DimensionAttribute ToDimensionAttribute(this INEService.Category category, bool hierarchical) 
        {
            if (hierarchical)
                return new HierarchyAttribute
                {
                    ID = category.Code,
                    Name = category.Designation
                };

            return new DimensionAttribute { 
                ID = category.Code,
                Name = category.Designation
            };
        }

        public static DimensionAttribute ToDimensionAttribute(this INEService.Period period) 
        {    
            return new DimensionAttribute 
            { 
                ID = period.Code,
                Name = period.Designation
            };
        }

    }
}