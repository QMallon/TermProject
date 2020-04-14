<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="TermProject.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div runat="server" id="divNewProfile"> <!-----------New profile-------------->


        <!-- Material form register -->
<div class="card">

    <h5 class="card-header info-color white-text text-center py-4">
        <strong> Built your profile </strong>
    </h5>

    <!--Card content-->
    <div class="card-body px-lg-5 pt-0">

        <!-- Form -->
        <form class="text-center" style="color: #757575;" action="#!">

            <div class="form-row">

			<div class="col">
                    <!-- First name -->
                    <div class="md-form">

    <asp:Label ID="lblFirstName" runat="server" Text="First Name:" AssociatedControlID="txtFirstName" ></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox>


                    </div>
                </div>
                <div class="col">
                    <!-- Last name -->
                    <div class="md-form">

                        
    <asp:Label ID="lblLastName" runat="server" Text="Last Name" AssociatedControlID="txtLastName"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>


                   
				   </div>
                </div>
            </div>

            <!-- E-mail -->
            <div class="md-form mt-0">

    <asp:Label ID="lblStreetAddress" runat="server" Text="Street Address:" AssociatedControlID="txtStreetAddress"></asp:Label>
    <asp:TextBox ID="txtStreetAddress" runat="server" class="form-control"></asp:TextBox>
            
			</div>

            <!-- Password -->
            <div class="md-form">

   <asp:Label ID="lblStreetAddressLn2" runat="server" Text="Street Address Line 2:" AssociatedControlID="txtStreetAddressLn2"></asp:Label>
    <asp:TextBox ID="txtStreetAddressLn2" runat="server" class="form-control"></asp:TextBox>

            
			</div>

            <!-- Phone number -->
            <div class="md-form">

<asp:Label ID="lblCity" runat="server" Text="City:" AssociatedControlID="txtCity"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server" class="form-control"></asp:TextBox>


            </div>

            <!-- Newsletter -->
            <div class="form-check">
 
    <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="txtState"></asp:Label>
    <asp:TextBox ID="txtState" runat="server" class="form-control"></asp:TextBox>

    <asp:Label ID="lblZipcode" runat="server" Text="Postal /Zip code:" AssociatedControlID="txtZipcode"></asp:Label>
    <asp:TextBox ID="txtZipcode" runat="server" class="form-control"></asp:TextBox>

       
	        </div>
            <br>
            <asp:Button ID="btnSudmit" runat="server" Text="Submit" OnClick="btnSudmit_Click" class="btn btn-success" /> <!--Submit button--->
       
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        
        </form>
        <!-- Form -->

    </div>

</div>
<!-- Material form register -->

        </div>


</asp:Content>
