using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ViewEngines.Razor;

namespace Engageatron.Web
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "Common";
       
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Common";

        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}