using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeStoreProject.Models
{
    public class ProductRepo
    {
        [Key]
        public int? RepoProductID { get; set; }

        [ForeignKey("Repo")]
        public int RepoID { get; set; }
        public string? ProductName { get; set; }

        [ForeignKey("Product")]
        public int? ProductID { get; set; }

        [ForeignKey("Source")]
        public int? SourceID { get; set; }
        public int? Quantity { get; set; }

        public virtual Repo? Repo { get; set; }
        public virtual Product? Cart { get; set; }
        public virtual Source? Source { get; set; }

    }
}
