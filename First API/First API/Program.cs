using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace First_API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var logger = NLogBuilder.ConfigureNLog("nlog.config.xml").GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            // ����� ���� ���������� � ������ ������ ����������
            catch (Exception exception)
            {
                //NLog: ������������� ����� ����������
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // ��������� �������
                NLog.LogManager.Shutdown();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {
            webBuilder.UseStartup<Startup>();
        }).ConfigureLogging(logging =>
        {
            logging.ClearProviders(); // �������� ����������� �����������
            logging.SetMinimumLevel(LogLevel.Trace); // ������������� ����������� ������� �����������
        }).UseNLog(); // ��������� ���������� nlog
    }
}
