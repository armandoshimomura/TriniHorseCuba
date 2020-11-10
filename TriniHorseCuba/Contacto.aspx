<%@ Page Title="" Language="C#" MasterPageFile="~/THC.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TriniHorseCuba.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section class="banner_area">
        <div class="banner_inner overlay d-flex align-items-center">
            <div class="container">
                <div class="banner_content text-center">
                    <div class="page_link">
						<a href="Inicio.aspx"><asp:Label ID="lblIni_1" runat="server"></asp:Label></a>
						<a href="#"><asp:Label ID="lblIni_2" runat="server"></asp:Label></a>
					</div>
					<h2><asp:Label ID="lblTitulo" runat="server"></asp:Label></h2>
                </div>
            </div>
        </div>
    </section>

    <section class="contact_area section_gap">
        <div class="container">
            <div class="mapBox">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1852.1786847433043!2d-79.98548857939171!3d21.805118951702262!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8f2ae44258937441%3A0x599a9d350caeb3d3!2sPlaza%20Mayor!5e0!3m2!1ses!2spe!4v1588461967658!5m2!1ses!2spe" width="100%" height="400" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="contact_info">
                        <div class="info_item">
                            <i class="lnr lnr-home"></i>
                            <h6>Trinidad, Cuba</h6>
                            <p>Plaza Mayor</p>
                        </div>
                        <div class="info_item">
                            <i class="lnr lnr-phone-handset"></i>
                            <h6><a href="#">(+53) 58657333</a></h6>
                            <p>Samuel Rodriguez Campos</p>
                        </div>
                        <div class="info_item">
                            <i class="lnr lnr-envelope"></i>
                            <h6><a href="mailto:horsebackubatrinidad@gmail.com">horsebackubatrinidad@gmail.com</a></h6>
                            <p><asp:Label ID="lblEscribenos" runat="server"></asp:Label></p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                    <form id="frmContacto" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="upContacto" runat="server">
                            <ContentTemplate>
                                <div class="row contact_form">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" required></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" AutoCompleteType="Email" required></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMensaje" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12 text-right">
                                        <asp:Button ID="btnEnviarContacto" CssClass="primary-btn text-uppercase" runat="server" Text="Enviar/Send" OnClick="btnEnviarContacto_Click" CausesValidation="false" />
                                    </div>
                                    <div class="form-row mb-5">
                                        <div class="col-md-12">
                                            <div id="divMsj" runat="server" role="alert"></div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnEnviarContacto" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>                        
                    </form>
                </div>
            </div>                   
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    <script>
        $(document).ready(function () {
            $('.nav-link[href="Contacto.aspx"]').parent('li').addClass('active');
        });
    </script>
</asp:Content>
