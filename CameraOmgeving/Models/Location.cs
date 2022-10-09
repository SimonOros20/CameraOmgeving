using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CameraOmgeving.Models
{
    public class Location
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public int? cameraID { get; set; }
        public int? mapId { get; set; }

        public List<Camera>? Cameras { get; set; }
        public Map? Map { get; set; }
    }
}
