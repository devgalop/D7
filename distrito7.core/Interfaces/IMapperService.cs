using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.Interfaces
{
    public interface IMapperService
    {
        OutputModel ConvertTo<OutputModel, InputModel>(InputModel model);
    }
}