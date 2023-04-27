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

        public bool IsValidModel(AddCustomer model)
        {
            return !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Email);
        }

    }
}