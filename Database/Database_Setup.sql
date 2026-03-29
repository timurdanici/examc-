-- Create Database
CREATE DATABASE IF NOT EXISTS product_management;
USE product_management;

-- Create Categories Table
CREATE TABLE IF NOT EXISTS Categories (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL UNIQUE,
    Description VARCHAR(255),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create Suppliers Table
CREATE TABLE IF NOT EXISTS Suppliers (
    SupplierID INT AUTO_INCREMENT PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL UNIQUE,
    ContactPerson VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create Products Table
CREATE TABLE IF NOT EXISTS Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    SupplierID INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

-- Insert Sample Categories
INSERT INTO Categories (CategoryName, Description) VALUES
('Electronics', 'Electronic devices and accessories'),
('Furniture', 'Office and home furniture'),
('Stationery', 'Office supplies and stationery items');

-- Insert Sample Suppliers
INSERT INTO Suppliers (SupplierName, ContactPerson, Email, Phone) VALUES
('TechSupply Inc.', 'John Smith', 'john@techsupply.com', '+1-555-0101'),
('FurniturePro Ltd.', 'Sarah Johnson', 'sarah@furniturepro.com', '+1-555-0102'),
('GlobalStationery Co.', 'Mike Chen', 'mike@globalstationery.com', '+1-555-0103');

-- Insert Sample Products
INSERT INTO Products (ProductName, CategoryID, SupplierID, Price, Quantity) VALUES
('Laptop Dell XPS 13', 1, 1, 999.99, 10),
('Wireless Mouse', 1, 1, 29.99, 50),
('USB-C Cable', 1, 1, 9.99, 100),
('Office Desk Pro', 2, 2, 399.99, 8),
('Executive Chair', 2, 2, 199.99, 20),
('Desk Lamp LED', 2, 2, 49.99, 25),
('Notebook A4', 3, 3, 5.99, 100),
('Pen Set Premium', 3, 3, 12.99, 60),
('Highlighter Pack', 3, 3, 8.99, 80);

-- Create Index for better performance
CREATE INDEX idx_category ON Products(CategoryID);
CREATE INDEX idx_supplier ON Products(SupplierID);

-- Verify Data
SELECT * FROM Categories;
SELECT * FROM Suppliers;
SELECT * FROM Products;
