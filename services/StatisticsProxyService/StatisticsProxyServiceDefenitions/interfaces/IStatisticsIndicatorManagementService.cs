using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DataStore.Common.Model;
using System.ServiceModel.Web;

namespace StatisticsProxyServiceDefenitions.interfaces
{
    [ServiceContract]
    public interface IStatisticsIndicatorManagementService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/id?providerid={providerid}&indicatorid={indicatorid}",
            ResponseFormat=WebMessageFormat.Json,
            BodyStyle=WebMessageBodyStyle.Bare)]
        Indicator GetIndicatorById(int providerid, int indicatorid);

        [OperationContract]
        [WebGet(
            UriTemplate = "/all?providerid={providerid}&pageNumber={pageNumber}&recordsPerPage={recordsPerPage}",
            ResponseFormat = WebMessageFormat.Json)]
        PaginationWrapper<Indicator> GetIndicators(int providerid, int pageNumber, int recordsPerPage);

        [OperationContract]
        [WebGet(
            UriTemplate = "/all/theme?providerid={providerid}&themeid={themeid}&subthemeid={subthemeid}&pageNumber={pageNumber}&recordsPerPage={recordsPerPage}",
            ResponseFormat = WebMessageFormat.Json)]
        PaginationWrapper<Indicator> GetIndicatorsByThemeId(int providerid, int themeid, int subthemeid, int pageNumber, int recordsPerPage);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/add", 
            Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat=WebMessageFormat.Json,
            BodyStyle=WebMessageBodyStyle.Bare)]
        int AddIndicator(Indicator indicator);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/configuration/add?indicatorid={indicatorid}", 
            Method = "POST", 
            BodyStyle= WebMessageBodyStyle.Bare, 
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int AddConfiguration(int indicatorid, Configuration config);

        [OperationContract]
        [WebGet(
            UriTemplate = "Configuration?providerid={providerid}&indicatorid={indicatorid}",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Configuration> GetIndicatorConfigurations(int providerid, int indicatorid);
    }
}
