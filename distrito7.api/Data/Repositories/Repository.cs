using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Interfaces;
using distrito7.core.Models;

namespace distrito7.api.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;
        
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }
        
        public async Task AddMeasurement(AnthropometricMeasurements measurement)
        {
            _dataContext.AnthropometricMeasurements.Add(measurement);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddPlan(PaymentPlan plan)
        {
            _dataContext.PaymentPlans.Add(plan);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AssignPaymentPlanToCustomer(CustomerPayment paymentPlan)
        {
            _dataContext.CustomerPayments.Add(paymentPlan);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerProgress(CustomerProgress progress)
        {
            _dataContext.CustomerProgresses.Remove(progress);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteMeasurement(AnthropometricMeasurements measurement)
        {
            _dataContext.AnthropometricMeasurements.Remove(measurement);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePlan(PaymentPlan plan)
        {
            _dataContext.PaymentPlans.Remove(plan);
            await _dataContext.SaveChangesAsync();
        }

        public Task<List<AnthropometricMeasurements?>> GetAllMeasurements()
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentPlan?>> GetAllPlans()
        {
            throw new NotImplementedException();
        }

        public Task<AnthropometricMeasurements?> GetAnthropometricMeasurement(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomerByEmail(string customerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer?>> GetCustomersByRegisteredDate(DateTime dateSelected)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentPlan?> GetPlan(int planId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentPlan?>> GetPlayByFrequency(string planFrequency)
        {
            throw new NotImplementedException();
        }

        public Task ModifyCustomerPaymentPlan(CustomerPayment paymentPlan)
        {
            throw new NotImplementedException();
        }

        public Task ModifyCustomerProgress(CustomerProgress progress)
        {
            throw new NotImplementedException();
        }

        public Task ModifyPlan(PaymentPlan plan)
        {
            throw new NotImplementedException();
        }

        public Task RegisterCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task RegisterCustomerProgress(CustomerProgress progress)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMeasurement(AnthropometricMeasurements measurement)
        {
            throw new NotImplementedException();
        }
    }
}