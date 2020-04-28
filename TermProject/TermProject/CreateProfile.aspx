<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="TermProject.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  

   <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">Logo</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <li class="active"><a href="#">Home</a></li>
        <li><a href="#">Profile</a></li>
        <li><a href="#">Matches</a></li>
        <li><a href="#">Messages</a></li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
      </ul>
    </div>
  </div>
</nav>
  
<div class="container-fluid text-center">    
     <div class="row content">
    <div class="col-sm-2 sidenav">
    </div>
    
	<div class="col-sm-8 text-left"> 
        <form runat="server">
            

    <div runat="server" id="divNewProfile"> <!-----------New profile-------------->


        <!-- Material form register -->
<div id="divMain" runat="server" class="card">

    <h5 class="card-header info-color white-text text-center py-4">
        <strong> Built your profile </strong>
    </h5>

    <!--Card content-->
    <div class="card-body px-lg-5 pt-0">

        <!-- Form -->
        <form class="text-center" style="color: #757575;" action="#!">

<br>

<asp:Image ID="Image1" runat="server" Height = "100" Width = "100" style="border-radius: 50%;display: block;margin-left: auto;margin-right: auto; background-color:lightgrey;" BorderColor="Red" BorderStyle="Solid" />

<br>

<asp:FileUpload ID="FileUpload1" runat="server" style="display: block;margin-left: auto;margin-right: auto;" class="btn btn-primary"/>

<br>

<asp:Button ID="btnUpload" Text="SaveImage" runat="server" OnClick="UploadFile" style="display: block;margin-left: auto;margin-right: auto;" class="btn btn-success" UseSubmitBehavior="false" />
            
            <hr>

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

            <!-- street address -->
            <div class="md-form mt-0">

    <asp:Label ID="lblStreetAddress" runat="server" Text="Street Address:" AssociatedControlID="txtStreetAddress"></asp:Label>
    <asp:TextBox ID="txtStreetAddress" runat="server" class="form-control"></asp:TextBox>
            
			</div>

            <!-- Street address line 2 -->
            <div class="md-form">

   <asp:Label ID="lblStreetAddressLn2" runat="server" Text="Street Address Line 2:" AssociatedControlID="txtStreetAddressLn2"></asp:Label>
    <asp:TextBox ID="txtStreetAddressLn2" runat="server" class="form-control"></asp:TextBox>

            
			</div>

            <!-- city -->
            <div class="md-form">

<asp:Label ID="lblCity" runat="server" Text="City:" AssociatedControlID="txtCity"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server" class="form-control"></asp:TextBox>


            </div>

            <!-- State -->
            <div class="form-check">
 
    <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="ddlState"></asp:Label>
 
