using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriniHorseCuba.BE;

namespace TriniHorseCuba.DAL
{
    public class DALCnHome
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcDatosHome = "USP_LISTAR_HOME";

        #endregion

        public BEHome ListaHome(string Idioma, ref string sMensajeResultado)
        {
            BEHome DatosHome = new BEHome();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcDatosHome, conn) { CommandType = CommandType.StoredProcedure };

                conn.Open();

                cmd.Parameters.Add("@Idioma", SqlDbType.Char).Value = Idioma;

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    // Datos sobre textos del Home
                    List<BETextosHome> lstTH = new List<BETextosHome>();
                    
                    while (Result.Read())
                    {
                        BETextosHome _TH = new BETextosHome();

                        _TH.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _TH.TituloFlyer = Result["Titulo_Flyer"].ToString().Trim();
                        _TH.TextoFlyer = Result["Texto_Flyer"].ToString().Trim();
                        _TH.TituloEncuentranos = Result["Titulo_Encuentro"].ToString().Trim();
                        _TH.TextoEncuentranos = Result["Texto_Encuentro"].ToString().Trim();
                        _TH.BotonEncuentranos = Result["Texto_Boton"].ToString().Trim();

                        lstTH.Add(_TH);
                    }
                    
                    Result.NextResult();

                    // Datos sobre textos del Servicio
                    List<BETextosServicio> lstTS = new List<BETextosServicio>();
                    
                    while (Result.Read())
                    {
                        BETextosServicio _TS = new BETextosServicio();

                        _TS.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _TS.Titulo = Result["Titulo"].ToString().Trim();
                        _TS.Subtitulo = Result["Texto_1"].ToString().Trim();
                        _TS.TextoCentral = Result["Texto_2"].ToString().Trim();
                        
                        lstTS.Add(_TS);
                    }
                    
                    Result.NextResult();

                    // Datos sobre detalle del Servicio
                    List<BEDetalleServicios> lstDS = new List<BEDetalleServicios>();

                    while (Result.Read())
                    {
                        BEDetalleServicios _DS = new BEDetalleServicios();

                        _DS.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _DS.Imagen = Result["NombreImagen"].ToString().Trim();
                        _DS.Titulo = Result["Titulo"].ToString().Trim();
                        _DS.Texto = Result["Texto"].ToString().Trim();
                        _DS.Precio = Convert.ToDecimal(Result["Precio"]);
                        _DS.Concepto = Result["Concepto"].ToString().Trim();
                        _DS.Orden = Convert.ToInt32(Result["Orden"]);
                        _DS.TextoBoton = Idioma == "SPA" ? "Ver más" : "See more";

                        lstDS.Add(_DS);
                    }
                    
                    Result.Close();
                    
                    DatosHome.lstTextosHome = lstTH;
                    DatosHome.lstTextosServ = lstTS;
                    DatosHome.lstDetalleServ = lstDS;

                    sMensajeResultado = "";
                }
            }
            catch (Exception ex)
            {
                sMensajeResultado = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return DatosHome;
        }
    }
}
