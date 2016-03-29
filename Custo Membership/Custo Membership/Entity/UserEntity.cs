using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Custo_Membership.Entity
{
    [Table("Users")]
    public class UserEntity
    {
        [Column]
        public int UserID { get; set; }
        [Column]
        public string UserName { get; set; }
        [Column]
        public string Password { get; set; }
        [Column]
        public string UserEmailAddress { get; set; }
    }
}