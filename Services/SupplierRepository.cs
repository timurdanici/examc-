using exam.Database;
using exam.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace exam.Services
{
    public class SupplierRepository
    {
        private DatabaseConnection _db;

        public SupplierRepository()
        {
            _db = new DatabaseConnection();
        }

        public DataTable GetAll()
        {
            try
            {
                string query = "SELECT SupplierID, SupplierName, ContactPerson, Email, Phone, CreatedDate FROM Suppliers ORDER BY SupplierID DESC";
                return _db.ExecuteSelect(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers: " + ex.Message);
            }
        }

        public bool Add(Supplier supplier)
        {
            try
            {
                string query = "INSERT INTO Suppliers (SupplierName, ContactPerson, Email, Phone) VALUES (@name, @contact, @email, @phone)";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@name", supplier.SupplierName),
                    new MySqlParameter("@contact", supplier.ContactPerson ?? ""),
                    new MySqlParameter("@email", supplier.Email ?? ""),
                    new MySqlParameter("@phone", supplier.Phone ?? "")
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding supplier: " + ex.Message);
            }
        }

        public bool Update(Supplier supplier)
        {
            try
            {
                string query = "UPDATE Suppliers SET SupplierName = @name, ContactPerson = @contact, Email = @email, Phone = @phone WHERE SupplierID = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", supplier.SupplierID),
                    new MySqlParameter("@name", supplier.SupplierName),
                    new MySqlParameter("@contact", supplier.ContactPerson ?? ""),
                    new MySqlParameter("@email", supplier.Email ?? ""),
                    new MySqlParameter("@phone", supplier.Phone ?? "")
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message);
            }
        }

        public bool Delete(int supplierID)
        {
            try
            {
                string query = "DELETE FROM Suppliers WHERE SupplierID = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", supplierID)
                };
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message);
            }
        }

        public DataTable Search(string keyword)
        {
            try
            {
                string query = "SELECT SupplierID, SupplierName, ContactPerson, Email, Phone, CreatedDate FROM Suppliers WHERE SupplierName LIKE @keyword OR ContactPerson LIKE @keyword OR Email LIKE @keyword ORDER BY SupplierID DESC";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@keyword", "%" + keyword + "%")
                };
                return _db.ExecuteSelect(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching suppliers: " + ex.Message);
            }
        }
    }
}
