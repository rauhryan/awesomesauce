using System;
using System.Collections.Generic;
using System.Reflection;
using FubuCore.Reflection;

namespace AwesomeSauce
{
    public class Walker
    {
        public void X()
        {
            var type = typeof (object);
            foreach (var propertyInfo in type.GetProperties())
            {
                if(isEntity(propertyInfo))
                {
                    var a = new SingleProperty(propertyInfo);
                    
                    //return some NestedAction? 
                }
            }
        }

        bool isEntity(Accessor accessor)
        {
            return true;
        }

        IEnumerable<Accessor> getChildDocs(Accessor accessor)
        {
            
        }
    }

    public class Loan
    {
        public LoanNumber Number { get; set; }
    }
    public class LoanNumber
    {
        public string Region { get; set; }
    }
}