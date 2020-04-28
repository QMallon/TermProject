<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="DateRequest.aspx.cs" Inherits="TermProject.DateRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form runat="server">
    <div class="container">
        <div class="row">
            <h1>Date Request</h1>
            
            </div> 
        <div class="row">
            <div class="col-lg-6">
                 <h1>Planned Dates</h1>
                <div class="table-responsive">

                
            <asp:GridView ID="gvPlannedDates" CssClass="table" runat="server" AutoGenerateColumns="False">
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
           <div class="col-lg-6">
                 <h1>Pending Dates</h1>
               <div class="table-responsive">

               
            <asp:GridView ID="gvPendingDates" CssClass="table" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPendingDates_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="UserName1" HeaderText="Name" />
                    <asp:BoundField DataField="UserName2" HeaderText="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Approve">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" CssClass="btn-success" runat="server" OnClick="btnApprove_Click" Text="Approve" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pass">
                        <ItemTemplate>
                            <asp:Button ID="btnPass" CssClass="btn-danger" runat="server" OnClick="btnPass_Click" Text="Pass" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                 </asp:GridView>
            </div>
               </div>
            
            </div>    
    </div>
      </form>
</asp:Content>
