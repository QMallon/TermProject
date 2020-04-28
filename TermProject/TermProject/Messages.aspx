<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="TermProject.WebForm7" %>

<%@ Register Src="~/MessagesControl.ascx" TagPrefix="uc1" TagName="MessagesControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
  
<div class="container-fluid text-center">    
  <div class="row content">
    <div class="col-sm-2 sidenav">
    </div>

    <div class="col-sm-8 text-left"> 
	<form runat="server">
         <div id="divMessageControl" runat="server">
    
        <uc1:MessagesControl runat="server" id="MessagesControl" />
    
         </div>

	</form>
    </div>

    <div class="col-sm-2 sidenav">
    </div>
  </div>
</div>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
   
</asp:Content>
