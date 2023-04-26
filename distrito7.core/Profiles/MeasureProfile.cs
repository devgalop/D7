using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using distrito7.core.DAO;
using distrito7.core.Models;

namespace distrito7.core.Profiles
{
    public class MeasureProfile : Profile
    {
        public MeasureProfile()
        {
            CreateMap<AnthropometricMeasurement, AnthropometricMeasurements>();
            CreateMap<AnthropometricMeasurements, AnthropometricMeasurement>();
            CreateMap<CustomerMeasures, CustomerAM>();
            CreateMap<CustomerAM, CustomerMeasures>();
            CreateMap<AddCustomerAM, CustomerAM>();
            CreateMap<CustomerAM, AddCustomerAM>();
            CreateMap<AddAM, AnthropometricMeasurements>();
            CreateMap<AnthropometricMeasurements, AddAM>();
        }

    }
}