using AutoMapper;
using First_API.DAL.BaseModuls;
using First_API.DAL.MetricDtoModules;
using First_API.DAL.MetricsModules;
using First_API.Interfaces;
using First_API.Responses;
using System.Collections.Generic;

namespace First_API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MetricBase, CpuMetricDto>();
            CreateMap<IMetric, CpuMetricDto>();
            CreateMap<IMetricDto, CpuMetricDto>();
            CreateMap<CpuMetricDto, IMetricDto>();
            CreateMap<CpuMetricDto, IMetric>();

            CreateMap<MetricBase, RamMetric>();
            CreateMap<MetricBase, NetworkMetric>();
            CreateMap<MetricBase, DotNetMetric>();
            CreateMap<MetricBase, HddMetric>();
            CreateMap<MetricBase, CpuMetric>();
            

            CreateMap<CpuMetricDto,  MetricBase>();
            CreateMap<RamMetric,     MetricBase>();
            CreateMap<NetworkMetric, MetricBase>();
            CreateMap<DotNetMetric,  MetricBase>();
            CreateMap<HddMetric,     MetricBase>();
            CreateMap<CpuMetric,     MetricBase>();
            CreateMap<IMetric,       MetricBase>();
            CreateMap<IMetricDto,    MetricBase>();
            
          
    }
  
    }
}
