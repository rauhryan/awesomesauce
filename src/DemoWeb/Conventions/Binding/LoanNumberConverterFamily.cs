using System.Reflection;
using DemoWeb.Domain;
using FubuCore.Binding;

namespace DemoWeb.Conventions.Binding
{
    public class LoanNumberConverterFamily : StatelessConverter
    {
        public override bool Matches(PropertyInfo property)
        {
            return property.PropertyType == typeof(LoanNumber);
        
        }

        public override object Convert(IPropertyContext context)
        {
            return new LoanNumber(context.ValueAs<string>());
        }
    }
}