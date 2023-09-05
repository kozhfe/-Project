using System;
using AutoMapper;
using twoChapter.Dtos;
using twoChapter.Model;

namespace twoChapter.Profiles
{
    public class TouristRoutePictureProfile:Profile
    {
        public TouristRoutePictureProfile() {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
        }
    }
}
