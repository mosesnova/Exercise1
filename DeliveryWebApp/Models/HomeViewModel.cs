using System.ComponentModel.DataAnnotations;

namespace DeliveryWebApp.Models
{
    public class HomeViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }

        [Required]
        [Display(Name = "Days To Ship")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value greater than zero")]
        public int DaysToShip { get; set; }
    }
}
