using System.Collections.Generic;

namespace AppCETN.Models
{
    public class Boca
    {
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        [Newtonsoft.Json.JsonProperty("Color")]
        public string Labios { get; set; }

        public override bool Equals(object obj)
        {
            var boca = obj as Boca;
            return boca != null &&
                   Tam == boca.Tam &&
                   Labios == boca.Labios;
        }

        public override int GetHashCode()
        {
            var hashCode = -1993078934;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Labios);
            return hashCode;
        }
    }
}
