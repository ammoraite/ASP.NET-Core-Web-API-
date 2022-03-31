using Dapper;
using First_API.DAL.BaseModuls;
using First_API.Handlers;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace First_API.Services.Repositories
{
    public class SqlLiteREpository : IRepositoryMetrics<Metric>
    {
        protected const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор

        public SqlLiteREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public IList<Metric> GetAll()
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                // Читаем, используя Query, и в шаблон подставляем тип данных,
                // объект которого Dapper, он сам заполнит его поля
                // в соответствии с названиями колонок
                return connection.Query<Metric>($"SELECT Id,Name,Time, Value FROM metrics").ToList();
            }
        }
        public void Create(Metric item)
        {

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            // Создаём команду
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на вставку данных
            connection.Execute($"INSERT INTO metrics (Name ,Value, Time) VALUES(@Name, @Value, @Time)",
                // Анонимный объект с параметрами запроса
                new
                {
                    // Value подставится на место "@value" в строке запроса
                    // Значение запишется из поля Value объекта item
                    Name = item.Name,
                    value = item.Value,
                    // Записываем в поле time количество секунд
                    time = (long)item.Time.TotalSeconds
                });
        }
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"DELETE FROM metrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(Metric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"UPDATE metrics SET name=@name, value = @value, time = @time WHERE id = @id",
                new
                {
                    name = item.ToString(),
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }
        public Metric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<Metric>($"SELECT Id, Name, Time, Value FROM metrics WHERE id = @id",
                new { id = id });
            }
        }

    }
}
