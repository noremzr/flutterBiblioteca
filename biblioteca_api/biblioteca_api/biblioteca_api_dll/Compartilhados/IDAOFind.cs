using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_api_dll.Compartilhados
{
    public interface IDAOFind<T,F>
    {
        List<T> FindAll(F filter);
        string GetQuery(F filter);
        string GetProperties();
    }
}
