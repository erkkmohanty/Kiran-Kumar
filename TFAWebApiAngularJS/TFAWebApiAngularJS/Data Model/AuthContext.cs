using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TFAWebApiAngularJS.Data_Model
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("AuthContext")
        {
        }
    }

    
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(16)]
        public string PSK { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PSKCreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
    }
}