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
    public class DALCnUsuario : DALBase
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcObtenerContrasena = "USP_OBTENER_CONTRASENA";
        private const string prcObtenerInfoUsuario = "USP_OBTENER_INFO_USUARIO";
        private const string prcCambiarContrasena = "USP_CAMBIO_CONTRASENA";

        #endregion

        public string ObtenerContrasena(string NombreUsuario)
        {
            string Contrasena = string.Empty;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcObtenerContrasena, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (Result.Read())
                    {
                        Contrasena = Result["Contrasena"].ToString();
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

            return Contrasena;
        }

        public BEUsuario ObtenerInfoUsuario(string NombreUsuario)
        {
            BEUsuario _BEUsuario = new BEUsuario();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcObtenerInfoUsuario, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (Result.Read())
                    {
                        _BEUsuario.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _BEUsuario.Nombre = Result["Nombre"].ToString().ToUpper();
                        _BEUsuario.Estado = Result["Estado"].ToString();
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

            return _BEUsuario;
        }

        public string CambiarContrasena(int CodigoUsuario, string Contrasena)
        {
            string Resultado = string.Empty;
            int Error = 0;

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcCambiarContrasena, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = CodigoUsuario;
                cmd.Parameters.Add("@NuevaContrasena", SqlDbType.VarChar).Value = Contrasena;

                cmd.Parameters.Add("@Error", SqlDbType.Int).Value = 0;
                cmd.Parameters["@Error"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                Error = Convert.ToInt32(cmd.Parameters["@Error"].Value.ToString());

                if (Error == 0)
                    Resultado = "Ok";
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return Resultado;
        }
    }
}
