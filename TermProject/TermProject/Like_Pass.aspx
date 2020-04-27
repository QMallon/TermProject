<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Like_Pass.aspx.cs" Inherits="TermProject.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="container">
        <div class="row">
            <div class="column">
                <h2>Liked</h2>
                <div class="table-responsive-md">
                    <asp:GridView ID="gvLikes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvLikes_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="firstname" HeaderText="First Name" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                            <asp:TemplateField HeaderText="Pass">
                                <ItemTemplate>
                                    <asp:Button ID="btnPass" class="btn-danger" runat="server" OnClick="btnPass_Click" Text="Pass" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Profile">
                                <ItemTemplate>
                                    <asp:Button ID="btnViewProfile" CssClass="btn-info" runat="server" OnClick="Button1_Click2" Text="View Profile" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
    </asp:GridView>
                </div>
                
            </div>
            <div class="column">
                <h2>Passed</h2>
                <div class="table-responsive-md">
                    <asp:GridView ID="gvDislikes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvDislikes_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="firstName" HeaderText="First Name" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                            <asp:TemplateField HeaderText="Like">
                                <ItemTemplate>
                                    <asp:Button ID="btnLike" class="btn-primary" runat="server" Text="Like" OnClick="btnLike_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Profile">
                                <ItemTemplate>
                                    <asp:Button ID="btnviewProfiledlike" runat="server" OnClick="Button1_Click2" CssClass="btn-info" Text="View Profile" />
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
