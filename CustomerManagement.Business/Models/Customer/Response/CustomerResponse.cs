using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Models
{
    /// <summary>
    /// Create customer response
    /// </summary>
    public class CustomerResponse : ResponseBase
    {
        public Customer Result { get; set; }
    }
}
