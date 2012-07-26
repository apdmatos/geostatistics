using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common.Model;

namespace INEDownloadIndicators
{
    class ExtendedTheme : Theme
    {
        public string SourceThemeCode { get; set; }
    }

    class ExtendedSubTheme : SubTheme
    {
        public string SourceThemeCode { get; set; }
    }
}
