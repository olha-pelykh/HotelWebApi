using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models.ViewModels
{
    public class UpdateHotelViewModel
    {
        [Required(ErrorMessage = "Hotel name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Hotel name must be between 2 and 100 characters")]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
    }
}