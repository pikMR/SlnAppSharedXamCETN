namespace AppCETN.Models
{
    class Mujer : Humano
    {
        [Newtonsoft.Json.JsonProperty("Color de Labios")]
        public string Labios { get; set; }
        [Newtonsoft.Json.JsonProperty("Escote")]
        public bool Escote { get; set; }
    }
}
