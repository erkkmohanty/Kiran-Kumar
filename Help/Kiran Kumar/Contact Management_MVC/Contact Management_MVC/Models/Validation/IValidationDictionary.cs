using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact_Management_MVC.Models.Validation
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
    }
}