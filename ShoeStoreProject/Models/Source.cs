
using System.ComponentModel.DataAnnotations;
namespace ShoeStoreProject.Models
   

{
    public class Source
    {
        
        [Key] 
        public int SourceID { get; set; }
        public string? SourceName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
