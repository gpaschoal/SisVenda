using Microsoft.EntityFrameworkCore;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Queries;
using SisVenda.Domain.Repositories;
using SisVenda.Infra.Contexts;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;
using System.Linq;

namespace SisVenda.Infra.Repositories
{
    public class UnitMeasurementRepository : IUnitMeasurementRepository
    {
        private readonly SisVendaContext _context;
        public UnitMeasurementRepository(SisVendaContext context)
        {
            _context = context;
        }

        public void Create(UnitMeasurement unitMeasurement)
        {
            _context.UnitMeasurement.Add(unitMeasurement);
            _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            UnitMeasurement unitMeasurement = _context.UnitMeasurement.FirstOrDefault(x => x.Id == id);
            if (unitMeasurement != null)
            {
                unitMeasurement.Delete();
                _context.SaveChangesAsync();
            }
        }

        public IEnumerable<UnitMeasurement> GetAll(UnitMeasurementFilter filter)
        {
            return _context.UnitMeasurement.AsNoTracking().Where(UnitMeasurementQuery.GetAll(filter));
        }

        public UnitMeasurement GetById(string id)
        {
            return _context.UnitMeasurement.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Update(UnitMeasurement unitMeasurement)
        {
            _context.Entry(unitMeasurement).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}
