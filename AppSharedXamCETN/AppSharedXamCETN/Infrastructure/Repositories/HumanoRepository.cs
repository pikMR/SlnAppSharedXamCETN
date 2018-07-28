﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppSharedXamCETN.Infrastructure.Repositories
{
    class HumanoRepository
    {
        internal async Task<bool> GenerarHumanoJSON(string data)
        {
            try
            {
                var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/CETN";
                //var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
                //var filename = "/" + Path.Combine(path.ToString(), DateTime.Now.ToString("CETN_yyyyMM_ddhhmmss") + ".json");
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
                throw new UnauthorizedAccessException("No se ha podido guardar el elemento en disco, revise los permisos de la aplicación");
                //return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("GenerarHumanoJSON:data:"+data+" -> ex:"+e.StackTrace);
                throw new UnauthorizedAccessException("Se ha producido un error: No se ha podido guardar el elemento en disco, revise los permisos de la aplicación");
                //return await Task.FromResult(false);
            }
            // obtiene el archivo, e inserta el contenido del json,
            // si no existe el archivo lo crea e introduce el json.
            //throw new NotImplementedException();
        }

        internal string GetAllJson()
        {
            try
            {
                var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/CETN";
                //var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
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
                throw new UnauthorizedAccessException("No se ha podido guardar el elemento en disco, revise los permisos de la aplicación");
                //return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("GenerarHumanoJSON:data: -> ex:" + e.StackTrace);
                throw new UnauthorizedAccessException("Se ha producido un error: No se ha podido guardar el elemento en disco, revise los permisos de la aplicación");
                //return await Task.FromResult(false);
            }
            return null;
        }
    }
}
