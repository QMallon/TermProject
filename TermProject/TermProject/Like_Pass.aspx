<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Like_Pass.aspx.cs" Inherits="TermProject.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="column">
                <h2>Liked</h2>
                <div class="table-responsive-md">
                    <asp:GridView ID="gvLikes" runat="server">
    </asp:GridView>
                </div>
                
            </div>
            <div class="column">
                <h2>Passed</h2>
                <div class="table-responsive-md">
                    <asp:GridView ID="gvDislikes" runat="server">
    </asp:GridView>
                </div>
                
            </div>
        </div>

    
    </div>
    

</asp:Content>
