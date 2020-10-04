using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Tests.Repositories
{
    public class UnitMeasurementRepositoryFake : IUnitMeasurementRepository
    {
        public void Create(UnitMeasurement unitMeasurement) { }

        public void Delete(string id) { }

        public IEnumerable<UnitMeasurement> GetAll(UnitMeasurementFilter filter)
        {
            return null;
        }

        public UnitMeasurement GetById(string id)
        {
            return null;
        }

        public void Update(UnitMeasurement unitMeasurement) { }
    }
}
