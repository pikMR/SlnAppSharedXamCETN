namespace AppCETN.Models
{
    public class Ojos
    {
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        
        public string Nombre
        {
            get
            {
                return Tam + " " + Color;
            }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
