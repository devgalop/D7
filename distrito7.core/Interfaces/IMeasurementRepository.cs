using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Models;

namespace distrito7.core.Interfaces
{
    public interface IMeasurementRepository
    {
        Task AddMeasurement(AnthropometricMeasurements measurement);
        Task UpdateMeasurement(AnthropometricMeasurements measurement);
        Task DeleteMeasurement(AnthropometricMeasurements measurement);
        Task<List<AnthropometricMeasurements?>> GetAllMeasurements();
        Task<AnthropometricMeasurements?> GetAnthropometricMeasurement(int Id);
    }
}