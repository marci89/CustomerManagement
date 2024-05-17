using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business
{

    /// <summary>
    /// Interface describing api settings
    /// </summary>
    public interface IApiSettings
    {
        /// <summary>
        /// Url for Api
        /// </summary>
        string ApiBaseUrl { get; }
    }
}