using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models.ViewModels
{
    public class HotelViewModel
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Hotel Name")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;
        
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        
        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }
    }
}