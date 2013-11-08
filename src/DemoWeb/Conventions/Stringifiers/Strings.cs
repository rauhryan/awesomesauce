using DemoWeb.Domain;
using FubuCore.Formatting;

namespace DemoWeb.Conventions.Stringifiers
{
    public class Strings : DisplayConversionRegistry
    {
        public Strings()
        {
            IfIsType<LoanNumber>()
                .ConvertBy(loanNumber=> loanNumber.ToString());
        }
    }
}