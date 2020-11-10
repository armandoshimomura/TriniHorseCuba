using Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriniHorseCuba
{
    public partial class Contacto : System.Web.UI.Page
    {
        cTHC cU = new cTHC();
        Util eU = new Util();
        string CorreoDestino = WebConfigurationManager.AppSettings["CorreoDestino"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Datos();
            }
        }

        private void Cargar_Datos()
        {
            string Idioma = Session["Idioma"].ToString();

            switch (Idioma)
            {
                case "SPA":
                    lblIni_1.Text = "Inicio";
                    lblIni_2.Text = "Contacto";
                    lblTitulo.Text = "Contacto";
                    lblEscribenos.Text = "Escríbenos cuando guste";

                    txtNombre.Attributes.Add("placeholder", "Nombre");
                    txtCorreo.Attributes.Add("placeholder", "Correo");
                    txtAsunto.Attributes.Add("placeholder", "Asunto");
                    txtMensaje.Attributes.Add("placeholder", "Mensaje");
                    btnEnviarContacto.Text = "Enviar";

                    break;
                default:
                    lblIni_1.Text = "Home";
                    lblIni_2.Text = "Contact";
                    lblTitulo.Text = "Contact";
                    lblEscribenos.Text = "Write us when you like";

                    txtNombre.Attributes.Add("placeholder", "Name");
                    txtCorreo.Attributes.Add("placeholder", "Email");
                    txtAsunto.Attributes.Add("placeholder", "Subject");
                    txtMensaje.Attributes.Add("placeholder", "Message");
                    btnEnviarContacto.Text = "Send";

                    break;
            }

        }

        protected void btnEnviarContacto_Click(object sender, EventArgs e)
        {
            StringBuilder body = new StringBuilder();

            body.AppendLine("Estimado Administrador(a)," + "<br>");
            body.AppendLine("<br>");
            body.AppendLine("Existe un mensaje desde la web - Contacto:" + "<br>");
            body.AppendLine("<ul>");
            body.AppendLine("<li>" + txtMensaje.Text.Trim() + "</li>");
            body.AppendLine("</ul>");

            int rptaMsj = eU.Enviar(txtCorreo.Text.Trim(), txtNombre.Text.Trim(), CorreoDestino, txtAsunto.Text.Trim(), body);

            if (rptaMsj == 1)
            {
                divMsj.Attributes.Add("class", cU.claseMsj("success"));
                divMsj.InnerHtml = "Su mensaje ha sido enviado con éxito.";

                txtNombre.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtAsunto.Text = string.Empty;
                txtMensaje.Text = string.Empty;
            }
            else
            {
                divMsj.Attributes.Add("class", cU.claseMsj("danger"));
                divMsj.InnerHtml = "Se presentaron problemas para el envío del mensaje, intentar nuevamente.";
            }
        }
    }
}