using System.Collections.Generic;
using NetCoreTeamCity.Locators.BuildType;
using NetCoreTeamCity.Models;

namespace NetCoreTeamCity.Services
{
    public interface IBuildTypeService
    {
        IBuildTypeService Set(string buildType);
        string[] GetBranches(BranchPolicyEnum policy);
        IList<BuildType> Find(BuildTypeLocator locator, int? count = null);
    }
}