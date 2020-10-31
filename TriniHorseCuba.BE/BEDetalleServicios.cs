using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BE
{
    public class BEDetalleServicios
    {
        public int Codigo { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Decimal Precio { get; set; }
        public string Concepto { get; set; }
        public int Orden { get; set; }
        public string TextoBoton { get; set; }
    }
}
