using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.DAO;

namespace distrito7.core.Interfaces
{
    public interface IPaymentPlanService
    {
        Task<Response<PaymentPlanInfo>> CreatePlan(AddPaymentPlan plan);
        Task<Response<PaymentPlanInfo>> ModifyPlan(UpdatePaymentPlan plan);
        Task<Response<List<PaymentPlanInfo>>> GetAllPlans();
        Task<Response<PaymentPlanInfo>> GetPlan(int planId);
        Task<Response<PaymentPlanInfo>> GetPlanByName(string planName);
        Task<Response<string>> DeletePlan(int planId);
        Task<Response<List<PaymentPlanInfo>>> GetPlanByFrequency(string planFrequency);
    }
}