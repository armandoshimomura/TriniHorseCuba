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
    public partial class Importante : Page
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
                    lblIni_2.Text = "Importante";
                    lblTitulo.Text = "Importante";
                    break;
                default:
                    lblIni_1.Text = "Home";
                    lblIni_2.Text = "Important";
                    lblTitulo.Text = "Important";
                    break;
            }

            BLLRuta obj = new BLLRuta();
            List<BERuta> lstRuta = obj.ListaRuta(Idioma, ref sMensajeResultado);

            if (sMensajeResultado == "")
            {
                rpRuta.DataSource = lstRuta;
                rpRuta.DataBind();
            }
        }
    }
}