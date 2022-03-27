using First_API.Interfaces;
using First_API.Interfaces.ForTest;
using First_API.Responses;
using First_API.SQLmetricitem;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace First_API
{  
    public class RamMetricsRepository : MetricRepositoryBase<RamMetric>, IRamMetricsRepository
    {     
    } 
}


