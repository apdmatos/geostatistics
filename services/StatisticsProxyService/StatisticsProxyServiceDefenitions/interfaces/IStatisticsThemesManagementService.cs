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
    public interface IStatisticsThemesManagementService
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "/add",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        int AddTheme(Theme theme);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/add/subtheme",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        int AddSubTheme(SubTheme subtheme);

        [OperationContract]
        [WebGet(
            UriTemplate = "/all?providerid={providerid}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Theme> GetThemes(int providerid);

        [OperationContract]
        [WebGet(
            UriTemplate = "/all/subtheme?providerid={providerid}&themeid={themeid}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<SubTheme> GetSubThemes(int providerid, int themeid);
    }
}
