<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessagesControl.ascx.cs" Inherits="TermProject.WebUserControl1" %>

<br>


<div class="card-footer" style="text-align: center">
<asp:DropDownList ID="ddlMatches" runat="server" OnSelectedIndexChanged="ddlMatches_SelectedIndexChanged"></asp:DropDownList>
<br>


  <asp:Repeater ID="rpMessages" runat="server">

               <ItemTemplate>
                                <br>
                                <asp:Label ID="lblSender" style="font-weight:bold" runat="server" Text='<%#Eval("SenderID")%>'></asp:Label> :
                                <asp:Label ID="lblMessage" runat="server" Text='<%# Eval("Message") %>'></asp:Label> 
           
                    </ItemTemplate>
    </asp:Repeater>
<br>
    <br>
<asp:TextBox ID="txtMessage" runat="server" ReadOnly="true" Rows="5" Height="94px" style="margin-left: 0px" Width="423px"></asp:TextBox>
<br>

<asp:Button ID="btnSend" class="btn btn-success" runat="server" Text="Send" OnClick="btnSend_Click" />
</div>