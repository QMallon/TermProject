<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="container">
        
        <div class="row justify-content-center align-items-center" style="height:100vh">
            <div class="col-4">
                <h1 style="align-content: center" > Login</h1>
                <div class="card">
                    <div class="card-body">
                        <form>
                            <div class="form-group">
                                <label for="txtLoginUserName">Username</label>
                        <asp:TextBox class="form-control" ID="txtLoginUserName"  runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword">Password</label>
                        <asp:TextBox ID="txtLoginPassword" class="form-control" type="password" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="chkRemember">Remember me</label>
                            <asp:CheckBox class="custom-checkbox" ID="chkRemember" runat="server" />
                            </div>
                            <asp:Button ID="btnRegister" class="btn btn-danger" runat="server" Text="Register" OnClick="btnRegister_Click" />
                            <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>
