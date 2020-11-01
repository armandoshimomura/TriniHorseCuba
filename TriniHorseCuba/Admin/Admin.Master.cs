using TriniHorseCuba.BE;
using TriniHorseCuba.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriniHorseCuba.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int CodigoUsuario = ValidarUsuario();

                if (CodigoUsuario <= 0)
                {
                    Response.Redirect("../Seguridad/Logueo.aspx");
                }
                else
                {
                    ListarMenu(CodigoUsuario);
                }
            }
        }

        #region "Métodos y Funciones locales"

        private int ValidarUsuario()
        {
            int CodigoUsuario = -1;

            if (Session["Usuario"] != null)
            {
                BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];
                CodigoUsuario = DatosUsuario.Codigo;
            }

            return CodigoUsuario;
        }

        private void ListarMenu(int CodigoUsuario)
        {
            BLLFormulario obj = new BLLFormulario();
            List<BEFormulario> lstFormularios = new List<BEFormulario>();
            string sMenu = "<li class='sidebar-nav-item'>" +
                                "<a href='Dashboard.aspx' class='sidebar-nav-link active'>" +
                                    "<span class='sidebar-nav-icon'><i data-feather='home'></i></span>" +
                                    "<span class='sidebar-nav-name'>Dashboard</span>" +
                                    "<span class='sidebar-nav-end'></span>" +
                                "</a>" +
                            "</li>";

            lstFormularios = obj.ListarFormularios(CodigoUsuario);

            List<BEFormulario> lstDatosPadres = lstFormularios.FindAll(s => s.Nivel.Equals(0));

            foreach (BEFormulario Frm in lstDatosPadres)
            {
                string Padre = Frm.Codigo;

                List<BEFormulario> lstDatosHijos = lstFormularios.FindAll(s => s.Padre.Equals(Padre));

                sMenu = sMenu + CrearOpcion(Frm, lstDatosHijos);
            }

            ulMenu.InnerHtml = sMenu;
        }

        private string CrearOpcion(BEFormulario DatoPadre, List<BEFormulario> lstDatosHijos)
        {
            string OpcionHtml =
                "<li class='sidebar-nav-item'>" +
                    "<a class='sidebar-nav-link collapsed' data-toggle='collapse' href='#" + DatoPadre.Abreviatura + "' aria-expanded='false' aria-controls='" + DatoPadre.Abreviatura + "'>" +
                        "<span class='sidebar-nav-icon'><i data-feather='" + DatoPadre.Icono + "'></i></span>" +
                        "<span class='sidebar-nav-name'>" + DatoPadre.Nombre + "</span>" +
                        "<span class='sidebar-nav-end'><i data-feather='chevron-right' class='nav-collapse-icon'></i></span>" +
                     "</a>" +

                     "<ul class='sidebar-sub-nav collapse' id='" + DatoPadre.Abreviatura + "'>";

            foreach (BEFormulario DatoHijo in lstDatosHijos)
            {
                OpcionHtml =
                    OpcionHtml +
                        "<li class='sidebar-nav-item'>" +
                            "<a href='" + DatoHijo.Url + "' class='sidebar-nav-link'>" +
                                "<span class='sidebar-nav-abbr'>" + DatoHijo.Abreviatura + "</span>" +
                                "<span class='sidebar-nav-name'>" + DatoHijo.Nombre + "</span>" +
                            "</a>" +
                        "</li>";
            }

            OpcionHtml =
                OpcionHtml +
                    "</ul>" +
                "</li>";

            return OpcionHtml;
        }

        public void MensajeSOL(string Logo, string Mensaje, string Tipo)
        {
            hfLogoMsj.Value = Logo;
            hfMensaje.Value = Mensaje;
            hfTipoMsj.Value = Tipo;
        }

        #endregion
    }
}