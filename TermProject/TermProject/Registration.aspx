<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div runat="server" id="divNewUser"> <!-----------New User-------------->


        <!-- Material form register -->
<div class="card">

    <h5 class="card-header info-color white-text text-center py-4">
        <strong> New user registration </strong>
    </h5>

    <!--Card content-->
    <div class="card-body px-lg-5 pt-0">

        <!-- Form -->
        <form class="text-center" style="color: #757575;" action="#!">

            <div class="form-row">

			<div class="col">
                    <!-- First name -->
                    <div class="md-form">

                        
    <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername" ></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server" class="form-control"></asp:TextBox>


                    </div>
                </div>
                <div class="col">
                    <!-- Last name -->
                    <div class="md-form">

                        
    <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" class="form-control"></asp:TextBox>


                   
				   </div>
                </div>
            </div>

            <!-- E-mail -->
            <div class="md-form mt-0">

    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm your Password:" AssociatedControlID="txtConfirmPassword"></asp:Label>
    <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control"></asp:TextBox>

            
			</div>

            <!-- Password -->
            <div class="md-form">

   <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>



            
			</div>

            <!-- Phone number -->
            <div class="md-form">


    <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm email:" AssociatedControlID="txtConfirmEmail"></asp:Label>
    <asp:TextBox ID="txtConfirmEmail" runat="server" class="form-control"></asp:TextBox>


            </div>

            <!-- Newsletter -->
            <div class="form-check">
    <br>
    <asp:Label ID="lblSecQuestion" runat="server" Text="Security question:" AssociatedControlID="txtSecurityResponse" ></asp:Label>
    <asp:DropDownList ID="ddlSecurityQuestion" runat="server" class="btn btn-primary dropdown-toggle">

        <asp:listitem text="What was the house number and street name you lived in as a child?" value="What was the house number and street name you lived in as a child?"></asp:listitem>
        <asp:listitem text="What were the last four digits of your childhood telephone number?" value="What were the last four digits of your childhood telephone number?"></asp:listitem>
        <asp:listitem text="What primary school did you attend?" value="What primary school did you attend?"></asp:listitem>
        <asp:listitem text="In what town or city was your first full time job?" value="In what town or city was your first full time job?"></asp:listitem>
        <asp:listitem text="In what town or city did you meet your spouse/partner?" value="In what town or city did you meet your spouse/partner?"></asp:listitem>
        <asp:listitem text="What are the last five digits of your driver's licence number?" value="What are the last five digits of your driver's licence number?"></asp:listitem>
        <asp:listitem text="In what town or city did your mother and father meet?" value="In what town or city did your mother and father meet?"></asp:listitem>

    </asp:DropDownList>
    <asp:TextBox ID="txtSecurityResponse" runat="server" class="form-control"></asp:TextBox>
    <br>

    <asp:Label ID="lblSecQuestion2" runat="server" Text="Security question:" AssociatedControlID="txtSecurityResponse2"></asp:Label>
    <asp:DropDownList ID="ddlSecurityQuestion2" runat="server" class="btn btn-primary dropdown-toggle">


        <asp:listitem text="What was the house number and street name you lived in as a child?" value="What was the house number and street name you lived in as a child?"></asp:listitem>
        <asp:listitem text="What were the last four digits of your childhood telephone number?" value="What were the last four digits of your childhood telephone number?"></asp:listitem>
        <asp:listitem text="What primary school did you attend?" value="What primary school did you attend?"></asp:listitem>
        <asp:listitem text="In what town or city was your first full time job?" value="In what town or city was your first full time job?"></asp:listitem>
        <asp:listitem text="In what town or city did you meet your spouse/partner?" value="In what town or city did you meet your spouse/partner?"></asp:listitem>
        <asp:listitem text="What are the last five digits of your driver's licence number?" value="What are the last five digits of your driver's licence number?"></asp:listitem>
        <asp:listitem text="In what town or city did your mother and father meet?" value="In what town or city did your mother and father meet?"></asp:listitem>


    </asp:DropDownList> 
    <asp:TextBox ID="txtSecurityResponse2" runat="server" class="form-control"></asp:TextBox>

    <br>
    <asp:Label ID="lblSecQuestion3" runat="server" Text="Security question:" AssociatedControlID="txtSecurityResponse3"></asp:Label>
    <asp:DropDownList ID="ddlSecurityQuestion3" runat="server" class="btn btn-primary dropdown-toggle">

        <asp:listitem text="What was the house number and street name you lived in as a child?" value="What was the house number and street name you lived in as a child?"></asp:listitem>
        <asp:listitem text="What were the last four digits of your childhood telephone number?" value="What were the last four digits of your childhood telephone number?"></asp:listitem>
        <asp:listitem text="What primary school did you attend?" value="What primary school did you attend?"></asp:listitem>
        <asp:listitem text="In what town or city was your first full time job?" value="In what town or city was your first full time job?"></asp:listitem>
        <asp:listitem text="In what town or city did you meet your spouse/partner?" value="In what town or city did you meet your spouse/partner?"></asp:listitem>
        <asp:listitem text="What are the last five digits of your driver's licence number?" value="What are the last five digits of your driver's licence number?"></asp:listitem>
        <asp:listitem text="In what town or city did your mother and father meet?" value="In what town or city did your mother and father meet?"></asp:listitem>

    </asp:DropDownList> 


    <asp:TextBox ID="txtSecurityResponse3" runat="server" class="form-control"></asp:TextBox>


    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        
                <br>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click1" />

       
	   </div>

       
        </form>
        <!-- Form -->

    </div>

</div>
<!-- Material form register -->

        </div>

</asp:Content>