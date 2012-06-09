using System;
using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuMVC.Core.Registration;

namespace AwesomeSauce.Configuration.Actions
{
    public static class TypePoolExtensions
    {
        public static IEnumerable<Type>  EntityTypes(this TypePool pool)
        {
            return (from type in pool.TypesMatching(AwesomeConfiguration.AwesomeEntities)
                    where type.IsConcrete()
                    select  type).Distinct();
        }
    }
}