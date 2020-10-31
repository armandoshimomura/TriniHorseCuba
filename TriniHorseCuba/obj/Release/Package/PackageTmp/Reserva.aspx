<%@ Page Title="" Language="C#" MasterPageFile="~/THC.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="TriniHorseCuba.Reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="css/calendario.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section class="banner_area">
        <div class="banner_inner overlay d-flex align-items-center">
            <div class="container">
                <div class="banner_content text-center">
                    <div class="page_link">
                        <a href="Inicio.aspx">Inicio</a>
                        <a href="#">Reserva</a>
                    </div>
                    <h2>Reserva</h2>
                </div>
            </div>
        </div>
    </section>

    <div class="whole-wrap">
        <div class="container">
            <form id="frmReserva" runat="server">
                <asp:HiddenField ID="hdfIdioma" runat="server" />
                <div class="section-top-border">
                    <div class="row">
                        <div class="col-12 col-lg-8">
                            <div class="month">
                                <ul>
                                    <asp:HiddenField ID="hdfFecha" runat="server" />
                                    <asp:LinkButton ID="lbPrev" runat="server" CssClass="prev" OnClick="lbPrev_Click">&#10094;</asp:LinkButton>
                                    <asp:LinkButton ID="lbNext" runat="server" CssClass="next" OnClick="lbNext_Click">&#10095;</asp:LinkButton>                                    
                                    <li>
                                        <asp:Label ID="lblMes" runat="server" Text=""></asp:Label><br>
                                        <span style="font-size: 18px">
                                            <asp:Label ID="lblAnho" runat="server" Text=""></asp:Label>
                                        </span>
                                    </li>
                                </ul>
                            </div>

                            <ul class="weekdays">
                                <asp:Repeater ID="rpSemana" runat="server">
                                    <ItemTemplate>
                                        <li><%# Eval("NombreDia") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>

                            <ul class="days">
                                <asp:Repeater ID="rpDia" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnbDia" CssClass="li"
                                            Text='<%# Eval("Dia") + "<br /> Únete a 4 persona" %>'
                                            CommandName="Reservar"
                                            CommandArgument="5"
                                            OnCommand="lnbDia_Command"
                                            runat="server" />
                                    </ItemTemplate>                                    
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="col-12 col-lg-4">
                            <div class="row">
                                <div class="form-group col-12 text-danger">
                                    (*) datos obligatorios
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="ddlNroPersonas">Cantidad de personas</label> <label class="ml-1 text-danger">*</label>
                                    <asp:DropDownList ID="ddlNroPersonas" CssClass="form-control w-100" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="txtResponsable">Responsable del grupo</label> <label class="ml-1 text-danger">*</label>
                                    <asp:TextBox ID="txtResponsable" CssClass="form-control" runat="server" placeholder="Ingrese dato"></asp:TextBox>                                
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="ddlNroCaballos">Cantidad de caballos (1 porsona x caballo)</label> <label class="ml-1 text-danger">*</label>
                                    <asp:DropDownList ID="ddlNroCaballos" CssClass="form-control w-100" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="ddlNroCalesas">Cantidad de calesas (2 personas x calesa)</label>
                                    <asp:DropDownList ID="ddlNroCalesas" CssClass="form-control w-100" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="txtNroEntradasParque">Entradas al parque</label>
                                    <asp:TextBox ID="txtNroEntradasParque" runat="server" CssClass="form-control border-0" Text="# entradas incluidas"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="ddlNroJugosCanha">Cantidad de jugos de caña</label>
                                    <asp:DropDownList ID="ddlNroJugosCanha" CssClass="form-control w-100" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="ddlNroCafeTabaco">Cantidad de café con tabaco</label>
                                    <asp:DropDownList ID="ddlNroCafeTabaco" CssClass="form-control w-100" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-12">
                                    <label for="ddlNroComidaCriolla">Cantidad de comidas criollas</label>
                                    <asp:DropDownList ID="ddlNroComidaCriolla" CssClass="form-control w-100" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="form-group text-center col-12">
                                    <h4>
                                        <asp:Label ID="lblTotal" CssClass="text-danger" runat="server" Text="Total: USD 120.00"></asp:Label>
                                    </h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    
</asp:Content>
