using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.DAO;

namespace distrito7.core.Interfaces
{
    public interface ICustomerService
    {
        Task<Response<SimpleCustomer>> RegisterCustomer(AddCustomer customer);
        Task<Response<SimpleCustomer>> ModifyCustomer(AddCustomer customer);
        Task<Response<string>> DeleteCustomer(string textEncrypted);
        Task<Response<CompleteCustomer>> GetCustomer(string textEncrypted);
    }
}