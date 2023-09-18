using System.ComponentModel.DataAnnotations;
namespace ShoeStoreProject.Models
{
    public class Repo
    {
        [Key]
        public int RepoID { get; set; }
        public string? RepoName { get; set; }
        public string? Address { get; set; }
    }
}