<asp:DropDownList ID="ddlState" runat="server">

    <asp:ListItem Enabled="true" Value="">State</asp:ListItem>
	<asp:ListItem Value="AL">AL</asp:ListItem>
	<asp:ListItem Value="AK">AK</asp:ListItem>
	<asp:ListItem Value="AZ">AZ</asp:ListItem>
	<asp:ListItem Value="AR">AR</asp:ListItem>
	<asp:ListItem Value="CA">CA</asp:ListItem>
	<asp:ListItem Value="CO">CO</asp:ListItem>
	<asp:ListItem Value="CT">CT</asp:ListItem>
	<asp:ListItem Value="DC">DC</asp:ListItem>
	<asp:ListItem Value="DE">DE</asp:ListItem>
	<asp:ListItem Value="FL">FL</asp:ListItem>
	<asp:ListItem Value="GA">GA</asp:ListItem>
	<asp:ListItem Value="HI">HI</asp:ListItem>
	<asp:ListItem Value="ID">ID</asp:ListItem>
	<asp:ListItem Value="IL">IL</asp:ListItem>
	<asp:ListItem Value="IN">IN</asp:ListItem>
	<asp:ListItem Value="IA">IA</asp:ListItem>
	<asp:ListItem Value="KS">KS</asp:ListItem>
	<asp:ListItem Value="KY">KY</asp:ListItem>
	<asp:ListItem Value="LA">LA</asp:ListItem>
	<asp:ListItem Value="ME">ME</asp:ListItem>
	<asp:ListItem Value="MD">MD</asp:ListItem>
	<asp:ListItem Value="MA">MA</asp:ListItem>
	<asp:ListItem Value="MI">MI</asp:ListItem>
	<asp:ListItem Value="MN">MN</asp:ListItem>
	<asp:ListItem Value="MS">MS</asp:ListItem>
	<asp:ListItem Value="MO">MO</asp:ListItem>
	<asp:ListItem Value="MT">MT</asp:ListItem>
	<asp:ListItem Value="NE">NE</asp:ListItem>
	<asp:ListItem Value="NV">NV</asp:ListItem>
	<asp:ListItem Value="NH">NH</asp:ListItem>
	<asp:ListItem Value="NJ">NJ</asp:ListItem>
	<asp:ListItem Value="NM">NM</asp:ListItem>
	<asp:ListItem Value="NY">NY</asp:ListItem>
	<asp:ListItem Value="NC">NC</asp:ListItem>
	<asp:ListItem Value="ND">ND</asp:ListItem>
	<asp:ListItem Value="OH">OH</asp:ListItem>
	<asp:ListItem Value="OK">OK</asp:ListItem>
	<asp:ListItem Value="OR">OR</asp:ListItem>
	<asp:ListItem Value="PA">PA</asp:ListItem>
	<asp:ListItem Value="RI">RI</asp:ListItem>
	<asp:ListItem Value="SC">SC</asp:ListItem>
	<asp:ListItem Value="SD">SD</asp:ListItem>
	<asp:ListItem Value="TN">TN</asp:ListItem>
	<asp:ListItem Value="TX">TX</asp:ListItem>
	<asp:ListItem Value="UT">UT</asp:ListItem>
	<asp:ListItem Value="VT">VT</asp:ListItem>
	<asp:ListItem Value="VA">VA</asp:ListItem>
	<asp:ListItem Value="WA">WA</asp:ListItem>
	<asp:ListItem Value="WV">WV</asp:ListItem>
	<asp:ListItem Value="WI">WI</asp:ListItem>
	<asp:ListItem Value="WY">WY</asp:ListItem>
     
</asp:DropDownList>

            <!------ Zipcode------->

    <asp:Label ID="lblZipcode" runat="server" Text="Postal /Zip code:" AssociatedControlID="txtZipcode"></asp:Label>
    <asp:TextBox ID="txtZipcode" runat="server" class="form-control"></asp:TextBox>

       
	        </div>

            <!-------Age------->
            
    <asp:Label ID="lblAge" runat="server" Text="Age:" AssociatedControlID="txtAge"></asp:Label>
    <asp:TextBox ID="txtAge" runat="server" class="form-control"></asp:TextBox>
            
            <!-------Height------->
    
    <asp:Label ID="lblHeight" runat="server" Text="Height:" AssociatedControlID="txtHeight"></asp:Label>
    <asp:TextBox ID="txtHeight" runat="server" class="form-control"></asp:TextBox>
            
            <!-------Weight------->
            
    <asp:Label ID="lblWeight" runat="server" Text="Weight:" AssociatedControlID="txtWeight"></asp:Label>
    <asp:TextBox ID="txtWeight" runat="server" class="form-control"></asp:TextBox>
     
            <!-------Ocupation------->
    
    <asp:Label ID="lblOcupation" runat="server" Text="Ocupation:" AssociatedControlID="txtOcupation"></asp:Label>
    <asp:TextBox ID="txtOcupation" runat="server" class="form-control"></asp:TextBox>
     
            <!-------Interest------->
    
    <asp:Label ID="lblInterest" runat="server" Text="Interest:" AssociatedControlID="txtOcupation"></asp:Label>
    <asp:TextBox ID="txtInterest" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
     
            
            <!-------Likes and Dislikes------->

    <asp:Label ID="lblLikesDislikes" runat="server" Text="Likes & Dislikes:" AssociatedControlID="txtLikesDislikes"></asp:Label>
    <asp:TextBox ID="txtLikesDislikes" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
     
            <!-------Favorites------->

    <asp:Label ID="lblFavorites" runat="server" Text="Favorites:" AssociatedControlID="txtFavorites"></asp:Label>
    <asp:TextBox ID="txtFavorites" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
     

            <!-------Goals------->

    <asp:Label ID="lblGoals" runat="server" Text="Goals:" AssociatedControlID="txtGoals"></asp:Label>
    <asp:TextBox ID="txtGoals" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
     
            <!-------Commitment------------>

