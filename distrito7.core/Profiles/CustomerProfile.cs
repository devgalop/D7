using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using distrito7.core.DAO;
using distrito7.core.Models;

namespace distrito7.core.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomer, Customer>();
            CreateMap<Customer, AddCustomer>();
            CreateMap<SimpleCustomer, Customer>();
            CreateMap<Customer, SimpleCustomer>();
            CreateMap<CompleteCustomer, Customer>();
            CreateMap<Customer, CompleteCustomer>();
            CreateMap<AddProgress, CustomerProgress>();
            CreateMap<CustomerProgress, AddProgress>();
            CreateMap<CustomerProgressInfo, CustomerProgress>();
            CreateMap<CustomerProgress, CustomerProgressInfo>();
        }

    }
}