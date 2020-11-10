using Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriniHorseCuba.BE;
using TriniHorseCuba.BLL;

namespace TriniHorseCuba
{
    public partial class Inicio : System.Web.UI.Page
    {
        cTHC cU = new cTHC();
        Util eU = new Util();
        string CorreoDestino = WebConfigurationManager.AppSettings["CorreoDestino"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Idioma();
                Cargar_Datos();
                Cargar_Comentarios();
            }
        }

        private void Cargar_Idioma()
        {
            string Lang = Request.QueryString["lang"];

            if (Lang == null)
                Session["Idioma"] = "ENG";
            else
            {
                Session["Idioma"] = Lang;
            }
        }

        private void Cargar_Datos()
        {
            string MsjResultado = "";

            BLLHome obj = new BLLHome();
            BEHome lstDatos = obj.ListaHome(Session["Idioma"].ToString(), ref MsjResultado);

            if (MsjResultado == "")
            {
                lblTituloFlyer.Text = lstDatos.lstTextosHome.ElementAt(0).TituloFlyer;
                lblTextoFlyer.Text = lstDatos.lstTextosHome.ElementAt(0).TextoFlyer;

                var lstDatosSup = from Serv in lstDatos.lstDetalleServ
                                  where Serv.Orden == 1 || Serv.Orden == 2
                                  select Serv;

                rpServSup.DataSource = lstDatosSup.ToList();
                rpServSup.DataBind();

                lblTituloServicios.Text = lstDatos.lstTextosServ.ElementAt(0).Titulo;
                lblSubtiServicios.Text = lstDatos.lstTextosServ.ElementAt(0).Subtitulo;
                lblTextoServicios.Text = lstDatos.lstTextosServ.ElementAt(0).TextoCentral;

                var lstDatosInf01 = from Serv in lstDatos.lstDetalleServ
                                    where Serv.Orden == 3 || Serv.Orden == 4
                                    select Serv;

                rpServInf01.DataSource = lstDatosInf01.ToList();
                rpServInf01.DataBind();

                var lstDatosInf02 = from Serv in lstDatos.lstDetalleServ
                                    where Serv.Orden == 5 || Serv.Orden == 6
                                    select Serv;

                rpServInf02.DataSource = lstDatosInf02.ToList();
                rpServInf02.DataBind();

                lblTituloEncuentro.Text = lstDatos.lstTextosHome.ElementAt(0).TituloEncuentranos;
                lblTextoEncuentro.Text = lstDatos.lstTextosHome.ElementAt(0).TextoEncuentranos;
                lblTextoBoton.Text = lstDatos.lstTextosHome.ElementAt(0).BotonEncuentranos;
            }

            string Idioma = Session["Idioma"].ToString();

            switch (Idioma)
            {
                case "SPA":
                    txtNombre.Attributes.Add("placeholder", "Nombre");
                    txtComentario.Attributes.Add("placeholder", "Comentario");
                    btnEnviar.Text = "Enviar";

                    break;
                default:
                    txtNombre.Attributes.Add("placeholder", "Name");
                    txtComentario.Attributes.Add("placeholder", "Comment");
                    btnEnviar.Text = "Send";

                    break;
            }
        }

        private void Cargar_Comentarios()
        {
            string MsjResultado = "";

            BLLComentario obj = new BLLComentario();
            List<BEComentario> lstComentario = obj.ListaComentarios("A", 1, 10, ref MsjResultado);

            rpComentarios.DataSource = lstComentario;
            rpComentarios.DataBind();            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            BLLComentario obj = new BLLComentario();

            BEResultado rpta = obj.MantenimientoComentario("I", 0, txtNombre.Text.Trim(), txtComentario.Text.Trim(), "P");

            if (rpta.Codigo == 1)
            {                
                StringBuilder body = new StringBuilder();

                body.AppendLine("Estimado Administrador(a)," + "<br>");
                body.AppendLine("<br>");
                body.AppendLine("Se acaba de registrar un nuevo comentario en su web:" + "<br>");
                body.AppendLine("<ul>");
                body.AppendLine("<li>" + "Nombre: " + txtNombre.Text.Trim() + "</li>");
                body.AppendLine("<li>" + "Comentario: " + txtComentario.Text.Trim() + "</li>");
                body.AppendLine("</ul>");

                int rptaMsj = eU.Enviar("noreply@horsebackuba.com", "Web HorseBackuba", CorreoDestino, "Nuevo comentario en la web", body);

                if (rptaMsj == 1)
                {
                    divMsj.Attributes.Add("class", cU.claseMsj("success"));

                    txtNombre.Text = string.Empty;
                    txtComentario.Text = string.Empty;
                }
                else
                {
                    divMsj.Attributes.Add("class", cU.claseMsj("danger"));
                    rpta.Descripcion = "Se presentaron problemas para el envío de correo, intentar nuevamente.";
                }
            }
            else
            {
                divMsj.Attributes.Add("class", cU.claseMsj("danger"));
            }

            divMsj.InnerHtml = rpta.Descripcion;
        }
    }
}