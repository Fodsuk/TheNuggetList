using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TheNuggetList.WebUI.ValidationAttributes;
using System.ComponentModel;

namespace TheNuggetList.WebUI.ViewModels
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class RegistrationViewModel
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}