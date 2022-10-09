using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace CameraOmgeving.Models;


public class Camera
{

    [Key]
    public int id { get; set; }


    [Required]
    public string type { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
    public int? locationID{ get; set; }
    public Location? Location { get; set; }


    
    [AllowHtml]
    public string Contents { get; set; }
    public byte[] Image { get; set; }
}

