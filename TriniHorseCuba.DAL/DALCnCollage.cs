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
    public class DALCnCollage
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListaCollage = "USP_LISTAR_COLLAGE";
        private const string prcMantenimientoCollage = "USP_MNT_COLLAGE";

        #endregion

        public List<BECollage> ListarCollage(ref string sMensajeResultado)
        {
            List<BECollage> lista = new List<BECollage>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("THCuba"));
                SqlCommand cmd = new SqlCommand(prcListaCollage, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    while (Result.Read())
                    {
                        BECollage _BECollage = new BECollage();

                        _BECollage.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _BECollage.NombreImagen = Result["NombreImagen"].ToString();
                        _BECollage.Titulo = Result["Titulo"].ToString();
                        _BECollage.Orden = Convert.ToInt32(Result["Orden"]);

                        lista.Add(_BECollage);
                    }

                    sMensajeResultado = "";

                    Result.Close();
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

            return lista;
        }

        public BEResultado MantenimientoCollage(string Accion, int Codigo, string NombreImagen, string Titulo, int Orden)
        {
            BEResultado _Resultado = new BEResultado();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("THCuba"));
                SqlCommand cmd = new SqlCommand(prcMantenimientoCollage, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                cmd.Parameters.Add("@Accion", SqlDbType.Char).Value = Accion;
                cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                cmd.Parameters.Add("@NombreImagen", SqlDbType.VarChar).Value = NombreImagen;
                cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = Titulo;
                cmd.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;

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
