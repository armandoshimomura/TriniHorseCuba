using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriniHorseCuba.BE;
using TriniHorseCuba.DAL;

namespace TriniHorseCuba.BLL
{
    public class BLLRuta
    {
        public List<BERuta> ListaRuta(string Idioma, ref string sMensajeResultado)
        {
            DALCnRuta obj = new DALCnRuta();
            return obj.ListaRuta(Idioma, ref sMensajeResultado);
        }
    }
}
