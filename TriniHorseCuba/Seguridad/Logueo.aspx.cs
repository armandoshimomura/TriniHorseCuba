using TriniHorseCuba.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriniHorseCuba.util;
using TriniHorseCuba.BE;

namespace TriniHorseCuba.Seguridad
{
    public partial class Logueo : System.Web.UI.Page
    {
        cTHCuba cU = new cTHCuba();
        BLLUsuario Us = new BLLUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Iniciar_Formulario();
                txtUsuario.Focus();
            }
        }

        protected void btnLogueo_Click(object sender, EventArgs e)
        {
            string Contrasena;

            if (Validar_Form())
            {
                Contrasena = Us.ObtenerContrasena(txtUsuario.Text.Trim());

                if (Contrasena.Length == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Usuario ingresado no existe','" + Constantes.cNotiPeligro + "');", true);
                }
                else
                {
                    if (txtContrasena.Text.Trim().Equals(cU.Desencriptar(Contrasena)))
                    {
                        BEUsuario DatosUsuario = new BEUsuario();

                        DatosUsuario = Us.ObtenerInfoUsuario(txtUsuario.Text.Trim());

                        switch (DatosUsuario.Estado)
                        {
                            case "E": // Eliminado
                                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Usuario ingresado no existe','" + Constantes.cNotiPeligro + "');", true);
                                break;
                            case "B": // Bloqueado
                                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Usuario actualmente bloqueado','" + Constantes.cNotiAdvertencia + "');", true);
                                break;
                            case "I": // Inactivo
                                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Usuario actualmente inactivo','" + Constantes.cNotiAdvertencia + "');", true);
                                break;
                            default:
                                Session["Usuario"] = DatosUsuario;

                                if (txtContrasena.Text.Trim().Equals(Constantes.cContrasenaPorDefecto))
                                {
                                    Response.Redirect("CambioContrasena.aspx");
                                }
                                else
                                {
                                    Response.Redirect("../Admin/Dashboard.aspx");
                                }

                                break;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Credenciales incorrectas','" + Constantes.cNotiPeligro + "');", true);
                    }
                }
            }
        }

        private void Iniciar_Formulario()
        {
            Session["Usuario"] = null;

            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        private bool Validar_Form()
        {
            if (txtUsuario.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), UniqueID, "vNoti('Debe ingresar un usuario','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            if (txtContrasena.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), UniqueID, "vNoti('Debe ingresar una contraseña','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            return true;
        }
    }
}