using AutoMapper;
using First_API.Interfaces.ForTest;
using First_API.Requests;
using First_API.Responses;
using First_API.SQLmetricitem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;

namespace First_API.Controllers
{

    //[ApiController]
    //[Route("api/metrics/cpu")]
    //public class CpuMetricsController : ControllerBase
    //{
    //    private readonly ILogger<CpuMetricsController> _logger;

    //    public CpuMetricsController(ILogger<CpuMetricsController> logger)
    //    {
    //        _logger = logger;
    //        _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
    //    }




    

    

    //    [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
    //    public IActionResult GetMetricsFromAgent
    //        (
    //        [FromRoute] int agentId,
    //        [FromRoute] TimeSpan fromTime,
    //        [FromRoute] TimeSpan toTime
    //        )
    //    {
    //        _logger.LogInformation("Привет! Это наше первое сообщение в лог");
    //        return Ok();
    //    }

    //    [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
    //    public IActionResult GetMetricsFromAllCluster
    //        (
    //        [FromRoute] TimeSpan fromTime,
    //        [FromRoute] TimeSpan toTime
    //        )
    //    {
    //        return Ok();
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly IDotNetMetricsRepository repository;
        private readonly ILogger<CpuMetricsController> logger;
        public static readonly string NameMetrics= "DotnetMetrics";
        public DotNetMetricsController(IDotNetMetricsRepository repository, ILogger<CpuMetricsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в {NameMetrics}Controller");
        }

       

        //    [HttpGet("sql-read-write-test")]
        //    public IActionResult TryToInsertAndRead()
        //    {
        //        // Создаём строку подключения в виде базы данных в оперативнойпамяти
        //        string connectionString = "Data Source=:memory:";

        //        // Создаём соединение с базой данных
        //        using (var connection = new SQLiteConnection(connectionString))
        //        {

        //            // Открываем соединение
        //            connection.Open();

        //            // Создаём объект, через который будут выполняться команды к базе данных
        //            using (var command = new SQLiteCommand(connection))
        //            {

        //                // Задаём новый текст команды для выполнения
        //                // Удаляем таблицу с метриками, если она есть в базе данных
        //                command.CommandText = "DROP TABLE IF EXISTS cpumetrics";

        //                // Отправляем запрос в базу данных
        //                command.ExecuteNonQuery();

        //                // Создаём таблицу с метриками
        //                command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY,value INT, time INT)";
        //                command.ExecuteNonQuery();

        //                // Создаём запрос на вставку данных
        //                command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES (10, 1)";
        //                command.ExecuteNonQuery();
        //                command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(50, 2)";
        //                command.ExecuteNonQuery();
        //                command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(75, 4)";
        //                command.ExecuteNonQuery();
        //                command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(90, 5)";
        //                command.ExecuteNonQuery();

        //                // Создаём строку для выборки данных из базы
        //                // LIMIT 3 обозначает, что мы достанем только 3 записи
        //                string readQuery = "SELECT * FROM cpumetrics LIMIT 3";

        //                // Создаём массив, в который запишем объекты с данными из базы данных
        //                var returnArray = new MetricBase[3];

        //                // Изменяем текст команды на наш запрос чтения
        //                command.CommandText = readQuery;

        //                // Создаём читалку из базы данных
        //                using (SQLiteDataReader reader = command.ExecuteReader())
        //                {
        //                    // Счётчик, чтобы записать объект в правильное место в массиве
        //                    var counter = 0;
        //                    // Цикл будет выполняться до тех пор, пока есть что читать из базы данных
        //                    while (reader.Read())
        //                    {
        //                        // Создаём объект и записываем его в массив
        //                        returnArray[counter] = new CpuMetric
        //                        {

        //                            Id = reader.GetInt32(0), // Читаем данные,полученные из базы данных
        //                            Value = reader.GetInt32(1), // преобразуя к целочисленному типу
        //                            Time = TimeSpan.FromSeconds(reader.GetInt32(2))
        //                        };

        //                        // Увеличиваем значение счётчика
        //                        counter++;
        //                    }
        //                }

        //                // Оборачиваем массив с данными в объект ответа и возвращаем пользователю
        //                return Ok(returnArray);
        //            }
        //        }
        //    }

        //    [HttpGet("sql-test")]
        //    public IActionResult TryToSqlLite()
        //    {
        //        _logger.LogInformation("запрос в базу sql");

        //        string cs = "Data Source=:memory:";
        //        string stm = "SELECT SQLITE_VERSION()";
        //        using (var con = new SQLiteConnection(cs))
        //        {
        //            con.Open();
        //            using var cmd = new SQLiteCommand(stm, con);
        //            string version = cmd.ExecuteScalar().ToString();
        //            return Ok(version);
        //        }
        //    }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {

            repository.Create(new DotNetMetric
            {
                Time = TimeSpan.FromSeconds( request.Time),
                Value = request.Value,
                Name = NameMetrics
            }, NameMetrics) ;

            logger.LogDebug(1, $"Добавлена DotNetMetric: {request.Name}") ;
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            // Задаём конфигурацию для маппера. Первый обобщённый параметр — тип объекта
            //источника, второй — тип объекта, в который перетекут данные из источника
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DotNetMetric, DotNetMetricDto>());

            var mapper = config.CreateMapper();

            IList<DotNetMetric> metrics = repository.GetAll(NameMetrics);

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };
            foreach (var metric in metrics)
            {
                // Добавляем объекты в ответ, используя маппер
                response.Metrics.Add(mapper.Map<DotNetMetricDto>(metric));
            }
            logger.LogDebug(1, $"Отправлены все DotNetMetric в {NameMetrics}");
            return Ok(response);
        }
    }
}


