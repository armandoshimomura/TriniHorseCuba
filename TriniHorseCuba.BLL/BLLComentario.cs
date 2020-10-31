using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriniHorseCuba.BE;
using TriniHorseCuba.DAL;

namespace TriniHorseCuba.BLL
{
    public class BLLComentario
    {
        public List<BEComentario> ListaComentarios(string Estado, int NroPagina, int NroFilas, ref string sMensajeResultado)
        {
            DALCnComentario obj = new DALCnComentario();
            return obj.ListaComentarios(Estado, NroPagina, NroFilas, ref sMensajeResultado);
        }

        public BEResultado MantenimientoComentario(string Accion, int Codigo, string Nombre, string Comentario, string Estado)
        {
            DALCnComentario obj = new DALCnComentario();
            return obj.MantenimientoComentario(Accion, Codigo, Nombre, Comentario, Estado);
        }
    }
}
