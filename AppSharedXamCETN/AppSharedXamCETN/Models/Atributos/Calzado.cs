using System.Collections.Generic;

namespace AppCETN.Models
{
    public class Calzado
    {
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        [Newtonsoft.Json.JsonProperty("Forma")]
        public string Forma { get; set; }

        public override bool Equals(object obj)
        {
            var calzado = obj as Calzado;
            return calzado != null &&
                   Tam == calzado.Tam &&
                   Forma == calzado.Forma;
        }

        public override int GetHashCode()
        {
            var hashCode = -1564739317;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Forma);
            return hashCode;
        }
    }
}
