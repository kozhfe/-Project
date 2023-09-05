using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using twoChapter.Dtos;
using twoChapter.IServices;
using twoChapter.Services;

namespace twoChapter.Controllers
{
    [ApiController]
    [Route("api/touristRoutes/{touristRoutesId}/pictures")]
    public class TouristRoutePicturesController:ControllerBase
    {
        private ITouristRouteRepository _TouristRouteRepository;
        private IMapper _Mapper;
        public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _TouristRouteRepository = touristRouteRepository??throw new ArgumentNullException(nameof(touristRouteRepository));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRoutesId)
        {
            if (!_TouristRouteRepository.TouristRouteExists(touristRoutesId))
            {
                return NotFound("旅游路线不存在");//抛出404
            }
            var GetPicture = _TouristRouteRepository.GetPicturesByTouristRouteId(touristRoutesId);
            if (GetPicture.Count()<=0)
            {
                return NotFound("旅游路线不存在");//抛出404
            }
            return Ok(_Mapper.Map<IEnumerable<TouristRoutePictureDto>>(GetPicture));
        }

        [HttpPost]
        public IActionResult GetPicturesList(Guid touristRoutesId)
        {
            var at = _TouristRouteRepository.GetPicturesList(touristRoutesId);
            return Ok(_Mapper.Map<TouristRouteDto>(at));
        }

    }
}
