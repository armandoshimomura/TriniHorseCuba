<%@ Page Title="" Language="C#" MasterPageFile="~/Seguridad/Seg.Master" AutoEventWireup="true" CodeBehind="Logueo.aspx.cs" Inherits="TriniHorseCuba.Seguridad.Logueo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="card mb-0">
        <div class="card-body">
            <form id="frmLogin" runat="server" defaultbutton="btnLogueo">
                <div class="form-group">
                    <label for="txtUsuario" class="form-label">Nombre de Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese nombre de usuario" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="form-group mb-4">
                    <label for="txtContrasena" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" placeholder="Ingrese contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <asp:Button ID="btnLogueo" runat="server" Text="Ingresar" CssClass="btn btn-sm btn-block btn-primary" OnClick="btnLogueo_Click" />
            </form>
        </div>
        <div class="card-footer text-center">
            <a href="#"><small>¿Olvidó su contraseña?</small></a>
        </div>
    </div>
</asp:Content>
