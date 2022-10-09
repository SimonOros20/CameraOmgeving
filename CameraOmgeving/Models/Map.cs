using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CameraOmgeving.Models
{
    public class Map
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        public int? LocationID { get; set; }
        public int? userID { get; set; }
        public List<Location>? Locations { get; set; }
        public User User { get; set; }

    }
}
