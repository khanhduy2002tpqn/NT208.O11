using System.ComponentModel.DataAnnotations;

namespace ShoeStoreProject.Models
{
    public class Category
    {
        [Key]
        public int  CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}
