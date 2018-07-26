namespace AppCETN.Models
{
    public class Mujer : Humano
    {
        public Mujer(Humano itemHumano) : base(itemHumano)
        {
        }

        public Mujer(Humano itemHumano,string labios, bool scote) : base(itemHumano)
        {
            Labios = labios;
            Escote = scote;
        }

        public Mujer() { }

        [Newtonsoft.Json.JsonProperty("Labios")]
        public string Labios { get; set; }
        [Newtonsoft.Json.JsonProperty("Escote")]
        public bool Escote { get; set; }
        public override char Sexo { get { return 'M'; } }
    }
}
