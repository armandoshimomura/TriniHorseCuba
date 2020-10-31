using TriniHorseCuba.BE;
using TriniHorseCuba.BLL;
using TriniHorseCuba.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriniHorseCuba.Seguridad
{
    public partial class CambioContrasena : System.Web.UI.Page
    {
        cTHCuba cU = new cTHCuba();
        BLLUsuario Us = new BLLUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int CodigoUsuario = ValidarUsuario();

                if (CodigoUsuario <= 0)
                {
                    Response.Redirect("Logueo.aspx");
                }
                else
                {
                    Limpiar_Formulario();
                    txtContrasena01.Focus();

                    hfCodigoUsuario.Value = CodigoUsuario.ToString();
                }
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (Validar_Form())
            {
                string Resultado = Us.CambiarContrasena(Convert.ToInt32(hfCodigoUsuario.Value), cU.Encriptar(txtContrasena01.Text.Trim()));

                if (Resultado == "Ok")
                {
                    Response.Redirect("../Admin/Dashboard.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('" + Resultado + "','" + Constantes.cNotiAdvertencia + "');", true);
                }
            }
        }

        private void Limpiar_Formulario()
        {
            txtContrasena01.Text = string.Empty;
            txtContrasena02.Text = string.Empty;
        }

        private bool Validar_Form()
        {
            if (txtContrasena01.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Debe ingresar una contraseña nueva','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            if (txtContrasena02.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Debe confirmar la contraseña nueva','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            if (txtContrasena01.Text.Trim() != txtContrasena02.Text.Trim())
            {
                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Las contraseñas no coinciden','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            if (txtContrasena01.Text.Trim().Length < 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('La contraseña debe tener 6 caracteres como mínimo','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            if (txtContrasena01.Text.Trim() == Constantes.cContrasenaPorDefecto)
            {
                ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Favor de ingresar una contraseña diferente a la actual','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            return true;
        }

        private int ValidarUsuario()
        {
            int CodigoUsuario = 0;

            if (Session["Usuario"] == null)
            {
                CodigoUsuario = -1;
            }
            else
            {
                BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];
                CodigoUsuario = DatosUsuario.Codigo;
            }

            return CodigoUsuario;
        }
    }
}