<%@ Page Title="" Language="C#" MasterPageFile="~/THC.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TriniHorseCuba.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section class="home_banner_area">
		<div class="banner_inner">
			<div class="container">
				<div class="row fullscreen d-flex align-items-center justify-content-center">
					<div class="banner_content">
                        <img id="ImgSlide" src="img/logoTHC.png" alt="LogoTHC" class="w-75" />
					</div>
				</div>
			</div>
		</div>
	</section>

    <section class="section_gap about-area">
		<div class="container">
			<div class="single-about row">
				<div class="col-lg-4 col-md-6 no-padding about-left">
					<div class="about-content">
						<h3><asp:Label ID="lblTituloFlyer" runat="server"></asp:Label></h3>
						<p><asp:Label ID="lblTextoFlyer" runat="server"></asp:Label></p>
					</div>
				</div>
				<div class="col-lg-8 col-md-6 text-center no-padding about-right">
					<div class="about-thumb">
						<img src="img/about-img.jpg" class="img-fluid info-img" alt="">
					</div>
				</div>
			</div>
		</div>
	</section>

    <section class="feature-area">
		<div class="container">
            <div class="row align-items-end justify-content-left">
				<div class="col-lg-12">
					<div class="main_title">
						<h5><asp:Label ID="lblTituloServicios" runat="server"></asp:Label></h5>
                        <asp:Label ID="lblSubtiServicios" runat="server"></asp:Label>
					</div>
				</div>
			</div>

			<div class="row justify-content-around">
                <asp:Repeater ID="rpServSup" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6">
					        <div class="single-feature">
						        <div class="feature-details">
                                    <h5><%# Eval("Titulo") %></h5>
						        </div>
						        <div class="feature-thumb p-1">
							        <img class="img-fluid" src='<%# "../img/service/" + Eval("Imagen") %>' alt="">
						        </div>
						        <div class="feature-details mt-3 mb-0">
						            <h6 class="text-danger">USD <%# Eval("Precio","{0:N2}") %> x <%# Eval("Concepto") %></h6>
                                    <a href="Galeria.aspx" class="primary-btn"><%# Eval("TextoBoton") %></a>
						        </div>
					        </div>
				        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="row align-items-end justify-content-left">
				<div class="col-lg-12">
					<div class="main_title">
                        <asp:Label ID="lblTextoServicios" runat="server"></asp:Label>
					</div>
				</div>
			</div>

            <div class="row justify-content-around">
                <asp:Repeater ID="rpServInf01" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6">
					        <div class="single-feature">						
						        <div class="feature-thumb p-1">
							        <img class="img-fluid" src='<%# "../img/service/" + Eval("Imagen") %>' alt="">
						        </div>
                                <div class="feature-details mt-20">
                                    <h5><%# Eval("Titulo") %></h5>
                                    <p><%# Eval("Texto") %></p>
						        </div>
                                <div class="feature-details mt-3 mb-0">
						            <h6 class="text-danger">USD <%# Eval("Precio","{0:N2}") %> x <%# Eval("Concepto") %></h6>
                                    <a href="Galeria.aspx" class="primary-btn"><%# Eval("TextoBoton") %></a>
						        </div>
					        </div>
				        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row justify-content-around">
                <asp:Repeater ID="rpServInf02" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6">
					        <div class="single-feature">						
						        <div class="feature-thumb p-1">
							        <img class="img-fluid" src='<%# "../img/service/" + Eval("Imagen") %>' alt="">
						        </div>
                                <div class="feature-details mt-20">
                                    <h5><%# Eval("Titulo") %></h5>
                                    <p><%# Eval("Texto") %></p>
						        </div>
                                <div class="feature-details mt-3 mb-0">
						            <h6 class="text-danger">USD <%# Eval("Precio","{0:N2}") %> x <%# Eval("Concepto") %></h6>
                                    <a href="Galeria.aspx" class="primary-btn"><%# Eval("TextoBoton") %></a>
						        </div>
					        </div>
				        </div>
                    </ItemTemplate>
                </asp:Repeater>
			</div>
		</div>
	</section>

    <div class="cta-area section_gap">
		<div class="container">
			<div class="row">
				<div class="col-lg-5">
                    <h1><asp:Label ID="lblTituloEncuentro" runat="server"></asp:Label></h1>
					<p><asp:Label ID="lblTextoEncuentro" runat="server"></asp:Label></p>
                    <a href="#" class="primary-btn mb-40" data-toggle="modal" data-target="#THCmodal"><asp:Label ID="lblTextoBoton" runat="server"></asp:Label></a>
				</div>
				<div class="offset-lg-1 col-lg-6">
					<img class="cta-img img-fluid" src="img/cta-img.png" alt="">
				</div>
			</div>
		</div>
	</div>

    <section class="testimonials-area section_gap">
		<div class="container">
			<div class="testi-slider owl-carousel" data-slider-id="1">
				<div class="item">
					<div class="testi-item">
						<img src="img/quote.png" alt="">
						<h4>Valerie Rosas</h4>
						<ul class="list">
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
						</ul>
						<div class="wow fadeIn" data-wow-duration="1s">
							<p>The scenery and excellent food, great service</p>
						</div>
					</div>
				</div>
				<div class="item">
					<div class="testi-item">
						<img src="img/quote.png" alt="">
						<h4>Jhoanna Chavez</h4>
						<ul class="list">
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
						</ul>
						<div class="wow fadeIn" data-wow-duration="1s">
							<p>A unique and unforgettable experience, I recommend taking many photos</p>
						</div>
					</div>
				</div>
				<div class="item">
					<div class="testi-item">
						<img src="img/quote.png" alt="">
						<h4>Andy Párraga</h4>
						<ul class="list">
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
							<li><a href="#"><i class="fa fa-star"></i></a></li>
						</ul>
						<div class="wow fadeIn" data-wow-duration="1s">
							<p>Excellent service, I highly recommend them.</p>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    <script>
        $(document).ready(function () {
            $('.nav-link[href="Inicio.aspx"]').parent('li').addClass('active');
        });
    </script>
</asp:Content>
