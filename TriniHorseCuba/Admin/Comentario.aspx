<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="TriniHorseCuba.Admin.Comentario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <script type="text/javascript">
        function ConfirmarEliminacion() {
            return confirm("¿Desea eliminar el Comentario?");
        }
        function ConfirmarAprobacion() {
            return confirm("¿Desea Aprobar el Comentario?");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="Dashboard.aspx">Inicio</a></li>
            <li class="breadcrumb-item"><a href="#">Página web</a></li>
            <li class="breadcrumb-item active  aria-current="page">Comentario Principal</li>
        </ol>
    </nav>

    <div class="row">
        <div class="col-lg-12">
            <div class="card mb-grid table-responsive-lg">
                                <div class="card-header">
                    <div class="row">
                        <ul class="nav nav-pills card-header-pills" role="tablist">
                            <li class="nav-item">
                                <a runat="server" class="nav-link disabled" id="Tab01" data-toggle="tab" href="#Contenido01" role="tab" aria-controls="Contenido01" aria-selected="true"></a>
                            </li>
                        </ul>
                    </div>                            
                </div>

                <div class="card-body">
                    <div class="tab-content">
                        <%-- Contenido Tab 01 --%>
                        <div runat="server" class="tab-pane fade AuxACYM" id="Contenido01" role="tabpanel" aria-labelledby="Tab01">
                            <table class="table table-bordered table-hover mb-0">
                                <thead>
                                    <tr class="text-center">                                
                                        <th scope="col">#</th>
                                        <th scope="col">Nombre</th>
                                        <th scope="col">Comentario</th>
                                        <th scope="col">Fecha</th>
                                        <th scope="col">Estado</th>
                                        <th scope="col">Acciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpComentario" runat="server">
                                        <HeaderTemplate></HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="text-center">
                                                <asp:HiddenField ID="hdfCodigo" runat="server" Value='<%#Eval("Codigo") %>' />                                                
                                                <th class="w-5">
                                                    <%#Eval("NumeroFila") %>
                                                </th>
                                                <td class="w-15">
                                                    <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>  
                                                </td>
                                                <td class="w-45">
                                                    <asp:Label ID="lblComentario" runat="server" Text='<%#Eval("Comentario") %>'></asp:Label>  
                                                </td>
                                                <td class="w-10">
                                                    <asp:Label ID="lblFecha" runat="server" Text='<%#Eval("Fecha") %>'></asp:Label>                                                            
                                                </td>
                                                <td class="w-10">
                                                    <span class='<%# "badge badge-pill " + Eval("Estado") %>'>
                                                        <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("Estado") %>'></asp:Label>   
                                                    </span>
                                                </td>
                                                <td class="w-15">
                                                            <asp:Button ID="btnAprobar" runat="server" Text="Aprobar" CssClass="btn btn-sm btn-warning mb-1" 
                                                                    OnClick="btnAprobar_Click" OnClientClick="return ConfirmarAprobacion();" />
                                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger mb-1" 
                                                                    OnClick="btnEliminar_Click" OnClientClick="return ConfirmarEliminacion();" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate></FooterTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">
</asp:Content>
