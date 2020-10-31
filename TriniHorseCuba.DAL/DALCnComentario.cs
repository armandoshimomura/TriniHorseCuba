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
    public class DALCnComentario
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListarComentario = "USP_LISTAR_COMENTARIOS";
        private const string prcManteComentario = "USP_MNT_COMENTARIO";

        #endregion

        public List<BEComentario> ListaComentarios(string Estado, int NroPagina, int NroFilas, ref string sMensajeResultado)
        {
            List<BEComentario> _lista = new List<BEComentario>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcListarComentario, conn) { CommandType = CommandType.StoredProcedure };

                conn.Open();

                cmd.Parameters.Add("@Estado", SqlDbType.Char).Value = Estado;
                cmd.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = NroPagina;
                cmd.Parameters.Add("@NumeroFilas", SqlDbType.Int).Value = NroFilas;

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    while (Result.Read())
                    {
                        BEComentario _Co = new BEComentario();

                        _Co.NumeroFila = Convert.ToInt32(Result["NumeroFila"]);
                        _Co.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _Co.Nombre = Result["Nombre"].ToString().Trim();
                        _Co.Comentario = Result["Comentario"].ToString().Trim();
                        _Co.Fecha = Result["Fecha"].ToString();
                        _Co.Estado = Result["Estado"].ToString().Trim();
                        _Co.TotalRegistros = Convert.ToInt32(Result["TotalRegistros"]);

                        _lista.Add(_Co);
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

            return _lista;
        }

        public BEResultado MantenimientoComentario(string Accion, int Codigo, string Nombre, string Comentario, string Estado)
        {
            BEResultado _Resultado = new BEResultado();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcManteComentario, conn) { CommandType = CommandType.StoredProcedure };

                conn.Open();

                cmd.Parameters.Add("@Accion", SqlDbType.Char).Value = Accion;
                cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = Comentario;
                cmd.Parameters.Add("@Estado", SqlDbType.Char).Value = Estado;

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    while (Result.Read())
                    {
                        _Resultado.Codigo = Convert.ToInt32(Result["CodigoRespuesta"]);
                        _Resultado.Descripcion = Result["DescripcionRespuesta"].ToString();
                    }

                    Result.Close();
                }
            }
            catch (Exception ex)
            {
                _Resultado.Codigo = 0;
                _Resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return _Resultado;
        }
    }
}
