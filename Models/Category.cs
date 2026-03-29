using System;

namespace exam.Models
{
    /// <summary>
    /// Category model class
    /// </summary>
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category() { }

        public Category(int categoryID, string categoryName, string description, DateTime createdDate)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Description = description;
            CreatedDate = createdDate;
        }
    }
}
