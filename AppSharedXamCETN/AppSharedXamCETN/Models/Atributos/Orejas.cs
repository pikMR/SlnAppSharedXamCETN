using System.Collections.Generic;

namespace AppCETN.Models
{
    public class Orejas
    {
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        [Newtonsoft.Json.JsonProperty("Forma")]
        public string Forma { get; set; }

        public override bool Equals(object obj)
        {
            var orejas = obj as Orejas;
            return orejas != null &&
                   Tam == orejas.Tam &&
                   Forma == orejas.Forma;
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
