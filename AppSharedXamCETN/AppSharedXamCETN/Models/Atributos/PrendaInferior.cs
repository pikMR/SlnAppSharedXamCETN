using System.Collections.Generic;

namespace AppCETN.Models
{
    public class PrendaInferior
    {
        [Newtonsoft.Json.JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Color { get; set; }

        public override bool Equals(object obj)
        {
            var inferior = obj as PrendaInferior;
            return inferior != null &&
                   Nombre == inferior.Nombre &&
                   Color == inferior.Color;
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
