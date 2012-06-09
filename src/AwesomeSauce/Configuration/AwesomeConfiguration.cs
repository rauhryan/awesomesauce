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
            GetIdValue = o =>
            {
                var pi = o.GetType().GetProperty("Id", BindingFlags.Instance | BindingFlags.Public);
                return pi.GetValue(o, null).ToString();

            };
        }

        public static Func<Type, bool> AwesomeEntities { get; set; }

        public static string TagProfile { get; set; }

        public static Func<object, string> GetIdValue;
        

        public static void SetIdValue(object o, object value)
        {
            var pi = o.GetType().GetProperty("Id", BindingFlags.Instance | BindingFlags.Public);
            pi.SetValue(o, value, null);
        }

        public static bool IdField(AccessorDef arg)
        {
            return arg.Accessor.Name.Equals("Id");
        }
    }
} 