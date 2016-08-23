using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ClientModel
    {
        [Required]
        [Display(Name = "Client Id")]
        [StringLength(100,ErrorMessage = "The {0} must be at least {2} characters long.",MinimumLength =6)]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Secret")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength  = 6)]
        public string Secret { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

    }
}