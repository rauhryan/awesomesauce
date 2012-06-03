using System;
using FubuCore;
using FubuMVC.Core.UI.Configuration;

namespace AwesomeSauce.Configuration
{
    public static class AwesomeConfiguration
    {
        static AwesomeConfiguration()
        {
            AwesomeEntities = t => t.Namespace.Contains("Domain");
            TagProfile = "AWESOME";
        }

        public static Func<Type, bool> AwesomeEntities { get; set; }

        public static string TagProfile { get; set; }

        public static bool IdField(AccessorDef arg)
        {
            return arg.Accessor.Name.Equals("Id");
        }
    }
} 