/*
 引用AutoMapper
 继承父类
 */
using AutoMapper;
using twoChapter.Dtos;
using twoChapter.Model;

namespace twoChapter.Profiles
{
    public class TouristRouteProfile:Profile
    {
        /// <summary>
        /// 映射配置在构造函数中完成
        /// </summary>
        public TouristRouteProfile() 
        {
            //第一个模型的对象，第二个为映射的目标对象
            CreateMap<TouristRoute, TouristRouteDto>()
                .ForMember(
                    dest=>dest.OriginalPrice,
                    opt=>opt.MapFrom(src=>(src.OriginalPrice+2).ToString())
                )
                .ForMember(
                    dest => dest.DiscountPresent,
                    opt => opt.MapFrom(src => src.DiscountPresent.ToString())
                );//做字段的投影
        }    
    }
}
