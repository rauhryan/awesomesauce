using System;
using AwesomeSauce.Domain;
using FubuCore;

namespace AwesomeSauce.Configuration
{
    public static class AwesomeConfiguration
    {
        static AwesomeConfiguration()
        {
            AwesomeEntities = t => t.CanBeCastTo<AwesomeEntity>();
            TagProfile = "AWESOME";
        }

        public static Func<Type, bool> AwesomeEntities { get; set; }

        public static string TagProfile { get; set; }
    }
} 