﻿using System.Net;

namespace NetCoreTeamCity.Locators.BuildConfiguration
{
    public class BuildConfigurationLocator : ILocator
    {
        private string _locator;
        internal BuildConfigurationLocator() { }

        public BuildConfigurationLocator Id(string buildTypeId)
        {
            _locator = new ApiLocator("id", buildTypeId).Value;
            return this;
        }

        public BuildConfigurationLocator Name(string buildConfigurationName)
        {
            _locator = new ApiLocator("name", WebUtility.UrlEncode(buildConfigurationName)).Value;
            return this;
        }

        string ILocator.GetLocatorQueryString()
        {
            return $"buildType:({_locator})";
        }
    }
}
