<%@ Page Title="" Language="C#" MasterPageFile="~/THC.Master" AutoEventWireup="true" CodeBehind="Importante.aspx.cs" Inherits="TriniHorseCuba.Importante" %>

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
    
    <div class="whole-wrap">
		<div class="container">
            <div class="section-top-border">
                <asp:Repeater ID="rpRuta" runat="server">
                    <ItemTemplate>
                        <div class="section-top-border pt-0">
                            <h3 class="mb-30 title_color"><%# Eval("Titulo") %></h3>
                            <div class="row">
                                <div class="col-lg-12">
                                    <blockquote class='<%# Eval("Estilo") %>'>
                                        <%# Eval("Texto") %>
                                    </blockquote>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    <script>
        $(document).ready(function () {
            $('.nav-link[href="Importante.aspx"]').parent('li').addClass('active');
        });
    </script>
</asp:Content>
