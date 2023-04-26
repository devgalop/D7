using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.DAO;
using distrito7.core.Interfaces;
using distrito7.core.Models;

namespace distrito7.core.Services
{
    public class PaymentPlanService : IPaymentPlanService
    {
        private readonly IRepository _repository;
        private readonly IMapperService _mapper;

        public PaymentPlanService(IRepository repository,
                                    IMapperService mapper)
        {
            _mapper = mapper;
            _repository = repository;

        }

        public async Task<Response<PaymentPlanInfo>> CreatePlan(AddPaymentPlan plan)
        {
            try
            {
                Response<PaymentPlanInfo> result = new Response<PaymentPlanInfo>();
                if (!IsValidModel(plan))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid model, please check it and try again.";
                    return result;
                }
                PaymentPlan entity = _mapper.ConvertTo<PaymentPlan, AddPaymentPlan>(plan);
                entity.Status = true;
                await _repository.AddPlan(entity);
                PaymentPlan? planFound = await _repository.GetPlanByName(plan.Name);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Payment plan wasn't added, please try again";
                    return result;
                }
                PaymentPlanInfo planTransformed = _mapper.ConvertTo<PaymentPlanInfo, PaymentPlan>(planFound);
                result.IsSuccessful = true;
                result.Result = planTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<PaymentPlanInfo>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<PaymentPlanInfo>> ModifyPlan(UpdatePaymentPlan plan)
        {
            try
            {
                Response<PaymentPlanInfo> result = new Response<PaymentPlanInfo>();
                if (!IsValidModel(plan) || !(plan.Id > 0))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid model, please check it and try again.";
                    return result;
                }
                PaymentPlan? planFound = await _repository.GetPlan(plan.Id);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The payment plan wasn't found.";
                    return result;
                }
                planFound.Name = plan.Name;
                planFound.Description = plan.Description;
                planFound.PayFrequency = plan.PayFrequency;
                planFound.Status = plan.Status;
                await _repository.ModifyPlan(planFound);
                PaymentPlanInfo planTransformed = _mapper.ConvertTo<PaymentPlanInfo, PaymentPlan>(planFound);
                result.IsSuccessful = true;
                result.Result = planTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<PaymentPlanInfo>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<List<PaymentPlanInfo>>> GetAllPlans()
        {
            try
            {
                Response<List<PaymentPlanInfo>> result = new Response<List<PaymentPlanInfo>>();
                List<PaymentPlan?> plansFound = await _repository.GetAllPlans();
                List<PaymentPlanInfo> plansTransformed = _mapper.ConvertTo<List<PaymentPlanInfo>, List<PaymentPlan>>(plansFound!);
                result.IsSuccessful = true;
                result.Result = plansTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<List<PaymentPlanInfo>>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<PaymentPlanInfo>> GetPlan(int planId)
        {
            try
            {
                Response<PaymentPlanInfo> result = new Response<PaymentPlanInfo>();
                if (planId < 1)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid payment plan id. Please check it and try again.";
                    return result;
                }
                PaymentPlan? planFound = await _repository.GetPlan(planId);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The payment plan wasn't found";
                    return result;
                }
                PaymentPlanInfo planTransformed = _mapper.ConvertTo<PaymentPlanInfo, PaymentPlan>(planFound);
                result.IsSuccessful = true;
                result.Result = planTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<PaymentPlanInfo>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<PaymentPlanInfo>> GetPlanByName(string planName)
        {
            try
            {
                Response<PaymentPlanInfo> result = new Response<PaymentPlanInfo>();
                if (string.IsNullOrEmpty(planName))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid payment plan name. Please check it and try again.";
                    return result;
                }
                PaymentPlan? planFound = await _repository.GetPlanByName(planName);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The payment plan wasn't found";
                    return result;
                }
                PaymentPlanInfo planTransformed = _mapper.ConvertTo<PaymentPlanInfo, PaymentPlan>(planFound);
                result.IsSuccessful = true;
                result.Result = planTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<PaymentPlanInfo>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<List<PaymentPlanInfo>>> GetPlanByFrequency(string planFrequency)
        {
            try
            {
                Response<List<PaymentPlanInfo>> result = new Response<List<PaymentPlanInfo>>();
                if (string.IsNullOrEmpty(planFrequency))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid payment plan name. Please check it and try again.";
                    return result;
                }
                List<PaymentPlan?> planFound = await _repository.GetPlansByFrequency(planFrequency);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The payment plan wasn't found";
                    return result;
                }
                List<PaymentPlanInfo> planTransformed = _mapper.ConvertTo<List<PaymentPlanInfo>, List<PaymentPlan>>(planFound!);
                result.IsSuccessful = true;
                result.Result = planTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<List<PaymentPlanInfo>>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<string>> DeletePlan(int planId)
        {
            try
            {
                Response<string> result = new Response<string>();
                if (planId < 1)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid payment plan id. Please check it and try again.";
                    return result;
                }
                PaymentPlan? planFound = await _repository.GetPlan(planId);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The payment plan wasn't found";
                    return result;
                }
                await _repository.DeletePlan(planFound);
                result.IsSuccessful = true;
                result.Result = "Payment plan was deleted successfully";
                return result;
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public bool IsValidModel(AddPaymentPlan model)
        {
            return !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.PayFrequency) || model.Value > 0;
        }
    }
}