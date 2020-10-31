using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.BE
{
    public class BEHome
    {
        public List<BETextosHome> lstTextosHome { get; set; }
        public List<BETextosServicio> lstTextosServ { get; set; }
        public List<BEDetalleServicios> lstDetalleServ { get; set; }
    }
}
