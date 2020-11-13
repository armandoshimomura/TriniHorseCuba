using TriniHorseCuba.BE;
using TriniHorseCuba.BLL;
using TriniHorseCuba.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriniHorseCuba.Admin
{
    public partial class Comentario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar_Comentario();
                Activar_Tab(1);
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            string CodigoAprobacion = (item.FindControl("hdfCodigo") as HiddenField).Value;

            Admin mp = (Admin)Master;
            BLLComentario obj = new BLLComentario();

            BEResultado rpta = obj.MantenimientoComentario("U", Convert.ToInt32(CodigoAprobacion),"" ,"" , "A");

            if (rpta.Codigo == 1)
            {
                mp.MensajeSOL(Constantes.cLogoExito, rpta.Descripcion, Constantes.cNotiExito);
                Listar_Comentario();
            }
            else
            {
                mp.MensajeSOL(Constantes.cLogoPeligro, rpta.Descripcion, Constantes.cNotiPeligro);
            }

            ClientScript.RegisterStartupScript(GetType(), UniqueID, Constantes.cObjNotificacion, true);

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            string CodigoEliminacion = (item.FindControl("hdfCodigo") as HiddenField).Value;

            Admin mp = (Admin)Master;
            BLLComentario obj = new BLLComentario();

            BEResultado rpta = obj.MantenimientoComentario("D", Convert.ToInt32(CodigoEliminacion), "", "", "");

            if (rpta.Codigo == 1)
            {
                mp.MensajeSOL(Constantes.cLogoExito, rpta.Descripcion, Constantes.cNotiExito);
                Listar_Comentario();
            }
            else
            {
                mp.MensajeSOL(Constantes.cLogoPeligro, rpta.Descripcion, Constantes.cNotiPeligro);
            }

            ClientScript.RegisterStartupScript(GetType(), UniqueID, Constantes.cObjNotificacion, true);
        }

        #region Métodos y funciones locales

        private void Listar_Comentario()
        {
            string MsjResultado = "";

            BLLComentario obj = new BLLComentario();
            List<BEComentario> _lstComentario = obj.ListaComentarios("T", 0, 0, ref MsjResultado);

            if (MsjResultado == "")
            {
                rpComentario.DataSource = _lstComentario;
                rpComentario.DataBind();
            }
        }

        private void Activar_Tab(int NroTab)
        {
            switch (NroTab)
            {
                case 1:
                    Tab01.Attributes.Add("class", Tab01.Attributes["class"].ToString().Replace("disabled", "active text-info"));

                    Contenido01.Attributes.Add("class", Contenido01.Attributes["class"].ToString().Replace("AuxACYM", "show active"));

                    break;
                case 2:
                    Tab01.Attributes.Add("class", Tab01.Attributes["class"].ToString().Replace("active text-info", "disabled"));

                    Contenido01.Attributes.Add("class", Contenido01.Attributes["class"].ToString().Replace("show active", "AuxACYM"));

                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}