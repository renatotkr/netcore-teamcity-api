using Microsoft.Extensions.DependencyInjection;
using NetCoreTeamCity.Clients;
using NetCoreTeamCity.Services;

namespace NetCoreTeamCity.Api
{
    public class TeamCity : ITeamCity
    {
        public TeamCity(string host, string userName, string password, bool usingSSL = true)
        {
            var connectionConfig = new TeamCityConnectionSettingsBuilder().ToHost(host).UsingSSL(usingSSL).AsUser(userName, password).Build();
            var bootstrapper = new ServiceCollection()
                .AddSingleton<IBuildService, BuildService>()
                .AddSingleton<IQueuedBuildService, QueuedBuildService>()
                .AddSingleton<IChangeService,ChangeService>()
                .AddSingleton<ITeamCityApiClient, TeamCityApiClient>()
                .AddSingleton(s=>connectionConfig)
                .AddSingleton<IBuildTagsService, BuildTagsService>()
                .AddSingleton<IBuildPinningService, BuildPinningService>()
                .AddSingleton<IHttpClientWrapperFactory, HttpClientWrapperFactory>()
                .BuildServiceProvider();

            Builds = bootstrapper.GetService<IBuildService>();
            QueuedBuilds = bootstrapper.GetService<IQueuedBuildService>();
            Changes = bootstrapper.GetService<IChangeService>();
        }

        public IBuildService Builds { get; }
        public IQueuedBuildService QueuedBuilds { get; }
        public IChangeService Changes { get; }
    }
}
