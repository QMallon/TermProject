<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="ProfileView.aspx.cs" Inherits="TermProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class ="row">
            <h1>
               <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>

            </h1>
            <asp:Image ID="imgProfilePicture" runat="server" />
        </div>
        <div class ="row">
            <h2>Personal Info</h2>
            <asp:Label ID="lblPersonalInfo" runat="server" Text="Label"></asp:Label>
        </div>
        <div class ="row">
            <h2>Values</h2>
            <asp:Label ID="lblValues" runat="server" Text="Label"></asp:Label>
        </div>
        <div class ="row">
            <h2>Interests</h2>
            <asp:Label ID="lblInterests" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div class ="row">
            <h2>Likes and Dislikes</h2>
            <asp:Label ID="lblLikes" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div class ="row">
            <h2>Favorites</h2>
            <asp:Label ID="lblFavorites" runat="server" Text="Label"></asp:Label>

    </div>
        <div class ="row">
            <asp:Button class="btn-primary" ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click" /><asp:Button class="btn-danger" ID="btnPass" runat="server" Text="Pass" OnClick="btnPass_Click" />
        </div>
        <div class="row">
        <asp:Button class="btn-primary" ID="btnMessage" runat="server" Text="Message" />
        </div>
        </div>

</asp:Content>
