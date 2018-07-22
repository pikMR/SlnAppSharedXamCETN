namespace AppCETN.Models
{
    public class Mujer : Humano
    {
        [Newtonsoft.Json.JsonProperty("Labios")]
        public string Labios { get; set; }
        [Newtonsoft.Json.JsonProperty("Escote")]
        public bool Escote { get; set; }
        public char Sexo { get { return 'M'; } }
    }
}
