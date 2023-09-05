using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.Model;

namespace twoChapter.IServices
{
    public interface ITouristRouteRepository
    {
        //数据仓库提供方法
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid touristRouteId);

        bool TouristRouteExists(Guid touristrouteid);
        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);
        public TouristRoute GetPicturesList(Guid touristRouteId);
    }
}
