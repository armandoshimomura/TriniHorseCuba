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
    public class DALCnRuta
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListaRuta = "USP_LISTAR_RUTA";

        #endregion

        public List<BERuta> ListaRuta(string Idioma, ref string sMensajeResultado)
        {
            List<BERuta> lstRuta = new List<BERuta>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcListaRuta, conn) { CommandType = CommandType.StoredProcedure };

                conn.Open();

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    while (Result.Read())
                    {
                        BERuta objRuta = new BERuta();

                        objRuta.Codigo = Convert.ToInt32(Result["Codigo"]);

                        switch (Idioma)
                        {
                            case "SPA":
                                objRuta.Titulo = Result["Titulo_SPA"].ToString().Trim();
                                objRuta.Texto = Result["Texto_SPA"].ToString().Trim();
                                break;
                            default:
                                objRuta.Titulo = Result["Titulo_ENG"].ToString().Trim();
                                objRuta.Texto = Result["Texto_ENG"].ToString().Trim();
                                break;
                        }

                        objRuta.Orden = Convert.ToInt32(Result["Orden"]);
                        objRuta.Estilo = (objRuta.Orden % 2) == 0 ? "generic-blockquote-a" : "generic-blockquote-r";

                        lstRuta.Add(objRuta);
                    }

                    Result.Close();
                    
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

            return lstRuta;
        }
    }
}
