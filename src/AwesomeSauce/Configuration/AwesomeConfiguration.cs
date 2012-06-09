using System;
using System.Reflection;
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
            SetIdValue = (o, value) =>
            {
                var pi = o.GetType().GetProperty("Id", BindingFlags.Instance | BindingFlags.Public);
                pi.SetValue(o, value, null);
            };
            IdField = arg => arg.Accessor.Name.Equals("Id");
        }

        public static Func<Type, bool> AwesomeEntities { get; set; }

        public static string TagProfile { get; set; }

        public static Func<object, string> GetIdValue;

        public static Action<object, object> SetIdValue;

        public static Func<AccessorDef, bool> IdField;
    }
} 