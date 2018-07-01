namespace AppCETN.Models
{
    class Hombre : Humano
    {
        [Newtonsoft.Json.JsonProperty("Bigote")]
        public bool Bigote { get; set; }
        [Newtonsoft.Json.JsonProperty("Corbata")]
        public bool Corbata { get; set; }
    }
}
