using System;
using Newtonsoft.Json;

namespace joanmiroschool.Models
{
    public class StatementData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("id_alumno")]
        public long IdAlumno { get; set; }

        [JsonProperty("id_cliente")]
        public long IdCliente { get; set; }

        [JsonProperty("concepto")]
        public string Concepto { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("prorroga")]
        public string Prorroga { get; set; }

        [JsonProperty("saldo_pendiente")]
         public long SaldoPendiente { get; set; }

        [JsonProperty("saldo_afavor")]
         public long SaldoAfavor { get; set; }

        [JsonProperty("tipo_pago")]
        public string TipoPago { get; set; }

        [JsonProperty("referencia")]
        public string Referencia { get; set; }
    }
}
