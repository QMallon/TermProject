<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="TermProject.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<div class="container-fluid text-center">    
     <div class="row content">
    <br>
    <div class="col-sm-2 sidenav">
    </div>
    
	<div class="col-sm-8 text-left"> 
        <form runat="server">
      
            <!-----------Modal----------->

 <!----------Name----------->
   <h3>Search by name:</h3>
   <div id="divSrcName" runat="server">

    <asp:Label ID="lblSearchName" runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="txtSrcName" runat="server"></asp:TextBox>
    
    <asp:Button ID="btnSrcName" class="btn btn-success" runat="server" Text="Find by name" OnClick="btnSrcName_Click" />
    </div>
 <button type="button" id="btnShowModal" style="float:right" class="btn btn-primary" data-toggle="modal" data-target="#searchModal">
  Search Profiles
</button>
   
            <!-- Button trigger modal -->

<!-- Modal -->
<div class="modal fade" id="searchModal" tabindex="-1" role="dialog" aria-labelledby="searchModal" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title" id="exampleModalLongTitle">Search for matchings</h2>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
            <div runat="server" id="divSearchFilter">

   
    <h3>Search by location:</h3>
    <div id="divSrcLocation" runat="server">
    <!----------City----------->
    

    <asp:Label ID="lblSearchByCity" runat="server" Text="City: "></asp:Label>
    <asp:TextBox ID="txtSrcCity" runat="server"></asp:TextBox>
    <br>
    <br>
    <!----------State----------->
    <asp:Label ID="lblSearchByState" runat="server" Text="State: "></asp:Label>
    <asp:DropDownList ID="ddlSearchState" runat="server">

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
    <br>
    <asp:Button ID="btnFindByLocation" class="btn btn-success" runat="server" Text="Find by location" OnClick="btnFindByLocation_Click" />
    </div>
    <hr>
    <!----------Age----------->
    <h3>Search by age:</h3>
    <div id="divSrcByAge" runat="server">

    <asp:Label ID="lblSearhByAge" runat="server" Text="Age: "></asp:Label>

    <br>

    <asp:Label ID="lblMinAge" runat="server" Text="Minimum Age: "></asp:Label>
    <asp:TextBox ID="txtMinAge" runat="server"> </asp:TextBox>

    <asp:Label ID="lblMaxAge" runat="server" Text="Maximum Age: "></asp:Label>
    <asp:TextBox ID="txtMaxAge" runat="server"></asp:TextBox>
    <asp:Button ID="btnSrcByAge" runat="server" class="btn btn-success" Text="Find by age" onclick="btnSrcByAge_Click"/>
    
    </div>
    <br>
    <!----------Commitment---------->
   <hr>
   <h3>Search by options:</h3>
    <div id="divSearchByOptions" runat="server">
  
    <br>
    <asp:Label ID="lblSearchByCommitment" runat="server" Text="Commitment: "></asp:Label>
    <br>
    
    <asp:RadioButtonList ID="rbCommintment" runat="server" RepeatDirection="Horizontal">

        <asp:ListItem Text="Unsure" Value="Unsure" />
        <asp:ListItem Text="Friends" Value="Friends" />
        <asp:ListItem Text="Relationship" Value="Relationship" />
        <asp:ListItem Text="Marriage" Value="Marriage" />

    </asp:RadioButtonList>


    <br>

    <!-----------Kids---------->

    <asp:Label ID="lblSearchByKids" runat="server" Text="Have kids: "></asp:Label>
    <br>
    <asp:RadioButtonList ID="rbKids" runat="server" RepeatDirection="Horizontal">

        <asp:ListItem Text="Yes" Value="Yes" />
        <asp:ListItem Text="No" Value="No" />

    </asp:RadioButtonList>

    <br>

    <!----------Want kids----------->


    <asp:Label ID="lblSearchWantKids" runat="server" Text="Want Kids: "></asp:Label>

    <asp:RadioButtonList ID="rbWantKids" runat="server" RepeatDirection="Horizontal">

        <asp:ListItem Text="Yes" Value="Yes" />
        <asp:ListItem Text="No" Value="No" />

    </asp:RadioButtonList>
    <br>
        
    <asp:Button ID="btnSrcOptions" class="btn btn-success" runat="server" Text="Find by options" onclick="btnSrcOptions_Click"/>
    
    </div>
    <!----------Religion----------->
    <hr>
    <h3>Search by Religion:</h3>

    <div id="divSrcByReligion" runat="server">
    
    <asp:Label ID="lblSearchByReligion" runat="server" Text="Religion: "></asp:Label>
    <br>

    <asp:DropDownList ID="ddlReligion" runat="server">
        
        <asp:ListItem Text="Non-religious" Value="Non-religious" />
        <asp:ListItem Text="Agnostic" Value="Agnostic" />
        <asp:ListItem Text="Atheist" Value="Atheist" />
        <asp:ListItem Text="Buddhism" Value="Buddhism" />
         
        <asp:ListItem Text="Christianity" Value="Christianity" />
        <asp:ListItem Text="Hinduism" Value="Hinduism" />
        <asp:ListItem Text="Islam" Value="Islam" />
        <asp:ListItem Text="Judaism" Value="Judaism" />

    </asp:DropDownList>
    
        <asp:Button ID="btnFindByReligion" class="btn btn-success" runat="server" Text="Find by Religion" OnClick="btnFindByReligion_Click"/>
    
    </div>
  
   
    <br>
    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<!-----------/Modal-------------->
    <br>
            <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
    <hr>
    <br>

    <div class="row">

        <asp:Repeater ID="rpProfiles" runat="server" OnItemCommand="rpProfiles_ItemCommand">

               <ItemTemplate>
               
                    <div class="col-lg-3 col-md-3 col-sm-3">
                            <br>
                            <div class="card " style="text-align:center;background-color:lightgray;border-radius: 5px;height:300px;width:280px">
                                <br>
                                <asp:Image style=" margin: auto;width: 50%; border: 3px solid white;  padding: 10px;" ID="imgRpt" runat="server" ImageUrl='<%#Eval("Userimage")%>' Width="160px" Height="160px" ></asp:Image>
                                
                                <div class="card-header" >
                            
                                <asp:Label ID="lblFirstName" class="" runat="server" style="text-align:center;font-weight:bold; font-size:20px" Text='<%#Eval("Firstname")%>'></asp:Label>
                                <br>
                                    
                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                            <asp:HiddenField ID="ProfileID" runat="server" Value='<%# Eval("ProfileId") %>' />
                                </div>
                            
                               <div class="card-body" style="text-align: center">
                                
                               <p class="card-text "> <asp:Label ID="lblFovorite" runat="server" Text='<%#Eval("Favorites")%>'></asp:Label> </p>
                            
                                </div>
                            
                                <div class="card-footer" style="text-align: center">
                            
                                <asp:Button class="btn btn-success"  UseSubmitBehavior="false" ID="btnRptLike" runat="server" Text="Like" CommandName="Like" />
                                
                                <asp:Button class="btn btn-danger" UseSubmitBehavior="false" ID="btnRptDislike" runat="server" Text="Not Like" CommandName="Pass" />

                                <asp:Button class="btn btn-info" UseSubmitBehavior="false" ID="btnRptViewProfile" runat="server" Text="View Profile" CommandName="ViewProfile" />
                                
                                <br>
                                

                                </div>
                        
                        </div>

                    </div>
           
                    </ItemTemplate>
    </asp:Repeater>
    </div>
            <br>
        </form>

    </div>
	
    <div class="col-sm-2 sidenav">
      
    </div>
  </div>
</div>

<footer class="container-fluid text-center">
  <p>Where you find your partner.</p>
</footer>

</asp:Content>
