using CustomerManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business
{
    public interface ICustomerService
    {
        Task<Customer> ReadById(long id);
        Task<List<Customer>> List();
        Task<CustomerResponse> Create(Customer request);
        Task<CustomerResponse> Update(Customer request);
        Task Delete(long id);
    }
}
