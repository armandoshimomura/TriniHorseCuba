using TriniHorseCuba.BE;
using TriniHorseCuba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BLL
{
    public class BLLFormulario
    {
        public BLLFormulario() { }

        public List<BEFormulario> ListarFormularios(int CodigoUsuario)
        {
            DALCnFormulario obj = new DALCnFormulario();
            return obj.ListarFormularios(CodigoUsuario);
        }
    }
}
