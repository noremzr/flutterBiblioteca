using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_api_extension_dll.Usuarios
{
    public class UsuarioFilter
    {
        [JsonProperty("usuario")]
        public string Usuario;
    }
}
