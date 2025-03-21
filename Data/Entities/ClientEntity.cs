namespace Data.Entities;

public class Client
{
    public int Id { get; set; } 
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Location { get; set; } = null!;
}
