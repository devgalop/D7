using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Models;

namespace distrito7.core.Interfaces
{
    public interface ICustomerRepository
    {
        Task RegisterCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task<Customer?> GetCustomer(int customerId);
        Task<Customer?> GetCustomerByEmail(string customerEmail);
        Task<List<Customer?>> GetCustomersByRegisteredDate(DateTime dateSelected);
        Task AssignPaymentPlanToCustomer(CustomerPayment paymentPlan);
        Task ModifyCustomerPaymentPlan(CustomerPayment paymentPlan);
        Task RegisterCustomerProgress(CustomerProgress progress);
        Task ModifyCustomerProgress(CustomerProgress progress);
        Task DeleteCustomerProgress(CustomerProgress progress);
    }
}