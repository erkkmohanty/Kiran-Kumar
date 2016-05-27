using System;
using System.Reflection;

namespace MVC_ANGULAR_IGNITE_CHART.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}