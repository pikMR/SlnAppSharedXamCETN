using System.Collections.Generic;

namespace AppCETN.Models
{
    public class Nariz
    {
        [Newtonsoft.Json.JsonProperty("Tamaño")]
        public string Tam { get; set; }
        [Newtonsoft.Json.JsonProperty("Forma")]
        public string Forma { get; set; }

        public override bool Equals(object obj)
        {
            var nariz = obj as Nariz;
            return nariz != null &&
                   Tam == nariz.Tam &&
                   Forma == nariz.Forma;
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
