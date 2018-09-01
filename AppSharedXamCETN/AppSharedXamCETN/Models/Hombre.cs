namespace AppCETN.Models
{
    public class Hombre : Humano
    {
        public Hombre() { }

        public Hombre(Humano itemHumano) : base(itemHumano)
        {
        }

        public Hombre(Humano itemHumano, bool bigote,bool corbata) :base(itemHumano)
        {
            Bigote = bigote;
            Corbata = corbata;
        }

        [Newtonsoft.Json.JsonProperty("Bigote")]
        public bool Bigote { get; set; }
        [Newtonsoft.Json.JsonProperty("Corbata")]
        public bool Corbata { get; set; }
        [Newtonsoft.Json.JsonProperty("Sexo")]
        public override char Sexo { get { return 'H'; } }
    }
}
