using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    
    public class LandService :ILand
    {
        private RmsContext _context;
        public LandService(RmsContext context)
        {
            _context = context;
        }
        public void Add(Land property)
        {
            _context.Add(property);
            _context.SaveChanges();
        }
        public Land Get(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Land> GetAll()
        {
            return _context.Lands.Include(p => p.Customers);
        }
        public int GetNumberOfLands()
        {
            return _context.Lands.Count();
        }
        public void Update(Land property)
        {
            Land entityToUpdate = Get(property.Id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(property);

            _context.SaveChanges();
        }
    }
}
