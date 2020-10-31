using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.DAL
{
    public class DALBase
    {
        public string CadenaCon(string DataBase)
        {
            return ConfigurationManager.ConnectionStrings["DataBase_" + DataBase].ConnectionString;
        }
    }
}
