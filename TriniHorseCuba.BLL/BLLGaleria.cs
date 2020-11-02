using TriniHorseCuba.BE;
using TriniHorseCuba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BLL
{
    public class BLLGaleria
    {
        public List<BEGaleria> ListarGaleria(ref string sMensajeResultado)
        {
            DALCnGaleria obj = new DALCnGaleria();
            return obj.ListarGaleria(ref sMensajeResultado);
        }

        public BEResultado MantenimientoGaleria(string Accion, int Codigo, string NombreImagen, string Titulo, int Orden)
        {
            DALCnGaleria obj = new DALCnGaleria();
            return obj.MantenimientoGaleria(Accion, Codigo, NombreImagen, Titulo, Orden);
        }
    }
}
