<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TriniHorseCuba.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <title>THCuba - Inicio</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
        </ol>
    </nav>

    <div class="pb-3">
        <h1>Dashboard</h1>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">
</asp:Content>
