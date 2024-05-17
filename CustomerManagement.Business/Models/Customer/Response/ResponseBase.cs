using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Models
{
    /// <summary>
    /// Response base class that helps send the correct objectto the client
    /// and send correct error messages if that has any
    /// </summary>
    public class ResponseBase
    {



        /// <summary>
        /// Returning error message
        /// </summary>
        public  string ErrorMessage { get; set; }
     

        /// <summary>
        /// Has error check
        /// </summary>
        public  bool HasError { get; set; }
    }
}

