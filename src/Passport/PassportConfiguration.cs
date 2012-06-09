using System;
using FubuMVC.Core.Registration.Nodes;

namespace Passport
{
    public static class PassportConfiguration
    {
        static PassportConfiguration()
        {
            RestrictedAction = bc => true;

        }

        public static Func<BehaviorChain, bool> RestrictedAction { get; set; }

        public static object LogonRouteInputModel { get; set; }

        public static Type HomeInputModel { get; set; }

        //a way to turn on SAML | FORMS | etc
    }
}