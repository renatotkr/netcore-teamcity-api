// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using NetCoreTeamCity.Models;
//
//    var buildTypeModel = BuildTypeModel.FromJson(jsonString);

namespace NetCoreTeamCity.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BuildTypeModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("buildType")]
        public BuildType[] BuildType { get; set; }
    }

    public partial class BuildType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("projectName")]
        public string ProjectName { get; set; }

        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("paused")]
        public bool? Paused { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class BuildTypeModel
    {
        public static BuildTypeModel FromJson(string json) => JsonConvert.DeserializeObject<BuildTypeModel>(json, NetCoreTeamCity.Models.Converter.Settings);
    }
}
