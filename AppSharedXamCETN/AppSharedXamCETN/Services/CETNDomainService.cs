using System;
using System.Collections.Generic;
using AppCETN.Models;

namespace AppCETN.Services
{
    class CETNDomainService
    {
        private static List<Ojos> instancialistaOjos = null;
        private static List<Cabello> instancialistaCabello = null;
        private static List<string> instanciaListaColorPlural = null;
        private static List<string> instanciaListaColor = null;
        private static List<string> instanciaListaTam = null;
        private static List<string> instanciaListaTamPlural = null;

        public static IEnumerable<Hombre> GetAllHombresJSON()
        {
            return CETNHombreService.GetAllHombresJSON();
        }

        public static void InsertarHombreJSON(object data) => CETNHombreService.InsertHombreJSON(data);

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

        internal static List<string> ObtenerValoresFisionomia()
        {
            throw new NotImplementedException();
        }

        internal static List<PrendaSuperior> ObtenerValoresPrendaSup()
        {
            throw new NotImplementedException();
        }

        internal static List<string> ObtenerValoresNalgas() => getComboTam();

        internal static List<PrendaInferior> ObtenerValoresPrendaInf()
        {
            throw new NotImplementedException();
        }

        internal static List<string> ObtenerValoresPecho()
        {
            if (instanciaListaColorPlural != null)
            {
                return instanciaListaColorPlural;
            }
            instanciaListaColorPlural = getComboTam_plural();
            return instanciaListaColorPlural;
        }

        internal static List<Cabello> ObtenerValoresCabello()
        {
            if (instancialistaCabello != null)
            {
                return instancialistaCabello;
            }

            List<string> combo_color = getComboColor();
            List<string> combo_tam = getComboTam();
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

        #endregion

        #region getCombo Literales
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
        #endregion

    }
}
