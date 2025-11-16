using System.ComponentModel.DataAnnotations;

namespace MVC_Company_Demo_Project.Web.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Format for Email")]
        public string Email { get; set; }
    }
}
