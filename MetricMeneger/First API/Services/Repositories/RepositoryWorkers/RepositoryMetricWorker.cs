using Dapper;
using MetricsMeneger.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsMeneger.Services.Repositories
{
    public class RepositoryMetricWorker<T> where T : IMetric
    {
        private readonly string _connectionString;
        private readonly string _nameTable;

        public RepositoryMetricWorker(string connectionString, string nameTabel)
        {
            _connectionString = connectionString;
            _nameTable = nameTabel;
        }
        public void Create(T item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            // Создаём команду
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на вставку данных
            connection.Execute($"INSERT INTO {_nameTable} (Value, Time) VALUES( @Value, @Time)",
                // Анонимный объект с параметрами запроса
                new
                {
                    // Value подставится на место "@value" в строке запроса
                    // Значение запишется из поля Value объекта item
                    Value = item.Value,
                    // Записываем в поле time количество секунд
                    Time = item.Time.TotalSeconds
                });
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute($"DELETE FROM {_nameTable} WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public IList<T> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                // Читаем, используя Query, и в шаблон подставляем тип данных,
                // объект которого Dapper, он сам заполнит его поля
                // в соответствии с названиями колонок
                return connection.Query<T>($"SELECT Id,Value,Time FROM {_nameTable};").ToList();
            }
        }

        public T GetById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<T>($"SELECT Id, Value, Time FROM {_nameTable} WHERE id = @id",
                    new { id = id });
            }
        }

        public void Update(T item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute($"UPDATE {_nameTable} SET value = @value, time = @time WHERE id = @id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }
    }
}
