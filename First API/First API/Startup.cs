using AutoMapper;
using First_API.DAL.BaseModuls;
using First_API.Mappers;
using First_API.Services.Repositories;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace First_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string ConnectionString = @"Data Source=metrics.db;Version=3;";

        // ���� ����� ���������� ������ ����������. ���������� ��� ���
        //���������� ����� � ���������

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IRepositoryMetrics<Metric>, SqlLiteREpository>();
            var mapperConfiguration = new MapperConfiguration(mp =>
                mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // ��������� ��������� SQLite
                    .AddSQLite()
                    // ������������� ������ �����������
                    .WithGlobalConnectionString(ConnectionString)
                    // ������������, ��� ������ ������ � ����������
                    .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());
        }

        // ���� ����� ���������� ������ ����������. ���������� ��� ���
        //��������� ��������� HTTP-��������

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
            // ��������� ��������
            migrationRunner.MigrateUp();
        }
    }
}