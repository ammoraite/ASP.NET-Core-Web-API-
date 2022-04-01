using AutoMapper;
using First_API.DAL.BaseModuls;
using First_API.DAL.Modules;

namespace First_API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Metric, DtoMetric>();
            CreateMap<CpuMetric, DtoMetric>();
            CreateMap<DotNetMetric, DtoMetric>();
            CreateMap<HddMetric, DtoMetric>();
            CreateMap<NetWorkMetric, DtoMetric>();
            CreateMap<RumMetric, DtoMetric>();
        }
    }
}
