<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="DateRequest.aspx.cs" Inherits="TermProject.DateRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h1>Date Request</h1>
            
            </div> 
        <div class="row">
            <div class="col-lg-4">
                 <h1>Planned Dates</h1>
                
            <asp:GridView ID="gvPlannedDates" class="" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UserName1" HeaderText="Name" />
                    <asp:BoundField DataField="UserName2" HeaderText="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                </Columns>
                 </asp:GridView>
            </div>
           <div class="col-lg-4">
                 <h1>Pending Dates</h1>
            <asp:GridView ID="gvPendingDates" class="" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UserName1" HeaderText="Name" />
                    <asp:BoundField DataField="UserName2" HeaderText="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                </Columns>
                 </asp:GridView>
            </div>
            
            </div>    
    </div>
</asp:Content>
