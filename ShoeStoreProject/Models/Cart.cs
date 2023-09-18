using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeStoreProject.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set;}

        public virtual Users? User { get; set; }
    }
}
