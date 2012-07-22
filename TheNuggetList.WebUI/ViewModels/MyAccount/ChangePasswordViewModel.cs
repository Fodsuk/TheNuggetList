using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TheNuggetList.WebUI.ValidationAttributes;
using System.ComponentModel;

namespace TheNuggetList.WebUI.ViewModels
{
	[PropertiesMustMatch("NewPassword", "ConfirmNewPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class ChangePasswordViewModel
    {
		[Required]
		[DataType(DataType.Password)]
		[MaxLength(100)]
		[DisplayName("New password")]
		public string NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[MaxLength(100)]
		[DisplayName("Confirm new password")]
		public string ConfirmNewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[MaxLength(100)]
		[DisplayName("Current password")]
		public string CurrentPassword { get; set; }
    }
}