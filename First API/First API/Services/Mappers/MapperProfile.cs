using AutoMapper;
using First_API.DAL.BaseModuls;
using First_API.Interfaces;

namespace First_API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Metric, DtoMetric>();
        }

    }
}
