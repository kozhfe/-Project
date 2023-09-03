using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.Database;
using twoChapter.IServices;
using twoChapter.Model;

namespace twoChapter.Services
{
    public class TouristRouteRepository:ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.FirstOrDefault(n => n.id == touristRouteId);

            //return _context.TouristRoutes.Join(_context.TouristRoutePictures,
            //    rout => rout.id,
            //    Pictur => Pictur.TouristRouteId,
            //    (rout, pictur) => new
            //    {
            //        route = rout,
            //        Pictur = pictur
            //    }
            //    ).FirstOrDefault(rout => rout.route.id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    }
}
