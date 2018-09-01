using System.Collections.Generic;

namespace AppCETN.Models
{
    public class PrendaSuperior
    {
        [Newtonsoft.Json.JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }

        public override bool Equals(object obj)
        {
            var superior = obj as PrendaSuperior;
            return superior != null &&
                   Nombre == superior.Nombre &&
                   Color == superior.Color;
        }

        public override int GetHashCode()
        {
            var hashCode = -151407816;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Color);
            return hashCode;
        }

        public override string ToString()
        {
            return Nombre + " " + Color;
        }
    }
}
