namespace WebAPI.Requests;

public class UpdateUser
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
}