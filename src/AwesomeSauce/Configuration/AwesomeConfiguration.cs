using System;
using System.Reflection;
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

 
        public static string GetIdValue(object o)
        {
            var pi = o.GetType().GetProperty("Id", BindingFlags.Instance | BindingFlags.Public);
            return pi.GetValue(o, null).ToString();
        }

        public static bool IdField(AccessorDef arg)
        {
            return arg.Accessor.Name.Equals("Id");
        }
    }
} 