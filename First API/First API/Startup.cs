using First_API.Controllers;
using First_API.Interfaces.ForTest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data.SQLite;

namespace First_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add
        //services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection();
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
        }
            
        private static void ConfigureSqlLiteConnection()
        {
            const string connectionString = "DataSource = metrics.db; Version = 3; Pooling = true; Max Pool Size = 1000; ";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }
        private static void PrepareSchema(SQLiteConnection connection)
        {
            using var command = new SQLiteCommand(connection);

            List<string> NameMetric = new()
            {
                DotNetMetricsController.NameMetrics,
                CpuMetricsController.NameMetrics,
                HddMetricsController.NameMetrics,
                NetworkMetricsController.NameMetrics,
                RamMetricsController.NameMetrics
            };
            // Задаём новый текст команды для выполнения
            // Удаляем таблицу с метриками, если она есть в базе данных
            foreach (var item in NameMetric)
            {
                command.CommandText = @$"DROP TABLE IF EXISTS {item}";
                // Отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @$"CREATE TABLE {item}(id INTEGER PRIMARY KEY,name TEXT,value INT, time INT)";
                command.ExecuteNonQuery();
            }
           
            
        }

        // This method gets called by the runtime. Use this method toconfigure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}