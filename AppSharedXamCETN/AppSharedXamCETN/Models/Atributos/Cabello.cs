namespace AppCETN.Models
{
    public class Cabello
    {
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }

        public string Nombre
        {
            get
            {
                return Color + " " + Tam;
            }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
