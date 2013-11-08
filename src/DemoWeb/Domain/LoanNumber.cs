using System.Diagnostics;

namespace DemoWeb.Domain
{
    [DebuggerDisplay("{_loanNumber}")]
    public class LoanNumber
    {
        readonly string _loanNumber;

        public LoanNumber(string loanNumber)
        {
            _loanNumber = loanNumber;
        }

        protected bool Equals(LoanNumber other)
        {
            return string.Equals(_loanNumber, other._loanNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LoanNumber) obj);
        }

        public override int GetHashCode()
        {
            return (_loanNumber != null ? _loanNumber.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return _loanNumber;
        }
    }
}