namespace AppCETN.Models
{
    public class PrendaInferior
    {
        [Newtonsoft.Json.JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Color;
        }
    }
}
