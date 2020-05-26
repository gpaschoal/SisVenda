using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IUnitMeasurementRepository
    {
        void Create(UnitMeasurement unitMeasurement);
        void Update(UnitMeasurement unitMeasurement);
        void Delete(string id);
        UnitMeasurement GetById(string id);
        IEnumerable<UnitMeasurement> GetAll(UnitMeasurementFilter filter);
    }
}
