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
    public class DALCnGaleria
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListaGaleria = "USP_LISTAR_GALERIA";
        private const string prcMantenimientoGaleria = "USP_MNT_GALERIA";

        #endregion

        public List<BEGaleria> ListarGaleria(ref string sMensajeResultado)
        {
            List<BEGaleria> lista = new List<BEGaleria>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcListaGaleria, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    while (Result.Read())
                    {
                        BEGaleria _BEGaleria = new BEGaleria();

                        _BEGaleria.Codigo = Convert.ToInt32(Result["Codigo"]);
                        _BEGaleria.NombreImagen = Result["NombreImagen"].ToString();
                        _BEGaleria.Titulo = Result["Titulo"].ToString();
                        _BEGaleria.Orden = Convert.ToInt32(Result["Orden"]);

                        lista.Add(_BEGaleria);
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

        public BEResultado MantenimientoGaleria(string Accion, int Codigo, string NombreImagen, string Titulo, int Orden)
        {
            BEResultado _Resultado = new BEResultado();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon("TriniHorseCuba"));
                SqlCommand cmd = new SqlCommand(prcMantenimientoGaleria, conn)
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
