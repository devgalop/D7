using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using distrito7.core.DAO;
using distrito7.core.Models;

namespace distrito7.core.Profiles
{
    public class PaymentPlanProfile : Profile
    {
        public PaymentPlanProfile()
        {
            CreateMap<PaymentPlanInfo, PaymentPlan>();
            CreateMap<PaymentPlan, PaymentPlanInfo>();
            CreateMap<CustomerPaymentPlan, CustomerPayment>();
            CreateMap<CustomerPayment, CustomerPaymentPlan>();
            CreateMap<AddCustomerPayment, CustomerPayment>();
            CreateMap<CustomerPayment, AddCustomerPayment>();
            CreateMap<AddPaymentPlan, PaymentPlan>();
            CreateMap<PaymentPlan, AddPaymentPlan>();
            CreateMap<UpdatePaymentPlan, PaymentPlan>();
            CreateMap<PaymentPlan, UpdatePaymentPlan>();
        }
    }
}