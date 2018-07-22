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
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
