using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriniHorseCuba.BE;
using TriniHorseCuba.DAL;

namespace TriniHorseCuba.BLL
{
    public class BLLHome
    {
        public BEHome ListaHome(string Idioma, ref string sMensajeResultado)
        {
            DALCnHome obj = new DALCnHome();
            return obj.ListaHome(Idioma, ref sMensajeResultado);
        }
    }
}
