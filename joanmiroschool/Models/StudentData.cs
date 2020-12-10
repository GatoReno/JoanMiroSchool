using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace joanmiroschool.Models
{
    public class StudentList {
        public IList<StudentData> StList{get;set;}
    }
    public class StudentData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_cartera")]
        public object IdCartera { get; set; }

        [JsonProperty("id_cliente")]
        public long IdCliente { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastnameP")]
        public string LastnameP { get; set; }

        [JsonProperty("lastnameM")]
        public string LastnameM { get; set; }

        [JsonProperty("alergias")]
        public string Alergias { get; set; }

        [JsonProperty("tiposangre")]
        public string Tiposangre { get; set; }

        [JsonProperty("talla")]
        public string Talla { get; set; }

        [JsonProperty("peso")]
        public string Peso { get; set; }

        [JsonProperty("precede")]
        public string Precede { get; set; }

        [JsonProperty("clave")]
        public string Clave { get; set; }

        [JsonProperty("colegiatura")]
        public long Colegiatura { get; set; }

        [JsonProperty("seguro")]
        public string Seguro { get; set; }

        [JsonProperty("grado")]
        public long Grado { get; set; }

        [JsonProperty("nivel")]
        public string Nivel { get; set; }

        [JsonProperty("observaciones")]
        public string Observaciones { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("promocion")]
        public string Promocion { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }
    }


}
