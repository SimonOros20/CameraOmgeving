using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace CameraOmgeving.Models
{
    public class Profile
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public List<User> users { get; set; }
        public int? userID { get; set; }
    }
}