<asp:Label ID="lblCommitment" runat="server" Text="Commitment:" AssociatedControlID="rblCommitment"></asp:Label>
    
 <asp:RadioButtonList ID="rblCommitment" runat="server" RepeatDirection="Horizontal">
    
    <asp:ListItem Text="Unsure" Value="Unsure" />
    <asp:ListItem Text="Friends" Value="Friends" />
    <asp:ListItem Text="Relationship" Value="Relationship" />
    <asp:ListItem Text="Marriage" Value="Marriage" />

 </asp:RadioButtonList>

            <!-------Kids------>

    <asp:Label ID="lblKids" runat="server" Text="Have kids:" AssociatedControlID="rbKids"></asp:Label>

  <asp:RadioButtonList ID="rbKids" runat="server" RepeatDirection="Horizontal">
    
    <asp:ListItem Text="Yes" Value="Yes" />
    <asp:ListItem Text="No" Value="No" />

  </asp:RadioButtonList>


            <!-------WantKids----->

  <asp:Label ID="lblWantKids" runat="server" Text="Want kids:" AssociatedControlID="rbWantKids"></asp:Label>

  <asp:RadioButtonList ID="rbWantKids" runat="server" RepeatDirection="Horizontal">
    
    <asp:ListItem Text="Yes" Value="Yes" />
    <asp:ListItem Text="No" Value="No" />
    <asp:ListItem Text="Unsure" Value="Unsure" />
  
  </asp:RadioButtonList>


            <!-------Religion------->
<asp:Label ID="lblReligion" runat="server" Text="Religion:" AssociatedControlID="ddlReligion"></asp:Label>

 <asp:DropDownList ID="ddlReligion" runat="server">

     <asp:ListItem Enabled="true" Text="Select Religion" Value=""></asp:ListItem>
     <asp:ListItem Text="Non-religious" Value="Non-religious"></asp:ListItem>
     <asp:ListItem Text="Judaism" Value="Judaism"></asp:ListItem>
     <asp:ListItem Text="Islam" Value="Islam"></asp:ListItem>
     <asp:ListItem Text="Hinduism" Value="Hinduism"></asp:ListItem>
     <asp:ListItem Text="Christianity" Value="Christianity"></asp:ListItem>
     <asp:ListItem Text="Chinese traditional religion" Value="Chinese traditional religion"></asp:ListItem>
     <asp:ListItem Text="Buddhism" Value="Buddhism"></asp:ListItem>
     <asp:ListItem Text="Atheist" Value="Atheist"></asp:ListItem>
     <asp:ListItem Text="Agnostic" Value="Agnostic"></asp:ListItem>
     
</asp:DropDownList>

            <br>
            
            <br>
            <asp:Button ID="btnSudmit" runat="server" Text="Submit" OnClick="btnSudmit_Click" class="btn btn-success" /> <!--Submit button--->
            
            <br>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        
      	   </div>

       
        </form>
        <!-- Form -->

    </div>

</div>
<!-- Material form register -->

        </div>
            </form>
    </div>

    <div class="col-sm-2 sidenav">
    </div>
  </div>
</div>
    
<footer class="container-fluid text-center">
  <p>Footer Text</p>
</footer>



</asp:Content>
