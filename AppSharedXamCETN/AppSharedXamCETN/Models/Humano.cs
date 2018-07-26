using System;
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
        [Newtonsoft.Json.JsonProperty("TezPiel")]
        public string Tez { get; set; }
        [Newtonsoft.Json.JsonProperty("Estatura")]
        public string Estatura { get; set; }
        [Newtonsoft.Json.JsonProperty("Fisionomia")]
        public string Fisionomia { get; set; }
        [Newtonsoft.Json.JsonProperty("Pecho")]
        public string Pecho { get; set; }
        [Newtonsoft.Json.JsonProperty("Nalgas")]
        public string Culo { get; set; }
        [Newtonsoft.Json.JsonProperty("Tatuaje")]
        public string Tatuaje { get; set; }
        [Newtonsoft.Json.JsonProperty("Cabello")]
        public Cabello Pelo { get; set; }
        [Newtonsoft.Json.JsonProperty("Ojos")]
        public Ojos Ojo { get; set; }
        [Newtonsoft.Json.JsonProperty("Orejas")]
        public Orejas Oreja { get; set; }
        [Newtonsoft.Json.JsonProperty("Accesorios")]
        public Accesorios Decoracion { get; set; }
        [Newtonsoft.Json.JsonProperty("PrendaSuperior")]
        public PrendaSuperior Prenda1 { get; set; }
        [Newtonsoft.Json.JsonProperty("PrendaInferior")]
        public PrendaInferior Prenda2 { get; set; }
        [Newtonsoft.Json.JsonProperty("Calzado")]
        public Calzado Pie { get; set; }
        public virtual char Sexo { get; set; }

        //public string AtribSeleccionado { get; set; }

        private void SetEstatura()
        {
            Estatura = (Altura * 100).ToString() + " cm";
        }
        public override string ToString()
        {
            /*if (!string.IsNullOrEmpty(AtribSeleccionado))
            {
                return base.ToString() + AtribSeleccionado;
            }*/
                return base.ToString();
        }

        public Humano(Humano itemHumano)
        {
            Fecha = itemHumano.Fecha;
            IdEntidad = itemHumano.IdEntidad;
            Ojo = itemHumano.Ojo;
            Pelo = itemHumano.Pelo;
            Pecho = itemHumano.Pecho;
            Culo = itemHumano.Culo;
            Fisionomia = itemHumano.Fisionomia;
            Prenda1 = itemHumano.Prenda1;
            Prenda2 = itemHumano.Prenda2;
            Nombre = itemHumano.Nombre;
            Descripcion = itemHumano.Descripcion;
        }

        public Humano() { }

        public static implicit operator Humano(Task<Humano> v)
        {
            return v.Result;
        }
    }
}
