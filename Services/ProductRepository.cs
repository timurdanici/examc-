using exam.Database;
using exam.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace exam.Services
{
    public class CarRepository
    {
        private DatabaseConnection _db;

        public CarRepository()
        {
            _db = new DatabaseConnection();
        }

        public DataTable GetAll()
        {
            try
            {
                string query = @"SELECT c.Id_car, c.Brand, c.Model, YEAR(c.Release_Year) AS Release_Year,
                                 c.Gos_number, cl.Surname, cl.Name, c.Id_Client
                                 FROM cars c JOIN clients cl ON c.Id_Client = cl.Id_client
                                 ORDER BY c.Id_car";
                return _db.ExecuteSelect(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения автомобилей: " + ex.Message);
            }
        }

        public bool Add(Car car)
        {
            try
            {
                string query = "INSERT INTO cars (Brand, Model, Release_Year, Gos_number, Id_Client) VALUES (@brand, @model, @year, @gos, @client)";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@brand", car.Brand),
                    new MySqlParameter("@model", car.Model),
                    new MySqlParameter("@year", car.Release_Year),
                    new MySqlParameter("@gos", car.Gos_number),
                    new MySqlParameter("@client", car.Id_Client)
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления автомобиля: " + ex.Message);
            }
        }

        public bool Update(Car car)
        {
            try
            {
                string query = "UPDATE cars SET Brand=@brand, Model=@model, Release_Year=@year, Gos_number=@gos, Id_Client=@client WHERE Id_car=@id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", car.Id_car),
                    new MySqlParameter("@brand", car.Brand),
                    new MySqlParameter("@model", car.Model),
                    new MySqlParameter("@year", car.Release_Year),
                    new MySqlParameter("@gos", car.Gos_number),
                    new MySqlParameter("@client", car.Id_Client)
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка обновления автомобиля: " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string query = "DELETE FROM cars WHERE Id_car=@id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления автомобиля: " + ex.Message);
            }
        }

        public DataTable Search(string keyword)
        {
            try
            {
                string query = @"SELECT c.Id_car, c.Brand, c.Model, YEAR(c.Release_Year) AS Release_Year,
                                 c.Gos_number, cl.Surname, cl.Name, c.Id_Client
                                 FROM cars c JOIN clients cl ON c.Id_Client = cl.Id_client
                                 WHERE c.Brand LIKE @kw OR c.Gos_number LIKE @kw
                                 ORDER BY c.Id_car";
                MySqlParameter[] parameters = { new MySqlParameter("@kw", "%" + keyword + "%") };
                return _db.ExecuteSelect(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка поиска автомобилей: " + ex.Message);
            }
        }

        public DataTable GetReportData()
        {
            try
            {
                string query = @"SELECT cl.Surname, cl.Name, cl.Phonenumber, cl.Address,
                                 c.Brand, c.Model, YEAR(c.Release_Year) AS Release_Year, c.Gos_number
                                 FROM clients cl
                                 LEFT JOIN cars c ON c.Id_Client = cl.Id_client
                                 ORDER BY cl.Surname, cl.Name";
                return _db.ExecuteSelect(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения данных отчёта: " + ex.Message);
            }
        }
    }
}
