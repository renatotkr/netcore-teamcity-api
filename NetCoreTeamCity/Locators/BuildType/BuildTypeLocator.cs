using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreTeamCity.Locators.BuildType
{
    public class BuildTypeLocator : ILocator
    {
        private List<string> _locator = new List<string>();
        public BuildTypeLocator() { }
        public BuildTypeLocator Template(string template)
        {
            _locator.Add(new ApiLocator("template", template).Value);
            return this;
        }

        public string GetLocatorQueryString()
        {
            var loc = String.Join(",", _locator);
            return $"locator={loc}";
        }
    }
}
