using System;
using System.Collections.Generic;
using Newtonsoft.Json; 

namespace joanmiroschool.Models
{
    public class AccountList
    {
        public IList<AccountData> AccList { get; set; }
    }
    
    public class AccountData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_cartera")]
        public long IdCartera { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("escolaridad")]
        public string Escolaridad { get; set; }

        [JsonProperty("ocupacion")]
        public string Ocupacion { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("oficina")]
        public string Oficina { get; set; }

        [JsonProperty("parentesco")]
        public string Parentesco { get; set; }

        [JsonProperty("trabajo")]
        public string Trabajo { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }
    }
}
