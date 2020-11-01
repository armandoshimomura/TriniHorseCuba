<%@ Page Title="" Language="C#" MasterPageFile="~/Seguridad/Seg.Master" AutoEventWireup="true" CodeBehind="CambioContrasena.aspx.cs" Inherits="TriniHorseCuba.Seguridad.CambioContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="card mb-0">
        <div class="card-body">
            <form id="frmCambio" runat="server" defaultbutton="btnCambiar">
                <div class="form-group">
                    <label for="txtContrasena01" class="form-label">Nueva contraseña</label>
                    <asp:TextBox ID="txtContrasena01" runat="server" CssClass="form-control" placeholder="Ingrese nueva contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="form-group mb-4">
                    <label for="txtContrasena02" class="form-label">Confirmar contraseña</label>
                    <asp:TextBox ID="txtContrasena02" runat="server" CssClass="form-control" placeholder="Confirme nueva contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <asp:HiddenField ID="hfCodigoUsuario" runat="server" />

                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" CssClass="btn btn-sm btn-block btn-primary" OnClick="btnCambiar_Click" />
            </form>
        </div>
        <div class="card-footer text-danger">
            <ul>
                <li>Contraseña mayor o igual a 6 caracteres</li>
            </ul>
        </div>
    </div>
</asp:Content>
