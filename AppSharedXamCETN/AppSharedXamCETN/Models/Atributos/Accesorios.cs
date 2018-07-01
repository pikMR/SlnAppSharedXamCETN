namespace AppCETN.Models
{
    public class Accesorios
    {
        [Newtonsoft.Json.JsonProperty("Fuma")]
        public bool Fumador { get; set; }
        [Newtonsoft.Json.JsonProperty("Bebe")]
        public bool Bebedor { get; set; }
        [Newtonsoft.Json.JsonProperty("Gorra")]
        public bool Gorra { get; set; }
        [Newtonsoft.Json.JsonProperty("Gafas")]
        public bool Gafas { get; set; }
        [Newtonsoft.Json.JsonProperty("Pulsera")]
        public bool Pulsera { get; set; }
        [Newtonsoft.Json.JsonProperty("Pendientes")]
        public bool Pendientes { get; set; }
        [Newtonsoft.Json.JsonProperty("Anillos")]
        public bool Anillos { get; set; }
        [Newtonsoft.Json.JsonProperty("Joyas")]
        public bool Joyas { get; set; }
        [Newtonsoft.Json.JsonProperty("Bufanda")]
        public bool Bufanda { get; set; }
    }
}
