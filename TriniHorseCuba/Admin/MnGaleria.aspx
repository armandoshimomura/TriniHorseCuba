<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MnGaleria.aspx.cs" Inherits="TriniHorseCuba.Admin.Galeria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <script type="text/javascript">
        function ConfirmarEliminacion() {
            return confirm("¿Desea eliminar la Imagen?");
        }

        function ConfirmarCancelacion() {
            return confirm("¿Realmente desea cancelar el proceso? Los datos ingresados se limpiarán");
        }
    </script>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="Dashboard.aspx">Inicio</a></li>
            <li class="breadcrumb-item"><a href="#">Página web</a></li>
            <li class="breadcrumb-item active  aria-current="page">Galería</li>
        </ol>
    </nav>

    <div class="row pb-3">
        <div class="col-md-8">
            <h1>Galería principal</h1>
        </div>
        <div class="col-md-4 text-right">           
            <asp:HiddenField ID="hdfAccion" runat="server" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-info btn-sm" OnClick="btnNuevo_Click" />                                    
            <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-primary btn-sm" OnClick="btnGrabar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-sm" OnClick="btnCancelar_Click" OnClientClick="return ConfirmarCancelacion();" />          
        </div>
    </div>
       
    <div class="row">
        <div class="col-lg-12">
            <div class="card mb-grid table-responsive-lg">
                <div class="card-header">
                    <div class="row">
                        <ul class="nav nav-pills card-header-pills" role="tablist">
                            <li class="nav-item">
                                <a runat="server" class="nav-link disabled" id="Tab01" data-toggle="tab" href="#Contenido01" role="tab" aria-controls="Contenido01" aria-selected="true">Imágenes de la galería</a>
                            </li>
                            <li class="nav-item">
                                <a runat="server" class="nav-link disabled" id="Tab02" data-toggle="tab" href="#Contenido02" role="tab" aria-controls="Contenido02" aria-selected="false">Propiedades de la imagen</a>
                            </li>
                        </ul>
                    </div>                            
                </div>
                <div class="card-body">
                    <div class="tab-content">
                        <%-- Contenido Tab 01 --%>
                        <div runat="server" class="tab-pane fade AuxACYM" id="Contenido01" role="tabpanel" aria-labelledby="Tab01">
                            <div class="row">
                                <asp:Repeater ID="rpCollage" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 mb-3">
                                            <div class="card text-center">
                                                <asp:Image CssClass="card-img-top img-fluid" ID="imgGaleria" runat="server" ImageUrl='<%# "~/img/collage/" + Eval("NombreImagen") %>' responsive />

                                                <div class="card-body">
                                                    <asp:HiddenField ID="hdfCodigo" runat="server" Value='<%#Eval("Codigo") %>' />
                                                    <asp:HiddenField ID="hdfTitulo" runat="server" Value='<%#Eval("Titulo") %>' />
                                                    <asp:HiddenField ID="hdfOrden" runat="server" Value='<%#Eval("Orden") %>' />

                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-warning w-100" OnClick="btnEditar_Click" />
                                                        </div>
                                                        <div class="col">
                                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger w-100" OnClick="btnEliminar_Click" OnClientClick="return ConfirmarEliminacion();" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>                           
                        </div>
                        <%-- Contenido Tab 02 --%>
                        <div runat="server" class="tab-pane fade AuxACYM" id="Contenido02" role="tabpanel" aria-labelledby="Tab02">
                            <div class="row mb-2">
                                <asp:HiddenField ID="hdfCodigoTab02" runat="server" />
                                <%-- Imagen --%>
                                <div class="col-lg-5 add-image mb-3">
                                    <div class="form">
                                        <h2>Selecciona una imagen</h2>
                                        <asp:FileUpload runat="server" ID="imageToUpload" ClientIDMode="Static" />
                                        <label>
                                            <input type="text" placeholder="No has seleccionado una imagen" readonly="readonly" />
                                            <span class="material-icons clear">close</span>
                                        </label>
                                        <span id="chooseFile" class="material-icons">more_horiz</span>
                                        <asp:LinkButton ID="btnSubir" runat="server" CssClass="btn-guardar disabled" OnClick="btnSubir_Click">Subir</asp:LinkButton>                                                
                                    </div>
                                    <div class="form-group row mt-2 m-0">
                                        <asp:HiddenField ID="hdfImagenSubida" runat="server" />
                                        <asp:Image CssClass="img-fluid border border-info" ID="imgTab02" runat="server" responsive />
                                    </div>
                                    <div class="form-group row mt-2 m-0">
                                        <ul class="list-group list-group-flush text-danger">
                                            <li class="list-group-item">Consideraciones</li>
                                            <li class="list-group-item">• Imagen no mayor a 2.5 Mb <br /> • Dimensiones 1000 ancho x 750 alto </li>                                           
                                        </ul>
                                    </div>
                                </div>
                                <%-- Datos --%>
                                <div class="col-lg-7">
                                    <div class="form-group row">
                                        <label for="txtTitulo" class="col-sm-2 col-form-label form-label">Título</label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Ingresar dato" MaxLength="50"></asp:TextBox>                                                    
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="txtOrden" class="col-sm-2 col-form-label form-label">Orden</label>
                                        <div class="col-sm-2">                                                    
                                            <asp:TextBox ID="txtOrden" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumberKey(event)" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">

</asp:Content>
