using System;
using System.Collections.Generic;
using System.Text;
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using NetCoreTeamCity.Models;
//
//    var repoResponse = RepoResponse.FromJson(jsonString);

namespace NetCoreTeamCity.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BranchResponse
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("branch")]
        public Branch[] Branch { get; set; }
    }

    public partial class Branch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }
    }

    public partial class RepoResponse
    {
        public static RepoResponse FromJson(string json) => JsonConvert.DeserializeObject<RepoResponse>(json, NetCoreTeamCity.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RepoResponse self) => JsonConvert.SerializeObject(self, NetCoreTeamCity.Models.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal,
                },
            },
        };
    }
    public enum BranchPolicyEnum
    {
        VCS_BRANCHES,
        ACTIVE_VCS_BRANCHES,
        HISTORY_BRANCHES,
        ACTIVE_HISTORY_BRANCHES,
        ACTIVE_HISTORY_AND_ACTIVE_VCS_BRANCHES,
        ALL_BRANCHES
    }
}

