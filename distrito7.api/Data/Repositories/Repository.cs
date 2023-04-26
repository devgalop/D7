using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Interfaces;
using distrito7.core.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<AnthropometricMeasurements?>> GetAllMeasurements()
        {
            List<AnthropometricMeasurements> results = await _dataContext.AnthropometricMeasurements
                                                            .OrderBy(am => am.UnitMeasurements)
                                                            .ToListAsync();
            return results!;
        }

        public async Task<List<PaymentPlan?>> GetAllPlans()
        {
            List<PaymentPlan> results = await _dataContext.PaymentPlans
                                            .OrderBy(pp => pp.PayFrequency)
                                            .ToListAsync();
            return results!;
        }

        public async Task<AnthropometricMeasurements?> GetAnthropometricMeasurement(int Id)
        {
            AnthropometricMeasurements? result = await _dataContext.AnthropometricMeasurements
                                                    .Where(am => am.Id == Id)
                                                    .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Customer?> GetCustomer(int customerId)
        {
            Customer? result = await _dataContext.Customers
                                .Include(c => c.Progress)
                                .Include(c => c.Payment)
                                .Where(c => c.IdNumber == customerId)
                                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Customer?> GetCustomerByEmail(string customerEmail)
        {
            Customer? result = await _dataContext.Customers
                                .Include(c => c.Progress)
                                .Include(c => c.Payment)
                                .Where(c => c.Email == customerEmail)
                                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Customer?>> GetCustomersByRegisteredDate(DateTime dateSelected)
        {
            List<Customer> result = await _dataContext.Customers
                                .Include(c => c.Progress)
                                .Include(c => c.Payment)
                                .Where(c => c.RegisterAt.Date == dateSelected.Date)
                                .OrderBy(c => c.Name)
                                .ToListAsync();
            return result!;
        }

        public async Task<PaymentPlan?> GetPlan(int planId)
        {
            PaymentPlan? result = await _dataContext.PaymentPlans
                                    .Where(pp => pp.Id == planId)
                                    .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<PaymentPlan?>> GetPlayByFrequency(string planFrequency)
        {
            List<PaymentPlan> result = await _dataContext.PaymentPlans
                                        .Where(pp => pp.PayFrequency.ToUpper() == planFrequency.ToUpper())
                                        .OrderBy(pp => pp.Name)
                                        .ToListAsync();
            return result!;
        }

        public async Task ModifyCustomerPaymentPlan(CustomerPayment paymentPlan)
        {
            _dataContext.CustomerPayments.Update(paymentPlan);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ModifyCustomerProgress(CustomerProgress progress)
        {
            _dataContext.CustomerProgresses.Update(progress);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ModifyPlan(PaymentPlan plan)
        {
            _dataContext.PaymentPlans.Update(plan);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RegisterCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RegisterCustomerProgress(CustomerProgress progress)
        {
            _dataContext.CustomerProgresses.Add(progress);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateMeasurement(AnthropometricMeasurements measurement)
        {
            _dataContext.AnthropometricMeasurements.Update(measurement);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<PaymentPlan?> GetPlanByName(string planName)
        {
            PaymentPlan? result = await _dataContext.PaymentPlans
                                    .Where(pp => pp.Name.ToUpper() == planName.ToUpper())
                                    .FirstOrDefaultAsync();
            return result;
        }
    }
}