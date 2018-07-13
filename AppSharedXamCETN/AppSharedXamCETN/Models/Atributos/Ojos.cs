
namespace AppCETN.Models
{
    public class Ojos
    {
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }

        public override string ToString()
        {
            return Color;
        }
    }
}
