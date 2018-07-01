using System.Collections.Generic;
using AppCETN.Models;

namespace AppCETN.Services
{
    class CETNDomainService
    {
        public IEnumerable<Hombre> GetAllHombresJSON()
        {
            return CETNHombreService.GetAllHombresJSON();
        }

        public void InsertarHombreJSON(object data) => CETNHombreService.InsertHombreJSON(data);
    }
}
