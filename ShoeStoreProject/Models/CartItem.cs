using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeStoreProject.Models
{
    public class CartItem
    {
        [Key]
        public int ItemID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [ForeignKey("Cart")]
        public int CartID { get; set; }
        public int Quantily { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Product? Cart { get; set; }

    }
}
