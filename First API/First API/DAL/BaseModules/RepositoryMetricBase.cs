using Core.Interfaces;
using Dapper;
using First_API.DAL.MetricsModules;
using First_API.Handlers;
using First_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace First_API.DAL.BaseModuls.HardwareBaseModules
{
    public  class RepositoryMetricBase: IRepositoryesBase
    {
        protected const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        // Инжектируем соединение с базой данных в наш репозиторий черезонструктор

        public RepositoryMetricBase()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
    
        public IList<MetricBase> GetAll(string NameMetric)
        {
     
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                // Читаем, используя Query, и в шаблон подставляем тип данных,
                // объект которого Dapper, он сам заполнит его поля
                // в соответствии с названиями колонок
                return connection.Query<MetricBase>($"SELECT Id, Name, Time, Value FROM {NameMetric}").ToList();        
            }
        }
        public void Create(IMetric item,string NameMetric)
        {
            
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            // Создаём команду
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на вставку данных
            connection.Execute($"INSERT INTO {NameMetric} (Name ,Value, Time) VALUES(@Name, @Value, @Time)",
                // Анонимный объект с параметрами запроса
                new
                {
                    // Value подставится на место "@value" в строке запроса
                    // Значение запишется из поля Value объекта item
                    Name=item.Name,
                    value = item.Value,
                    // Записываем в поле time количество секунд
                    time = item.Time.TotalSeconds
                });
        }
        public void Delete(int id,string NameMetric)
        { 
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"DELETE FROM {NameMetric} WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(IMetric item,string NameMetric)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"UPDATE {NameMetric} SET name=@name, value = @value, time = @time WHERE id = @id",
                new
                {
                    name=item.Name,
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }
        public IMetric GetById(int id,string NameMetric)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<IMetric>($"SELECT Id, Name, Time, Value FROM {NameMetric} WHERE id = @id",
                new { id = id });
            }
        }
        
    }
}
    