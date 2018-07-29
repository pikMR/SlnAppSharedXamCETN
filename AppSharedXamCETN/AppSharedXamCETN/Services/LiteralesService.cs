using System.Collections.Generic;

namespace AppCETN.Services
{
    public class LiteralesService
    {
        private static IDictionary<string, string> _map = new Dictionary<string,string>();

        public static string GetLiteral(string key)
        {
            string valor = "";
            if(key!=null)
            _map.TryGetValue(key, out valor);
            return valor;
        }

        public static void AddLiterales(string[] lbl_literales, string[] literales)
        {
            if (lbl_literales!= null && literales!=null && lbl_literales.Length==literales.Length)
            {
                int i = 0;

                if (_map.ContainsKey(lbl_literales[i]))
                    return;

                for(; i < lbl_literales.Length; i++)
                    _map.Add(lbl_literales[i],literales[i]);
            }
        }

        public static void TestPrintDebug()
        {
            if (_map.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> pair in _map)
                {
                    i++;
                    System.Diagnostics.Debug.WriteLine("{0} -> Key: {1} Values: {2} ", i, pair.Key, pair.Value);
                    System.Console.WriteLine("{0} -> Key: {1} Values: {2} ", i, pair.Key, pair.Value);
                }
            }
        }
    }
}
