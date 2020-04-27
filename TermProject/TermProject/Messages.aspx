<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="TermProject.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    
              <asp:Repeater ID="rpMessages" runat="server">

               <ItemTemplate>
               
                    <div class="col-lg-3 col-md-3 col-sm-3">
                            <br>
                            <div class="card " style="text-align:center;background-color:lightgray;border-radius: 5px;height:300px;width:280px">
                                
                                <br>
                                
                                <asp:Label ID="lblSender" class="" runat="server" style="text-align:center;font-weight:bold; font-size:20px" Text='<%#Eval("SenderID")%>'></asp:Label>
                               
                                <asp:Label ID="lblMessage" runat="server" Text='<%#Eval("Message")%>'></asp:Label>
                                
                               <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label> </p>
                            
                                <asp:Button class="btn btn-success" ID="btnRptLike" runat="server" Text="Like" />
                                
                                <asp:Button class="btn btn-danger" ID="btnRptDislike" runat="server" Text="Not Like" />
                        
                        </div>

                    </div>
           
                    </ItemTemplate>
    </asp:Repeater>
    

    </form>
</asp:Content>
