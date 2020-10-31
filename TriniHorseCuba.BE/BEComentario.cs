using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BE
{
    public class BEComentario
    {
        public int NumeroFila { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Comentario { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public int TotalRegistros { get; set; }
    }
}
