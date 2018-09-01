using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            var ojos = obj as Ojos;
            return ojos != null &&
                   Color == ojos.Color &&
                   Tam == ojos.Tam &&
                   Nombre == ojos.Nombre;
        }

        public override int GetHashCode()
        {
            var hashCode = -1920214191;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Color);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            return hashCode;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
