using MessagePack;
using Microsoft.Build.Framework;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CameraOmgeving.Models
{
    public class Loginpage
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
