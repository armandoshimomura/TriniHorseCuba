<%@ Page Title="" Language="C#" MasterPageFile="~/THC.Master" AutoEventWireup="true" CodeBehind="Galeria.aspx.cs" Inherits="TriniHorseCuba.Galeria" %>

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
					<h2><asp:Label ID="lblTitulo_1" runat="server"></asp:Label></h2>
                </div>
            </div>
        </div>
    </section>

    <div class="whole-wrap">
		<div class="container">
            <div class="section-top-border">
		        <h3 class="title_color"><asp:Label ID="lblTitulo_2" runat="server"></asp:Label></h3>
		        <div class="row gallery-item">
			        <div class="col-md-4">
				        <a href="img/galery/g1.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g1.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g2.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g2.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g3.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g3.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g4.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g4.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g5.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g5.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g6.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g6.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g7.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g7.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g8.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g8.jpg);"></div>
				        </a>
			        </div>
                    <div class="col-md-4">
				        <a href="img/galery/g9.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g9.jpg);"></div>
				        </a>
			        </div>
			        <div class="col-md-4">
				        <a href="img/galery/g10.jpg" class="img-gal">
					        <div class="single-gallery-image" style="background: url(img/galery/g10.jpg);"></div>
				        </a>
			        </div>
		        </div>
	        </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    <script>
        $(document).ready(function () {
            $('.nav-link[href="Galeria.aspx"]').parent('li').addClass('active');
        });
    </script>
</asp:Content>
