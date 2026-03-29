using exam.Database;
using exam.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace exam.Services
{
    public class CategoryRepository
    {
        private DatabaseConnection _db;

        public CategoryRepository()
        {
            _db = new DatabaseConnection();
        }

        public DataTable GetAll()
        {
            try
            {
                string query = "SELECT CategoryID, CategoryName, Description, CreatedDate FROM Categories ORDER BY CategoryID DESC";
                return _db.ExecuteSelect(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message);
            }
        }

        public bool Add(Category category)
        {
            try
            {
                string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@name, @desc)";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@name", category.CategoryName),
                    new MySqlParameter("@desc", category.Description ?? "")
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category: " + ex.Message);
            }
        }

        public bool Update(Category category)
        {
            try
            {
                string query = "UPDATE Categories SET CategoryName = @name, Description = @desc WHERE CategoryID = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", category.CategoryID),
                    new MySqlParameter("@name", category.CategoryName),
                    new MySqlParameter("@desc", category.Description ?? "")
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating category: " + ex.Message);
            }
        }

        public bool Delete(int categoryID)
        {
            try
            {
                string query = "DELETE FROM Categories WHERE CategoryID = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", categoryID)
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting category: " + ex.Message);
            }
        }

        public DataTable Search(string keyword)
        {
            try
            {
                string query = "SELECT CategoryID, CategoryName, Description, CreatedDate FROM Categories WHERE CategoryName LIKE @keyword OR Description LIKE @keyword ORDER BY CategoryID DESC";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@keyword", "%" + keyword + "%")
                };
                return _db.ExecuteSelect(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching categories: " + ex.Message);
            }
        }
    }
}
