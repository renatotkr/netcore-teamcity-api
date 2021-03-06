﻿using NetCoreTeamCity.Locators.Build;
using NetCoreTeamCity.Locators.BuildConfiguration;
using NetCoreTeamCity.Locators.Project;
using NetCoreTeamCity.Models;
using System.Collections.Generic;

namespace NetCoreTeamCity.Services
{
    public interface IQueuedBuildService
    {
        Build Get(long buildId);
        IList<Build> Find(BuildConfigurationLocator locator, BuildField fields = null, int count = 100);
        IList<Build> Find(ProjectLocator locator, BuildField fields = null, int count = 100);
        IList<Build> Find(BuildField fields = null, int count = 100);
        IList<Agent> CompatibleAgents(long buildId);
        Build Run(string buildTypeId, string branchName = null, string comment = null);
        Build Run(BuildRunOptions options);
        Build Cancel(long buildId, string comment, bool reAddToTheQueue = false);

    }
}
