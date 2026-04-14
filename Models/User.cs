using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class User
{
    [Key]
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    
    [Required]
    [ForeignKey("Role")]
    public int Role_ID { get; set; }
    public Role Role { get; set; }
    
}