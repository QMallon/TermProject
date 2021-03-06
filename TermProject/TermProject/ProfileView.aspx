﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="ProfileView.aspx.cs" Inherits="TermProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h2 {
        
            text-align:center;
            font-weight:bold;
        
        
        }
        h1{
            text-align:center;
        }
            
            
            
     </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid text-center">    
  <div class="row content">
    <div class="col-sm-2 sidenav">
    </div>

    <div class="col-sm-8 text-left"> 
	<form runat="server">
	    <div class="container" id="divProfile" runat="server">

       
        <div class ="row text-center">
            <asp:Image CssClass="rounded mx-auto d-block" height="200" width="200"  imageAlign="Middle" ID="imgProfilePicture" ImageUrl="\Img\Profiles\Default.png" runat="server" />
            <h1>
               <asp:Label ID="lblName" runat="server" Text=""></asp:Label>

            </h1>
            
            
        </div>
        <div class ="row">
            <h2>Personal Info</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;" runat="server" id="PersonalInfo">
            <asp:Label class="" ID="lblPersonalInfo" runat="server" Text=""></asp:Label>
        </div>
        <div class ="row">
            <h2>Values</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;">
            <asp:Label  ID="lblValues" runat="server" Text=""></asp:Label>
        </div>

        <div class ="row">
            <h2>Interests</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;">
            <asp:Label ID="lblInterests" runat="server" Text=""></asp:Label>
        </div>

        
        <div class ="row" style="white-space:pre-wrap;">
            <h2>Likes and Dislikes</h2>
            
        </div>
        <div class="row" style="white-space:pre-wrap;">
            <asp:Label ID="lblLikes" runat="server" Text=""></asp:Label>
        </div>
        
        <div class ="row">
            <h2>Favorites</h2>
            

    </div>
        <div class="row">
            <asp:Label ID="lblFavorites" runat="server" Text=""></asp:Label>
            </div>

        <div class ="row">
        <asp:Button class="btn-primary" ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click" /><asp:Button class="btn-danger" ID="btnPass" runat="server" Text="Pass" OnClick="btnPass_Click" />
        <asp:Button class="btn-danger" ID="btnBlock" runat="server" Text="Block" OnClick="btnBlock_click" />
        <asp:Button class="btn-primary" ID="btnMessage" runat="server" Text="Message" />
        <asp:Button class="btn-primary" ID="btnDateRequest" runat="server" Text="Request Date" OnClick="btnDateRequest_Click1"  />
        
        
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
        </div>
            </div>
   
            </form>
    </div>

    <div class="col-sm-2 sidenav">
    </div>
  </div>
</div>

</asp:Content>
