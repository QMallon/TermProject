<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="ProfileView.aspx.cs" Inherits="TermProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form runat="server">
    <div class="container">
       
        <div class ="row">
            <h1>
               <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>

            </h1>
            <asp:Image ID="imgProfilePicture" runat="server" />
        </div>
        <div class ="row">
            <h2>Personal Info</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;" runat="server" id="PersonalInfo">
            <asp:Label class="" ID="lblPersonalInfo" runat="server" Text="Label"></asp:Label>
        </div>
        <div class ="row">
            <h2>Values</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;">
            <asp:Label ID="lblValues" runat="server" Text="Label"></asp:Label>
        </div>

        <div class ="row">
            <h2>Interests</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;">
            <asp:Label ID="lblInterests" runat="server" Text="Label"></asp:Label>
        </div>

        
        <div class ="row" style="white-space:pre-wrap;">
            <h2>Likes and Dislikes</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;">
            <asp:Label ID="lblLikes" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div class ="row">
            <h2>Favorites</h2>
            

    </div>
        <div class="row">
            <asp:Label ID="lblFavorites" runat="server" Text="Label"></asp:Label>
        </div>
        <div class ="row">
           <asp:Button class="btn-primary" ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click" /><asp:Button class="btn-danger" ID="btnPass" runat="server" Text="Pass" OnClick="btnPass_Click" />
            <asp:Button class="btn-danger" ID="btnBlock" runat="server" Text="Block" OnClick="btnBlock_click" />
        </div>
        <div class="row">
        <asp:Button class="btn-primary" ID="btnMessage" runat="server" Text="Message" />
        <asp:Button class="btn-primary" ID="btnDateRequest" runat="server" Text="Request Date" OnClick="btnDateRequest_Click1"  />
        </div>
        </div>
    <asp:Panel ID="pnlDateRequest" runat="server" style="margin-top: 1px" Visible="False">
        <h2>Date Request</h2>
        <label class="col-form-label" for="txtLocation">Enter Location</label>
        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
        <label class="col-form-label" for="txtDescription">Enter Description</label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <label class="col-form-label" for="txtDate">Select Date</label>
        <asp:TextBox ID="txtDate" class="input-append date" runat="server"></asp:TextBox>
        






        <asp:Button ID="btnDateSubmit" CssClass="btn-success" runat="server" Text="Submit" OnClick="btnDateSubmit_Click" />
        






    </asp:Panel>

    </form>
</asp:Content>
