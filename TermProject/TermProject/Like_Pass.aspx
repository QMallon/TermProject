<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Like_Pass.aspx.cs" Inherits="TermProject.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="column">
                <h2>Liked</h2>
                <div class="table-responsive-md">
                    <asp:GridView ID="gvLikes" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="firstname" HeaderText="First Name" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                            <asp:TemplateField HeaderText="Pass">
                                <ItemTemplate>
                                    <asp:Button class="btn-danger" ID="btnPass" runat="server" OnClick="Button1_Click" Text="Pass" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:Button class="btn-success" ID="btnView" runat="server" OnClick="Button1_Click1" Text="View Profile" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
    </asp:GridView>
                </div>
                
            </div>
            <div class="column">
                <h2>Passed</h2>
                <div class="table-responsive-md">
                    <asp:GridView ID="gvDislikes" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="firstName" HeaderText="First Name" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button class="btn-danger" ID="Button2" runat="server" OnClick="Button1_Click" Text="Pass" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button class="btn-success" ID="Button1" runat="server" OnClick="Button1_Click1" Text="View Profile" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
    </asp:GridView>
                </div>
                
            </div>
        </div>

    
    </div>
    

</asp:Content>
