using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriniHorseCuba.BE;

namespace TriniHorseCuba
{
    public partial class Reserva : Page
    {
        cTHC cU = new cTHC();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hdfIdioma.Value = "es";
                Cargar_Mes(0, hdfIdioma.Value);
                Cargar_Semana();
                Cargar_Dias();
            }
        }
        protected void lbPrev_Click(object sender, EventArgs e)
        {
            Cargar_Mes(-1, hdfIdioma.Value);
        }

        protected void lbNext_Click(object sender, EventArgs e)
        {
            Cargar_Mes(1, hdfIdioma.Value);
        }

        private void Cargar_Mes(int NumeroMesAdicional, string idioma)
        {
            DateTime Hoy = DateTime.Now;
            DateTime Fecha = hdfFecha.Value == "" ? new DateTime(Hoy.Year, Hoy.Month, 1) : Convert.ToDateTime(hdfFecha.Value);
            DateTime FechaFinal = Fecha.AddMonths(NumeroMesAdicional);

            lblMes.Text = FechaFinal.ToString("MMMM", CultureInfo.CreateSpecificCulture(idioma));
            lblAnho.Text = FechaFinal.Year.ToString();

            hdfFecha.Value = FechaFinal.ToString();
            
            if (FechaFinal > DateTime.Now)
                lbPrev.Visible = true;
            else
                lbPrev.Visible = false;

            Cargar_Dias();
        }

        private void Cargar_Semana()
        {
            
            List<BESemana> lstSemana = new List<BESemana>();

            for (int i = 1; i <= 7; i++)
            {
                BESemana _obj = new BESemana();

                _obj.NumeroDia = i;
                _obj.NombreDia = cU.NombreDia(i, hdfIdioma.Value);

                lstSemana.Add(_obj);
            }

            rpSemana.DataSource = lstSemana;
            rpSemana.DataBind();
        }
        
        private void Cargar_Dias()
        {
            DateTime Hoy = DateTime.Now;
            DateTime PrimerDiaMes = Convert.ToDateTime(hdfFecha.Value);
            DateTime UltimoDiaMes = PrimerDiaMes.AddMonths(1).AddDays(-1);
            int NroDia = cU.NumeroDia(PrimerDiaMes.DayOfWeek.ToString().ToLower());
            List<BEDia> lstDia = new List<BEDia>();
            bool Inicio = false;

            for (int i = 1; i <= UltimoDiaMes.Day; i++)
            {
                BEDia _obj = new BEDia();

                if (i == NroDia && Inicio == false)
                { 
                    Inicio = true;
                    i = 1;
                }

                if (Inicio == false)
                    _obj.Dia = "";
                else
                {
                    if (i == Hoy.Day && PrimerDiaMes.Month == Hoy.Month && PrimerDiaMes.Year == Hoy.Year)
                        _obj.Dia = "<span class='active'>" + i.ToString() + "</span>";
                    else
                        _obj.Dia = i.ToString();
                }

                lstDia.Add(_obj);
            }

            rpDia.DataSource = lstDia;
            rpDia.DataBind();
        }

        protected void lnbDia_Command(object sender, CommandEventArgs e)
        {

        }
    }
}