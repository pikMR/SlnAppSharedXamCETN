namespace AppCETN.Models
{
    public class Entidad
    {
        [Newtonsoft.Json.JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }
        [Newtonsoft.Json.JsonProperty("Altura")]
        public double Altura { get; set; }
        [Newtonsoft.Json.JsonProperty("Descripcion")]
        public string Descripcion { get; set; }
        [Newtonsoft.Json.JsonProperty("IdEntidad")]
        public int IdEntidad{ get; set; }
        [Newtonsoft.Json.JsonProperty("Fecha")]
        public string Fecha { get; set; }
        [Newtonsoft.Json.JsonProperty("Photo")]
        public string Photo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return Nombre + " | " +Descripcion;
        }
    }
}
