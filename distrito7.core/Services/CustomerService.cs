using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.DAO;
using distrito7.core.Interfaces;
using distrito7.core.Models;
using System.Globalization;

namespace distrito7.core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapperService _mapper;
        private readonly IRepository _repository;
        private readonly ISecurityService _security;

        public CustomerService(IRepository repository, IMapperService mapper, ISecurityService security)
        {
            _security = security;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<SimpleCustomer>> RegisterCustomer(AddCustomer customer)
        {
            try
            {
                Response<SimpleCustomer> result = new Response<SimpleCustomer>();
                if (!IsValidModel(customer))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid model, please check it and try again.";
                    return result;
                }
                Customer? customerFound = await _repository.GetCustomerByEmail(customer.Email);
                if (customerFound != null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Customer is already registered on database";
                    return result;
                }
                Customer entity = _mapper.ConvertTo<Customer, AddCustomer>(customer);
                await _repository.RegisterCustomer(entity);
                customerFound = await _repository.GetCustomerByEmail(customer.Email);
                if (customerFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Customer wasn't registered on database";
                    return result;
                }
                SimpleCustomer customerTransformed = _mapper.ConvertTo<SimpleCustomer, Customer>(customerFound);
                result.IsSuccessful = true;
                result.Result = customerTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<SimpleCustomer>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<SimpleCustomer>> ModifyCustomer(AddCustomer customer)
        {
            try
            {
                Response<SimpleCustomer> result = new Response<SimpleCustomer>();
                if (!IsValidModel(customer))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid model, please check it and try again";
                    return result;
                }
                Customer? customerFound = await _repository.GetCustomerByEmail(customer.Email);
                if (customerFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Customer wasn't registered on database";
                    return result;
                }
                customerFound.Name = customer.Name;
                customerFound.Age = customer.Age;
                customerFound.Cellphone = customer.Cellphone;
                await _repository.UpdateCustomer(customerFound);
                SimpleCustomer customerTransformed = _mapper.ConvertTo<SimpleCustomer, Customer>(customerFound);
                result.IsSuccessful = true;
                result.Result = customerTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<SimpleCustomer>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<string>> DeleteCustomer(string textEncrypted)
        {
            try
            {
                Response<string> result = new Response<string>();
                if (string.IsNullOrEmpty(textEncrypted))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid email address. Please check it and try again.";
                    return result;
                }
                string customerEmail = await _security.Decrypt(textEncrypted);
                Customer? customerFound = await _repository.GetCustomerByEmail(customerEmail);
                if (customerFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Customer wasn't registered on database";
                    return result;
                }
                await _repository.DeleteCustomer(customerFound);
                result.IsSuccessful = true;
                result.Result = "Customer was removed successfully";
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

        public async Task<Response<CompleteCustomer>> GetCustomer(string textEncrypted)
        {
            try
            {
                Response<CompleteCustomer> result = new Response<CompleteCustomer>();
                if (string.IsNullOrEmpty(textEncrypted))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid email address, please check it and try again";
                    return result;
                }
                string customerEmail = await _security.Decrypt(textEncrypted);
                Customer? customerFound = await _repository.GetCustomerByEmail(customerEmail);
                if (customerFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Customer wasn't registered on database";
                    return result;
                }
                CompleteCustomer customerTransformed = _mapper.ConvertTo<CompleteCustomer, Customer>(customerFound);
                result.IsSuccessful = true;
                result.Result = customerTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<CompleteCustomer>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<List<CompleteCustomer>>> GetCustomersByRegisterDate(SelectCustomerByDate model)
        {
            try
            {
                Response<List<CompleteCustomer>> result = new Response<List<CompleteCustomer>>();
                if (string.IsNullOrEmpty(model.DateSelected) || string.IsNullOrEmpty(model.CultureInfo))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid model, please check it and try again";
                    return result;
                }
                DateTime dateSelected = DateTime.Parse(model.DateSelected, new CultureInfo(model.CultureInfo));
                List<Customer?> customersFound = await _repository.GetCustomersByRegisteredDate(dateSelected);
                if (customersFound.Count < 1)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "There aren't results for that date";
                    return result;
                }
                List<CompleteCustomer> customersTransformed = _mapper.ConvertTo<List<CompleteCustomer>, List<Customer>>(customersFound!);
                result.IsSuccessful = true;
                result.Result = customersTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<List<CompleteCustomer>>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public async Task<Response<CompleteCustomer>> AssignPlanToCustomer(AddCustomerPayment plan)
        {
            try
            {
                Response<CompleteCustomer> result = new Response<CompleteCustomer>();
                if (plan.CustomerId < 1 || plan.PaymentId < 1)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Invalid model, please check it and try again";
                    return result;
                }
                PaymentPlan? planFound = await _repository.GetPlan(plan.PaymentId);
                if (planFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The payment plan doesn't exist in database";
                    return result;
                }
                Customer? customerFound = await _repository.GetCustomer(plan.CustomerId);
                if (customerFound == null)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "Customer doesn't exist in database";
                    return result;
                }
                plan.PaidAt = DateTime.Now;
                CalculateFinalizationDate model = new CalculateFinalizationDate()
                {
                    StartDate = plan.PaidAt,
                    Plan = planFound.PayFrequency
                };
                CustomerPayment entity = _mapper.ConvertTo<CustomerPayment, AddCustomerPayment>(plan);
                entity.EndsAt = GetPlanFinalizationDate(model);
                entity.PlanSelected = planFound;
                await _repository.AssignPaymentPlanToCustomer(entity);
                customerFound = await _repository.GetCustomer(plan.CustomerId);
                CompleteCustomer customerTransformed = _mapper.ConvertTo<CompleteCustomer, Customer>(customerFound!);
                result.IsSuccessful = true;
                result.Result = customerTransformed;
                return result;
            }
            catch (Exception ex)
            {
                return new Response<CompleteCustomer>()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        public bool IsValidModel(AddCustomer model)
        {
            return !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Email);
        }

        public DateTime GetPlanFinalizationDate(CalculateFinalizationDate model)
        {
            switch (model.Plan)
            {
                case "Quincenal":
                    return model.StartDate.AddDays(15);
                case "Mensual":
                    return model.StartDate.AddMonths(1);
                case "Trimestral":
                    return model.StartDate.AddMonths(3);
                case "Semestral":
                    return model.StartDate.AddMonths(6);
                case "Anual":
                    return model.StartDate.AddMonths(12);
                default:
                    return model.StartDate.AddMonths(1);
            }
        }

    }
}