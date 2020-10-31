using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriniHorseCuba.BE;
using TriniHorseCuba.BLL;

namespace TriniHorseCuba
{
    public partial class Galeria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Datos();
            }
        }

        private void Cargar_Datos()
        {
            string sMensajeResultado = "";
            string Idioma = Session["Idioma"].ToString();

            switch (Idioma)
            {
                case "SPA":
                    lblIni_1.Text = "Inicio";
                    lblIni_2.Text = "Galería";
                    lblTitulo_1.Text = "Galería";
                    lblTitulo_2.Text = "Imágenes de las experiencias";
                    break;
                default:
                    lblIni_1.Text = "Home";
                    lblIni_2.Text = "Gallery";
                    lblTitulo_1.Text = "Gallery";
                    lblTitulo_2.Text = "Images of the experiences";
                    break;
            }

            
        }
    }
}