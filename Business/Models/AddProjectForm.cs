using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class AddProjectForm
{
    [DataType(DataType.Text)]
    [Display(Name = "Project Name", Prompt = "Enter project name")]
    [Required(ErrorMessage = "Required")]
    public string ProjectName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Client Name", Prompt = "Enter client name")]
    [Required(ErrorMessage = "Required")]
    public string ClientName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Description", Prompt = "Enter description")]
    public string? Description { get; set; }
}