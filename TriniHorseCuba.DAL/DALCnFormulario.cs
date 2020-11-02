using TriniHorseCuba.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriniHorseCuba.DAL
{
    public class DALCnFormulario : DALBase
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListaFormularios = "USP_LISTA_FORMULARIOS";

        #endregion

        public List<BEFormulario> ListarFormularios(int CodigoUsuario)
        {
            List<BEFormulario> lstFormulario = new List<BEFormulario>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcListaFormularios, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = CodigoUsuario;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BEFormulario obj = new BEFormulario();

                        obj.Codigo = Result["CodigoFormulario"].ToString();
                        obj.Url = Result["URL"].ToString();
                        obj.Nombre = Result["Nombre"].ToString();
                        obj.Padre = Result["CodigoPadre"].ToString();
                        obj.Nivel = Convert.ToInt32(Result["Nivel"].ToString());
                        obj.Icono = Result["Icono"].ToString();
                        obj.Abreviatura = Result["Abreviatura"].ToString();
                        obj.Orden = Result["Orden"].ToString();

                        lstFormulario.Add(obj);
                    }

                    Result.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return lstFormulario;
        }
    }
}
