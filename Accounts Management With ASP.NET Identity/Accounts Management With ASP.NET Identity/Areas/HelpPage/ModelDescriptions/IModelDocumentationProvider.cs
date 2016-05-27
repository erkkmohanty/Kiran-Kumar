using System;
using System.Reflection;

namespace Accounts_Management_With_ASP.NET_Identity.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}