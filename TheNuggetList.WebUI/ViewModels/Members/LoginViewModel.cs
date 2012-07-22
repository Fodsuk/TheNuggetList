using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TheNuggetList.WebUI.ValidationAttributes;
using System.ComponentModel;

namespace TheNuggetList.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}