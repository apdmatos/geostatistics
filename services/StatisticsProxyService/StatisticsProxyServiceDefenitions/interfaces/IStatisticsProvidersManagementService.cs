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
    public interface IStatisticsProvidersManagementService
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "/add",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        int AddProvider(Provider p);

        [OperationContract]
        [WebGet(
            UriTemplate = "/all?pageNumber={pageNumber}&recordsPerPage={recordsPerPage}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        PaginationWrapper<Provider> GetProviders(int pageNumber, int recordsPerPage);
    }
}
