namespace AppCETN.Models
{
    public class Calzado
    {
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        [Newtonsoft.Json.JsonProperty("Forma")]
        public string Forma { get; set; }
    }
}
