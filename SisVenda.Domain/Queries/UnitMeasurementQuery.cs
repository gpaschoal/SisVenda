using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class UnitMeasurementQuery
    {
        public static Expression<Func<UnitMeasurement, bool>> GetAll(UnitMeasurementFilter filter)
        {
            filter.Normalize();
            return unit => unit.DtDeleted == null && unit.Name.Trim().Contains(filter.Name);
        }
    }
}
