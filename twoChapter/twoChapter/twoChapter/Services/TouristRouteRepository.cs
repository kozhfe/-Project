using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.Database;
using twoChapter.IServices;
using twoChapter.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace twoChapter.Services
{
    public class TouristRouteRepository:ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        private IMapper _Mapper;

        public TouristRouteRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
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

        public bool TouristRouteExists(Guid touristRoutesId)
        {
            return _context.TouristRoutes.Any(a => a.id == touristRoutesId);
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return _context.TouristRoutePictures.Where(a => a.TouristRouteId == touristRouteId).ToList();
        }

        public TouristRoute GetPicturesList(Guid touristRouteId)
        {
            //include(通过外键加载)  join(指定字段链接)   Lazy Load (延时加载)
            return _context.TouristRoutes.Include(a => a.TouristRoutePictures).FirstOrDefault();
        }
    }
}
