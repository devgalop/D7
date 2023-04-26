using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Models;

namespace distrito7.core.Interfaces
{
    public interface IPaymentRepository
    {
        Task AddPlan(PaymentPlan plan);
        Task ModifyPlan(PaymentPlan plan);
        Task DeletePlan(PaymentPlan plan);
        Task<PaymentPlan?> GetPlan(int planId);
        Task<PaymentPlan?> GetPlanByName(string planName);
        Task<List<PaymentPlan?>> GetAllPlans();
        Task<List<PaymentPlan?>> GetPlansByFrequency(string planFrequency);
    }
}