using AutoMapper;
using MetricsMeneger.DAL.BaseModuls;
using MetricsMeneger.DAL.Modules;

namespace MetricsMeneger.Mappers
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
