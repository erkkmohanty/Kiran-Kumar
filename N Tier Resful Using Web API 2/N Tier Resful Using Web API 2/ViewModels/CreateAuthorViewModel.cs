using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace N_Tier_Resful_Using_Web_API_2.ViewModels
{
    public class CreateAuthorViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}