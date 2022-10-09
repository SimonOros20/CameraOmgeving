using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CameraOmgeving.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public Profile? Profile { get; set; }
        public int? ProfileID { get; set; }






    }
}
