using TriniHorseCuba.BE;
using TriniHorseCuba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BLL
{
    public class BLLCollage
    {
        public List<BECollage> ListarCollage(ref string sMensajeResultado)
        {
            DALCnCollage obj = new DALCnCollage();
            return obj.ListarCollage(ref sMensajeResultado);
        }

        public BEResultado MantenimientoCollage(string Accion, int Codigo, string NombreImagen, string Titulo, int Orden)
        {
            DALCnCollage obj = new DALCnCollage();
            return obj.MantenimientoCollage(Accion, Codigo, NombreImagen, Titulo, Orden);
        }
    }
}
