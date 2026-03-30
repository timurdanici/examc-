using exam.Database;
using exam.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace exam.Services
{
    public class ClientRepository
    {
        private DatabaseConnection _db;

        public ClientRepository()
        {
            _db = new DatabaseConnection();
        }

        public DataTable GetAll()
        {
            try
            {
                string query = "SELECT Id_client, Surname, Name, Phonenumber, Address FROM clients ORDER BY Id_client";
                return _db.ExecuteSelect(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения клиентов: " + ex.Message);
            }
        }

        public bool Add(Client client)
        {
            try
            {
                string query = "INSERT INTO clients (Surname, Name, Phonenumber, Address) VALUES (@surname, @name, @phone, @address)";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@surname", client.Surname),
                    new MySqlParameter("@name", client.Name),
                    new MySqlParameter("@phone", client.Phonenumber),
                    new MySqlParameter("@address", client.Address)
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления клиента: " + ex.Message);
            }
        }

        public bool Update(Client client)
        {
            try
            {
                string query = "UPDATE clients SET Surname=@surname, Name=@name, Phonenumber=@phone, Address=@address WHERE Id_client=@id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", client.Id_client),
                    new MySqlParameter("@surname", client.Surname),
                    new MySqlParameter("@name", client.Name),
                    new MySqlParameter("@phone", client.Phonenumber),
                    new MySqlParameter("@address", client.Address)
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка обновления клиента: " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string query = "DELETE FROM clients WHERE Id_client=@id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления клиента: " + ex.Message);
            }
        }

        public DataTable Search(string keyword)
        {
            try
            {
                string query = "SELECT Id_client, Surname, Name, Phonenumber, Address FROM clients WHERE Surname LIKE @kw OR Name LIKE @kw OR Phonenumber LIKE @kw ORDER BY Id_client";
                MySqlParameter[] parameters = { new MySqlParameter("@kw", "%" + keyword + "%") };
                return _db.ExecuteSelect(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка поиска клиентов: " + ex.Message);
            }
        }
    }
}
