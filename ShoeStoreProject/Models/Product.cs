using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeStoreProject.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }
        public string? ProductName { get; set; }

        [ForeignKey("Category")]
        public int? CategoryID { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }

        [ForeignKey("Source")]
        public int? SourceID { get; set; }
        public int? ImportPrice { get; set; }
        public Decimal? Discount { get; set; } = 0;
        public string? ImageUrl { get; set; }
        public string? Color { get; set; }
        public Boolean? Available { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Source? Source { get; set; }




    }
}
