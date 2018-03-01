using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetCoreTeamCity.Clients;
using NetCoreTeamCity.Locators;
using NetCoreTeamCity.Locators.Build;
using NetCoreTeamCity.Locators.BuildType;
using NetCoreTeamCity.Models;

namespace NetCoreTeamCity.Services
{
    internal class BuildServiceType : IBuildTypeService
    {
        protected readonly ITeamCityApiClient ApiClient;
        private string _buildType;
        private readonly string _endpoint = "buildTypes";
        public BuildServiceType(ITeamCityApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public IBuildTypeService Set(string buildType)
        {
            _buildType = buildType;
            return this;
        }

        public string[] GetBranches(BranchPolicyEnum policy)
        {
            return (ApiClient.Get<BranchResponse>($"{GetUri()}branches?locator=policy:{policy.ToString()}").Branch.Select(x => x.Name.ToString()).ToArray());
        }

        public IList<BuildType> Find(BuildTypeLocator locator, int? count = null)
        {
            var query = GetQuery(locator, count);
            return ApiClient.Get<BuildTypeModel>($"{_endpoint}{query}").BuildType;
        }

        protected string GetQuery(ILocator locator, int? count)
        {
            var query = "?";
            if (locator != null) query += $"{locator.GetLocatorQueryString()}";
            if (count.HasValue)
                query += $",count:{count}";
            return query;
        }

        //public string[] GetBuildType

        private string GetUri()
        {
            if (string.IsNullOrEmpty(_buildType))
                throw new Exception("Set the build type");
            return $"{_endpoint}/{_buildType}/";
        }
    }
}
