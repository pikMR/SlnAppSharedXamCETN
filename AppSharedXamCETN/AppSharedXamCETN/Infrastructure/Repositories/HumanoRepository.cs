using System;
using System.IO;
using System.Threading.Tasks;

namespace AppCETN.Infrastructure.Repositories
{
    class HumanoRepository : IHumanoRepository
    {
        public async Task<bool> GenerarHumanoJSON(string data)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filename = "/" + Path.Combine(path.ToString(), "CETN_data.json");
                if (!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path.ToString());
                }
                File.WriteAllText(filename, data);
                return await Task.FromResult(true);
            }
            catch(UnauthorizedAccessException auth)
            {
                System.Diagnostics.Debug.WriteLine("GenerarHumanoJSON:data:" + data + " -> ex:"+auth.StackTrace);
                throw new UnauthorizedAccessException(AppCETN.Services.LiteralesService.GetLiteral("ex_2"));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("GenerarHumanoJSON:data:"+data+" -> ex:"+e.StackTrace);
                throw new UnauthorizedAccessException(AppCETN.Services.LiteralesService.GetLiteral("ex_2"));
            }
        }

        public string GetAllJson()
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filename = "/" + Path.Combine(path.ToString(), "CETN_data.json");
                if (!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path.ToString());
                }
                else
                {
                    if(File.Exists(filename))
                        return File.ReadAllText(filename);
                }
            }
            catch (UnauthorizedAccessException auth)
            {
                System.Diagnostics.Debug.WriteLine("GenerarHumanoJSON:data: -> ex:" + auth.StackTrace);
                throw new UnauthorizedAccessException(AppCETN.Services.LiteralesService.GetLiteral("ex_2"));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("GenerarHumanoJSON:data: -> ex:" + e.StackTrace);
                throw new UnauthorizedAccessException(AppCETN.Services.LiteralesService.GetLiteral("ex_2"));
            }
            return null;
        }
    }
}
