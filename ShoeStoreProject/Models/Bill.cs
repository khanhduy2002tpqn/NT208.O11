using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeStoreProject.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        public string? Name { get; set; }

        [ForeignKey("User")]
        public string? UserID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set;}

        [ForeignKey("Cart")]
        public int CartID { get; set; }

        public virtual Users? User { get; set; }

        public virtual Cart? Cart { get; set; }
    }
}
