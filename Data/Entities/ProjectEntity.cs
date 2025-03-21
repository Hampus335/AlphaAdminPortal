namespace Data.Entities;

class ProjectEntity
{
    public class Project
    {
        public int Id { get; set; } 
        public int ClientId { get; set; }   
        public string ClientName { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }

        public Client Client { get; set; }
    }
}
