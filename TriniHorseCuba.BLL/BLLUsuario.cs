using TriniHorseCuba.DAL;
using TriniHorseCuba.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BLL
{
    public class BLLUsuario
    {
        public string ObtenerContrasena(string NombreUsuario)
        {
            DALCnUsuario obj = new DALCnUsuario();
            return obj.ObtenerContrasena(NombreUsuario);
        }

        public BEUsuario ObtenerInfoUsuario(string NombreUsuario)
        {
            DALCnUsuario obj = new DALCnUsuario();
            return obj.ObtenerInfoUsuario(NombreUsuario);
        }

        public string CambiarContrasena(int CodigoUsuario, string Contrasena)
        {
            DALCnUsuario obj = new DALCnUsuario();
            return obj.CambiarContrasena(CodigoUsuario, Contrasena);
        }
    }
}
