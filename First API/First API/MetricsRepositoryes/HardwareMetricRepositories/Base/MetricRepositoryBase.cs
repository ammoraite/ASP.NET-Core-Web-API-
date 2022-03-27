using First_API.Interfaces;
using First_API.SQLmetricitem;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace First_API.Responses
{
    public  class MetricRepositoryBase<T>where T : IMetric
    {
        protected const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        // Инжектируем соединение с базой данных в наш репозиторий черезонструктор

      
        public IList<MetricBase> GetAll(string NameMetric)
        {
           
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на получение всех данных из
            //таблицы
            cmd.CommandText = $"SELECT * FROM {NameMetric}";
            var returnList = new List<MetricBase>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // Пока есть что читать — читаем
                while (reader.Read())
                {
                    // Добавляем объект в список возврата
                    returnList.Add(new MetricBase
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Value = reader.GetInt32(2),
                        // Налету преобразуем прочитанные секунды в метку
                        //времени
                        Time = reader.GetInt32(3)
                    });
                }
            }
            return returnList;
        }
        public void Create(T item,string NameMetric)
        {
            
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            // Создаём команду
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на вставку данных
            cmd.CommandText = $"INSERT INTO {NameMetric} (Name ,Value, Time) VALUES(@Name, @Value, @Time)";
            cmd.Parameters.AddWithValue("@Name", item.Name);
            // Добавляем параметры в запрос из нашего объекта
            cmd.Parameters.AddWithValue("@Value", item.Value );
            // В таблице будем хранить время в секундах, поэтому преобразуем
            // перед записью в секунды через свойство
            cmd.Parameters.AddWithValue("@Time", item.Time);

            
            // подготовка команды к выполнению
            cmd.Prepare();
            // Выполнение команды
            cmd.ExecuteNonQuery();
        }
        public void Delete(int id,string NameMetric)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на удаление данных
            cmd.CommandText = $"DELETE FROM {NameMetric} WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void Update(T item,string NameMetric)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на обновление данных
            cmd.CommandText = $"UPDATE {NameMetric} SET value = @value, time = @time WHERE id = @id; ";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public MetricBase GetById(int id,string NameMetric)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"SELECT * FROM {NameMetric} WHERE {id}=@id";
            using SQLiteDataReader reader = cmd.ExecuteReader();
            // Если удалось что-то прочитать
            if (reader.Read())
            {
                // возвращаем прочитанное
                return new MetricBase
                {
                    Id = reader.GetInt32(0),
                    Value = reader.GetInt32(1),
                    Time = reader.GetInt32(2)
                };
            }
            else
            {
                // Не нашлась запись по идентификатору, не делаем ничего
                return null;
            }
        }
    }
}
    