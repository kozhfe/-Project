using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.Database;
using twoChapter.Model;

namespace twoChapter.Services
{
    public class TouristRouteRepository1:ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        public TouristRouteRepository1(AppDbContext context)
        {
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.FirstOrDefault(n => n.id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    } 
}
