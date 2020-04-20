<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h1>Login</h1>
            </div>
            </div>

            <form>
                    <div class="row">
                        <div class="col-4">
                            <label for="txtUserName">UserName</label>
                        <asp:TextBox class="form-control" ID="txtUserName"  runat="server"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label for="txtPassword">Password</label>
                        <asp:TextBox ID="txtPassword" class="form-control" type="password" runat="server"></asp:TextBox>
                            </div>
                    </div>
                <div class="row">
                    <div class="col-4">
                        Remember Me? <asp:CheckBox ID="chkRemember" runat="server" />
                    </div>
                </div>
        <div class="row">
                        <div class="col-12">
                            <label for="btnRegister">Dont have an account?</label>
                            <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Register" OnClick="btnRegister_Click" />
                            
                            </div>
                    </div>
        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
            
        </div>
                </form>
                </div>

</asp:Content>
