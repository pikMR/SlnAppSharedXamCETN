namespace AppCETN.Models
{
    public class Entidad
    {
        [Newtonsoft.Json.JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public double Altura { get; set; }
        [Newtonsoft.Json.JsonProperty("Desc")]
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Nombre + " | " +Descripcion;
        }
    }
}
