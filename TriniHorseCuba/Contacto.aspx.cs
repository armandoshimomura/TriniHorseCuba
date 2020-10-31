using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriniHorseCuba
{
    public partial class Contacto : System.Web.UI.Page
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
            string Idioma = Session["Idioma"].ToString();

            switch (Idioma)
            {
                case "SPA":
                    lblIni_1.Text = "Inicio";
                    lblIni_2.Text = "Contacto";
                    lblTitulo.Text = "Contacto";
                    lblEscribenos.Text = "Escríbenos cuando guste";
                    break;
                default:
                    lblIni_1.Text = "Home";
                    lblIni_2.Text = "Contact";
                    lblTitulo.Text = "Contact";
                    lblEscribenos.Text = "Write us when you like";
                    break;
            }

        }
    }
}