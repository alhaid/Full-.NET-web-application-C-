<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Assignment3.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h3>Hamzah Shafeeq</h3>
    <br />
    <lable>Please fill in all the fields to add a new movie or choose from the frop down menu to delete one:</lable>
    <br />
    <br />


    <fieldset class="update-left">
        <legend>Add a new movie</legend>
        <br />
        <label>Movie ID</label>
        <input type="text" id="movieID" placeholder="Less than 10 char" runat="server" />
        <br />
        <label>Movie Name</label>
        <input type="text" id="movieTitle" runat="server" />
        <br />
        <label>Movie Release Date</label>
        <input type="text" id="movieReleaseDate" placeholder="YYYY-MM-DD" runat="server" />
        <br />
        <label>Genre ID</label>
        <input type="text" id="genreID" placeholder="Less than 10 char" runat="server" />
        <br />
        <label>Genre Type</label>
        <input type="text" id="genreType" runat="server" />
        <br />
        <label>Director ID</label>
        <input type="text" id="directorID" placeholder="Less than 10 char" runat="server" />
        <br />
        <label>Director Name</label>
        <input type="text" id="directorName" runat="server" />
        <br />
        <label>Director Nationality</label>
        <input type="text" id="directorNationality" runat="server" />
        <br />
        <br />
        <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
    </fieldset>



    <fieldset class="update-right">
        <legend id="remove-legend">Remove a movie</legend>
        <br />
        <br />
        <asp:DropDownList ID="UpdateDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UpdateDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="removeButton" runat="server" Text="Delete" OnClick="Button1_Click" />
    </fieldset>

</asp:Content>
