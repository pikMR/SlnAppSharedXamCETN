using System.Threading.Tasks;

namespace AppCETN.Models
{
    public class Humano : Entidad
    {
        [Newtonsoft.Json.JsonProperty("Apodo")]
        public string Apodo { get; set; }
        [Newtonsoft.Json.JsonProperty("Apellido")]
        public string Apellido { get; set; }
        [Newtonsoft.Json.JsonProperty("Voz")]
        public string Voz { get; set; }
        [Newtonsoft.Json.JsonProperty("Tez")]
        public string Tez { get; set; }
        [Newtonsoft.Json.JsonProperty("Estatura")]
        public string Estatura { get; set; }
        [Newtonsoft.Json.JsonProperty("Fisionomia")]
        public string Fisionomia { get; set; }
        [Newtonsoft.Json.JsonProperty("Pecho")]
        public string Pecho { get; set; }
        [Newtonsoft.Json.JsonProperty("Culo")]
        public string Culo { get; set; }
        [Newtonsoft.Json.JsonProperty("Tatuaje")]
        public string Tatuaje { get; set; }
        [Newtonsoft.Json.JsonProperty("Cabello")]
        public Cabello Cabello { get; set; }
        [Newtonsoft.Json.JsonProperty("Ojos")]
        public Ojos Ojos { get; set; }
        [Newtonsoft.Json.JsonProperty("Orejas")]
        public Orejas Orejas { get; set; }
        [Newtonsoft.Json.JsonProperty("Accesorios")]
        public Accesorios Accesorios { get; set; }
        [Newtonsoft.Json.JsonProperty("PrendaSuperior")]
        public PrendaSuperior PrendaSuperior { get; set; }
        [Newtonsoft.Json.JsonProperty("PrendaInferior")]
        public PrendaInferior PrendaInferior { get; set; }
        [Newtonsoft.Json.JsonProperty("Calzado")]
        public Calzado Calzado { get; set; }
        public virtual char Sexo { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Humano(Humano itemHumano)
        {
            Fecha = itemHumano.Fecha;
            IdEntidad = itemHumano.IdEntidad;
            Ojos = itemHumano.Ojos;
            Cabello = itemHumano.Cabello;
            Pecho = itemHumano.Pecho;
            Culo = itemHumano.Culo;
            Fisionomia = itemHumano.Fisionomia;
            PrendaSuperior = itemHumano.PrendaSuperior;
            PrendaInferior = itemHumano.PrendaInferior;
            Nombre = itemHumano.Nombre;
            Descripcion = itemHumano.Descripcion;
            Photo = itemHumano.Photo;

            if (string.IsNullOrEmpty(Fecha))
                Fecha = System.DateTime.Now.ToLocalTime().ToString();
        }

        public Humano():base() { }

        public static implicit operator Humano(Task<Humano> v)
        {
            return v.Result;
        }
    }
}
