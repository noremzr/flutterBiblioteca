using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_api_dll.Compartilhados
{
    public static class Conversions
    {

        public static string ValueSqlString(string str) {
            return "'" + str.Replace("'","") + "' ";
        }
    }
}
