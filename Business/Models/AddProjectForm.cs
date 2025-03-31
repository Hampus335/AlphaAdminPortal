using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class AddProjectForm
    {

        [DataType(DataType.Text)]
        [Display(Name = "Project Name", Prompt = "Enter project name")]
        [Required(ErrorMessage = "Required")]
        public string ProjectName { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Client Name", Prompt = "Select a client")]
        [Required(ErrorMessage = "Required")]
        public string ClientName { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Description", Prompt = "Enter description")]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date", Prompt = "Enter start date")]
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date", Prompt = "Enter end date")]
        [Required(ErrorMessage = "Required")]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Budget", Prompt = "Enter budget amount")]
        [Required(ErrorMessage = "Required")]
        public decimal Budget { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
