using System.Collections.Generic;
using AppCETN.Models;
using System.Threading.Tasks;
using AppSharedXamCETN.Infrastructure.Services;

namespace AppCETN.Services
{
    class CETNDomainService
    {
        // datos de la aplicación estaticos que hacen referencia a los valores de los modelos.
        private static List<Ojos> instancialistaOjos = null;
        private static List<Cabello> instancialistaCabello = null;
        private static List<string> instanciaListaColorPlural = null;
        private static List<string> instanciaListaColor = null;
        private static List<string> instanciaListaTam = null;
        private static List<string> instanciaListaTamPlural = null;
        private static List<PrendaInferior> instanciaListaPrendaInf = null;
        private static List<PrendaSuperior> instanciaListaPrendaSup = null;
        private static List<string> instanciaFisionomia = null;
        private static List<string> instanciaListaColorCabello = null;
        private static List<string> instanciaListaTamCabello = null;

        /// <summary>
        /// Recoge los datos del json disponible y los diferencia según su tipo
        /// </summary>
        /// <returns>Nueva lista de tipo Humano con la instancía especifica según su tipo</returns>
        public static IEnumerable<Humano> GetAllHombresJSON()
        {
            List<Humano> mixlista = new List<Humano>();
            var lista = CETNHumanoService.GetAllHombresJSON();
            foreach(var human in lista)
            {
                if (human.Sexo == 'M')
                {
                    Mujer nueva = new Mujer(human);
                    mixlista.Add(nueva);
                }
                else
                {
                    Hombre nuevo = new Hombre(human);
                    mixlista.Add(nuevo);
                }
            }
            return mixlista;
        }

        /// <summary>
        /// Actualización del json a generar,
        /// obtiene los datos y se comunica con el servicio adecuado
        /// que se encargará de generar el nuevo json y guardarlo.
        /// </summary>
        /// <param name="data">Lista de elementos de tipo Humano</param>
        /// <returns></returns>
        public static async Task<bool> InsertarHumanoJSON(object data)
        {
            return await CETNHumanoService.GenerarHumanoJSON(data);
        }

        #region ObtenerValores para picker
        public static List<Ojos> ObtenerValoresOjos()
        {
            if (instancialistaOjos != null)
            {
                return instancialistaOjos;
            }

            List<string> combo_color = getComboOjosColor_plural();
            List<string> combo_tam = getComboTam_plural();
            instancialistaOjos = new List<Ojos>();

            combo_color.ForEach(c =>
            {
                combo_tam.ForEach(t =>
                {
                    instancialistaOjos.Add(new Ojos() { Color = c , Tam = t });
                });
            });
            return instancialistaOjos;
        }

        internal static List<Cabello> ObtenerValoresCabello()
        {
            if (instancialistaCabello != null)
            {
                return instancialistaCabello;
            }

            List<string> combo_color = getComboColorCabello();
            List<string> combo_tam = getComboTamCabello();
            instancialistaCabello = new List<Cabello>();

            combo_color.ForEach(c =>
            {
                combo_tam.ForEach(t =>
                {
                    instancialistaCabello.Add(new Cabello() { Color = c, Tam = t });
                });
            });
            return instancialistaCabello;
        }

        internal static List<string> ObtenerValoresFisionomia() => getFisionomia();

        internal static List<PrendaSuperior> ObtenerValoresPrendaSup() => getComboPrendaSup();

        internal static List<string> ObtenerValoresNalgas() => getComboTam();

        internal static List<PrendaInferior> ObtenerValoresPrendaInf() => getComboPrendaInf();

        internal static List<string> ObtenerValoresPecho() => getComboTam();

        #endregion

        #region ObtenerValores para Literales
        private static List<string> getComboTam()
        {
            if (instanciaListaTam != null)
                return instanciaListaTam;

            return instanciaListaTam = new List<string>() {
                LiteralesService.GetLiteral("tam_1"),
                LiteralesService.GetLiteral("tam_2"),
                LiteralesService.GetLiteral("tam_3")
            };
        }

        private static List<string> getComboTam_plural()
        {
            if (instanciaListaTamPlural != null)
                return instanciaListaTamPlural;

            return instanciaListaTamPlural = new List<string>() {
                LiteralesService.GetLiteral("tam_1_plural"),
                LiteralesService.GetLiteral("tam_2_plural"),
                LiteralesService.GetLiteral("tam_3_plural")
            };
        }

        private static List<string> getComboColor()
        {
            if (instanciaListaColor != null)
                return instanciaListaColor;

            return instanciaListaColor=new List<string>() {
                LiteralesService.GetLiteral("color_marron"),
                LiteralesService.GetLiteral("color_verde"),
                LiteralesService.GetLiteral("color_azul")
            };
        }

        private static List<string> getComboColorCabello()
        {
            if (instanciaListaColorCabello != null)
                return instanciaListaColorCabello;

            return instanciaListaColorCabello = new List<string>() {
                LiteralesService.GetLiteral("color_cabello_1"),
                LiteralesService.GetLiteral("color_cabello_2"),
                LiteralesService.GetLiteral("color_cabello_3")
            };
        }

        private static List<string> getComboTamCabello()
        {
            if (instanciaListaTamCabello != null)
                return instanciaListaTamCabello;

            return instanciaListaTamCabello = new List<string>() {
                LiteralesService.GetLiteral("tam_cabello_1"),
                LiteralesService.GetLiteral("tam_cabello_2")
            };
        }

        private static List<string> getComboOjosColor_plural()
        {
            if (instanciaListaColorPlural != null)
                return instanciaListaColorPlural;

            return instanciaListaColorPlural=new List<string>() {
                LiteralesService.GetLiteral("color_marron_plural"),
                LiteralesService.GetLiteral("color_verde_plural"),
                LiteralesService.GetLiteral("color_azul_plural")
            };
        }

        private static List<PrendaInferior> getComboPrendaInf()
        {
            if (instanciaListaPrendaInf != null)
                return instanciaListaPrendaInf;

            return instanciaListaPrendaInf = new List<PrendaInferior>()
            {
                new PrendaInferior{ Nombre = LiteralesService.GetLiteral("prenda_inferior_hombre_1") },
                new PrendaInferior{ Nombre = LiteralesService.GetLiteral("prenda_inferior_hombre_2") },
                new PrendaInferior{ Nombre = LiteralesService.GetLiteral("prenda_inferior_hombre_3") },
                new PrendaInferior{ Nombre = LiteralesService.GetLiteral("prenda_inferior_hombre_4") }
            };
        }

        private static List<PrendaSuperior> getComboPrendaSup()
        {
            if (instanciaListaPrendaSup != null)
                return instanciaListaPrendaSup;

            return instanciaListaPrendaSup = new List<PrendaSuperior>() {
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_1") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_2") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_3") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_4") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_5") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_6") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_7") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_8") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_9") },
                new PrendaSuperior{ Nombre = LiteralesService.GetLiteral("prenda_superior_hombre_10") }
            };
        }

        private static List<string> getFisionomia()
        {
            if(instanciaFisionomia!=null)return instanciaFisionomia;

            return instanciaFisionomia = new List<string>()
            {
                LiteralesService.GetLiteral("figura_delgada"),
                LiteralesService.GetLiteral("figura_atletica"),
                LiteralesService.GetLiteral("figura_sobrepeso")
            };
        }
        #endregion

    }
}
