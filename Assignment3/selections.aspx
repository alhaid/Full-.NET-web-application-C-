<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="selections.aspx.cs" Inherits="Assignment3.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Hamzah Shafeeq</h3>
    <br />
    <lable>Please select what you want to view and click on the button</lable>
    <br />
    <br />
    <fieldset class="selection-left">
        <legend>Select by genre</legend>
        <br />
        <asp:RadioButtonList ID="genreRadioButtons" runat="server">
            <asp:ListItem Selected="True">Action</asp:ListItem>
            <asp:ListItem>Comedy</asp:ListItem>
            <asp:ListItem>Drama</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="GenreButton" runat="server" Text="View" OnClick="GenreButton_Click" />
        <br />
        <br />
        <asp:GridView ID="GenreGridView" runat="server"></asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </fieldset>
    <fieldset class="selection-right">
        <legend>Select by director</legend>
        <br />
        <asp:DropDownList ID="directorDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="directorDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="DirectorGridView" runat="server"></asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    </fieldset>
</asp:Content>

