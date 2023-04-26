using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using distrito7.core.Interfaces;

namespace distrito7.core.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;
        public MapperService(IMapper mapper)
        {
            _mapper = mapper;

        }
        /// <summary>
        /// Map a class to another using AutoMapper library
        /// </summary>
        /// <param name="model">class instance to map</param>
        /// <typeparam name="OutputModel">final class type</typeparam>
        /// <typeparam name="InputModel">base class type</typeparam>
        /// <returns>class transformed</returns>
        public OutputModel ConvertTo<OutputModel, InputModel>(InputModel model)
        {
            return _mapper.Map<OutputModel>(model);
        }
    }
}