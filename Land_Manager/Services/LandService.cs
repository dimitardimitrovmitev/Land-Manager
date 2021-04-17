using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    /// <summary>
    /// Handles the land business logic
    /// </summary>
    public class LandService :ILand
    {
        private RmsContext _context;
        /// <summary>
        /// Constuctor for the Land Service
        /// </summary>
        /// <param name="context">Database context</param>
        public LandService(RmsContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adds a new land to the Database
        /// </summary>
        /// <param name="land"></param>
        public void Add(Land land)
        {
            _context.Add(land);
            _context.SaveChanges();
        }
        /// <summary>
        /// Returns a single land, specified by id
        /// </summary>
        /// <param name="id">A land matching the id or null if none matches</param>
        /// <returns></returns>
        public Land Get(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// Returns all land records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Land> GetAll()
        {
            return _context.Lands.Include(p => p.Customers);
        }
        /// <summary>
        /// Gets the number of all lands
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfLands()
        {
            return _context.Lands.Count();
        }
        /// <summary>
        /// Update the values of a single land
        /// </summary>
        /// <param name="land"></param>
        public void Update(Land land)
        {
            Land entityToUpdate = Get(land.Id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(land);

            _context.SaveChanges();
        }
    }
}
