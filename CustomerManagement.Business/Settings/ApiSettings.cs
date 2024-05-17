

using Microsoft.Extensions.Configuration;

namespace CustomerManagement.Business
{

    /// <summary>
    /// Department responsible for api settings
    /// </summary>
    public class ApiSettings : IApiSettings
    {
        public ApiSettings(IConfiguration configuration)
        {
            ApiBaseUrl = configuration.GetSection("ApiSettings").GetValue<string>("ApiBaseUrl");
        }

        public virtual string ApiBaseUrl { get; private set; }

    }
}