<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Assignment3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Hamzah Shafeeq</h3>
    <br />
<lable>Please select a movie form the menu bellow:</lable>
    <br />
    <br />
<div class="left">
    <asp:DropDownList ID="IndexDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="IndexDropDownList_SelectedIndexChanged">
        <asp:ListItem>Movie</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="right">
    <asp:DetailsView ID="IndexDetailsView" runat="server" Height="50px" Width="302px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</div>
</asp:Content>