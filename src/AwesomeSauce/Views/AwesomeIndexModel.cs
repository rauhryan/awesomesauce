using System.Collections;
using System.Collections.Generic;

namespace AwesomeSauce.Views
{
    public class AwesomeIndexModel
    {
        public IEnumerable<object> Models { get; set; }
        public string Header { get; set; }

        public string CreateUrl { get; set; }
    }
}