using AutoMapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DTO.Jobs;
using First_API.Mappers;
using First_API.Services.Jobs;
using First_API.Services.Repositories;
using FluentMigrator.Runner;
using MetricsAgent.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using First_API.Services.Migrations;
using FluentMigrator;

namespace First_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private const string ConnectionString = @"Data Source=HardWareMetrics.db;Version=3;";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        ///<summary>
        /// Этот метод вызывается средой выполнения. Используем его для добавления служб в контейнер
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            #region Controllers

            services.AddControllers();

            #endregion

            #region Repositoryes

            services.AddSingleton<ICpuMetricRepository, SqlLiteCpuREpository>();
            services.AddSingleton<IRumMetricRepository, SqlLiteRumREpository>();
            services.AddSingleton<INetWorkMetricRepository, SqlLiteNetWorkREpository>();
            services.AddSingleton<IDotNetMetricRepository, SqlLiteDotNetREpository>();
            services.AddSingleton<IHddMetricRepository, SqlLiteHddREpository>();

            #endregion

            #region Mapper

            var mapperConfiguration = new MapperConfiguration(mp =>
                mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region Migrator

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Добавляем поддержку SQLite
                    .AddSQLite()
                    // Устанавливаем строку подключения
                    .WithGlobalConnectionString(ConnectionString)
                    // Подсказываем, где искать классы с миграциями
                    .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());

            #endregion

            #region Jobs
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();

            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?")); // Запускать каждые 5 секунд

            services.AddSingleton<DotNetMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DotNetMetricJob),
                cronExpression: "0/5 * * * * ?")); // Запускать каждые 5 секунд

            services.AddSingleton<RumMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RumMetricJob),
                cronExpression: "0/5 * * * * ?")); // Запускать каждые 5 секунд

            services.AddSingleton<NetWorkMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetWorkMetricJob),
                cronExpression: "0/5 * * * * ?")); // Запускать каждые 5 секунд

            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: "0/5 * * * * ?")); // Запускать каждые 5 секунд
            #endregion
        }


        /// <summary>
        /// Этот метод вызывается средой выполнения.Используем его для настройки конвейера HTTP-запросов
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            // Запускаем миграции
            migrationRunner.MigrateUp();
        }
    }
}