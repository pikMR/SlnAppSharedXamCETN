namespace AppCETN.Models
{
    class Nariz
    {
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        [Newtonsoft.Json.JsonProperty("Forma")]
        public string Forma { get; set; }
    }
}
