using System;
using NetCoreTeamCity.Api;

namespace NetCoreTeamCity.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var teamCity = new TeamCity(args[0], args[1], args[2]);

            var build = teamCity.Builds.Get(106731);
            Console.WriteLine(build.Number);

            var builds = teamCity.Builds.Find(
                By.Build.QueuedDateAfter(DateTime.Now.AddDays(-1)),
                Include.Build
                    .BuildType()
                    .Triggered()
                    .LastChanges()
                    .Agent()
                    .Properties());
            Console.WriteLine(builds.Count);

            var queuedBuilds = teamCity.QueuedBuilds.Find(Include.Build.QueuedDate());
            Console.ReadLine();
        }
    }
}
