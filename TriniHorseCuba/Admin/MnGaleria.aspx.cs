using TriniHorseCuba.BE;
using TriniHorseCuba.BLL;
using TriniHorseCuba.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriniHorseCuba.Admin
{
    public partial class Galeria : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar_Galeria();
                Activar_Tab(1);
                string x = "";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Limpiar_Form();

            hdfAccion.Value = "U";

            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            string CodigoEditado = (item.FindControl("hdfCodigo") as HiddenField).Value;
            string RutaImagen = (item.FindControl("imgGaleria") as Image).ImageUrl;
            string Titulo = (item.FindControl("hdfTitulo") as HiddenField).Value;
            string Orden = (item.FindControl("hdfOrden") as HiddenField).Value;

            hdfCodigoTab02.Value = CodigoEditado;

            string[] NombreImagen = RutaImagen.Split('/');
            hdfImagenSubida.Value = NombreImagen[NombreImagen.Length - 1];

            imgTab02.ImageUrl = RutaImagen;
            txtTitulo.Text = Titulo;
            txtOrden.Text = Orden;

            Activar_Tab(2);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            string CodigoEliminacion = (item.FindControl("hdfCodigo") as HiddenField).Value;

            Admin mp = (Admin)Master;
            BLLCollage obj = new BLLCollage();

            BEResultado rpta = obj.MantenimientoCollage("D", Convert.ToInt32(CodigoEliminacion), "", "", 0);

            if (rpta.Codigo == 1)
            {
                mp.MensajeSOL(Constantes.cLogoExito, rpta.Descripcion, Constantes.cNotiExito);
                Listar_Galeria();
            }
            else
            {
                mp.MensajeSOL(Constantes.cLogoPeligro, rpta.Descripcion, Constantes.cNotiPeligro);
            }

            ClientScript.RegisterStartupScript(GetType(), UniqueID, Constantes.cObjNotificacion, true);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar_Form();

            hdfAccion.Value = "I";
            hdfCodigoTab02.Value = "0";

            Activar_Tab(2);
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar_Form() == true)
            {
                Admin mp = (Admin)Master;
                BLLCollage obj = new BLLCollage();
                
                BEResultado rpta = obj.MantenimientoCollage(hdfAccion.Value, Convert.ToInt32(hdfCodigoTab02.Value), hdfImagenSubida.Value,
                                                           txtTitulo.Text.Trim(), Convert.ToInt32(txtOrden.Text.Trim()));

                if (rpta.Codigo == 1)
                {
                    Activar_Tab(1);
                    mp.MensajeSOL(Constantes.cLogoExito, rpta.Descripcion, Constantes.cNotiExito);
                    Limpiar_Form();
                    Listar_Galeria();
                }
                else
                {
                    mp.MensajeSOL(Constantes.cLogoPeligro, rpta.Descripcion, Constantes.cNotiPeligro);
                }

                ClientScript.RegisterStartupScript(GetType(), UniqueID, Constantes.cObjNotificacion, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (hdfAccion.Value == "I" && imgTab02.ImageUrl != "")
            {
                File.Delete(Server.MapPath("../img/collage/" + hdfImagenSubida.Value));
            }

            Activar_Tab(1);
            hdfAccion.Value = string.Empty;
            Limpiar_Form();
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            Admin mp = (Admin)Master;

            if (imageToUpload.HasFile)
            {
                FileInfo fileImage;
                fileImage = new FileInfo(imageToUpload.FileName);

                if (imageToUpload.FileBytes.Length / 1048576 >= 2.5)
                {
                    mp.MensajeSOL(Constantes.cLogoAdvertencia, "Imagen sobrepasa los 2.5 Mb", Constantes.cNotiAdvertencia);
                    ClientScript.RegisterStartupScript(GetType(), UniqueID, Constantes.cObjNotificacion, true);
                    return;
                }

                if (fileImage.Extension == ".jpg" || fileImage.Extension == ".jpeg" || fileImage.Extension == ".png")
                {
                    string RutaImagen = Server.MapPath("~/img/collage/" + imageToUpload.FileName);

                    if (File.Exists(RutaImagen))
                    {
                        File.Delete(RutaImagen);
                    }

                    hdfImagenSubida.Value = imageToUpload.FileName;
                    imageToUpload.SaveAs(RutaImagen);
                    imgTab02.ImageUrl = "../img/collage/" + imageToUpload.FileName;
                    imgTab02.DataBind();
                }
            }
        }

        #region Métodos y funciones locales

        private void Listar_Galeria()
        {
            string MsjResultado = "";

            BLLCollage obj = new BLLCollage();
            List<BECollage> _lstGaleria = obj.ListarCollage(ref MsjResultado);

            if (MsjResultado == "")
            {
                rpCollage.DataSource = _lstGaleria;
                rpCollage.DataBind();
            }
        }

        private void Activar_Tab(int NroTab)
        {
            switch (NroTab)
            {
                case 1:
                    Tab01.Attributes.Add("class", Tab01.Attributes["class"].ToString().Replace("disabled", "active text-info"));
                    Tab02.Attributes.Add("class", Tab02.Attributes["class"].ToString().Replace("active text-info", "disabled"));

                    Contenido01.Attributes.Add("class", Contenido01.Attributes["class"].ToString().Replace("AuxACYM", "show active"));
                    Contenido02.Attributes.Add("class", Contenido02.Attributes["class"].ToString().Replace("show active", "AuxACYM"));

                    btnNuevo.Visible = true;
                    btnGrabar.Visible = false;
                    btnCancelar.Visible = false;

                    break;
                case 2:
                    Tab01.Attributes.Add("class", Tab01.Attributes["class"].ToString().Replace("active text-info", "disabled"));
                    Tab02.Attributes.Add("class", Tab02.Attributes["class"].ToString().Replace("disabled", "active text-info"));

                    Contenido01.Attributes.Add("class", Contenido01.Attributes["class"].ToString().Replace("show active", "AuxACYM"));
                    Contenido02.Attributes.Add("class", Contenido02.Attributes["class"].ToString().Replace("AuxACYM", "show active"));

                    btnNuevo.Visible = false;
                    btnGrabar.Visible = true;
                    btnCancelar.Visible = true;

                    break;
                default:
                    break;
            }
        }

        private void Limpiar_Form()
        {
            hdfCodigoTab02.Value = string.Empty;
            hdfImagenSubida.Value = string.Empty;

            imgTab02.ImageUrl = string.Empty;

            txtTitulo.Text = string.Empty;
            txtOrden.Text = "0";
        }

        private bool Validar_Form()
        {
            Admin mp = (Admin)Master;
            int Errores = 0;

            if (hdfAccion.Value == "I")
            {
                if (hdfImagenSubida.Value == "")
                {
                    mp.MensajeSOL(Constantes.cLogoAdvertencia, "Favor de subir una imagen previamente", Constantes.cNotiAdvertencia);
                    Errores++;
                }
            }
            
            if (txtOrden.Text.Trim().Length == 0)
            {
                mp.MensajeSOL(Constantes.cLogoAdvertencia, "Favor de agregar un número de orden", Constantes.cNotiAdvertencia);
                Errores++;
            }
            else
            {
                if (Convert.ToInt32(txtOrden.Text) < 0)
                {
                    mp.MensajeSOL(Constantes.cLogoAdvertencia, "Favor de agregar un número de orden mayor o igual a cero", Constantes.cNotiAdvertencia);
                    Errores++;
                }
            }
                     
            if (Errores > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), UniqueID, Constantes.cObjNotificacion, true);
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}