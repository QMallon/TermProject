<%@ Page Title="" Language="C#" MasterPageFile="~/TermProject.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="TermProject.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

    <div runat="server" id="divSearchFilter">
    <!----------Username----------->

    <asp:Label ID="lblSearchByUsername" runat="server" Text="Username: "></asp:Label>
    <asp:TextBox ID="txtSrchUsername" runat="server"></asp:TextBox>

    <br>

    <!----------Name----------->

    <asp:Label ID="lblSearchName" runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="txtSrcName" runat="server"></asp:TextBox>

    <br>

    <!----------City----------->

    <asp:Label ID="lblSearchByCity" runat="server" Text="City: "></asp:Label>
    <asp:TextBox ID="txtSrcCity" runat="server"></asp:TextBox>

    <br>

    <!----------State----------->

    <asp:Label ID="lblSeachByState" runat="server" Text="State: "></asp:Label>

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

    <!----------Age----------->


    <asp:Label ID="lblSearhByAge" runat="server" Text="Age: "></asp:Label>

    <br>

    <asp:Label ID="lblMinAge" runat="server" Text="Minimum Age: "></asp:Label>
    <asp:TextBox ID="txtMinAge" Text="0" runat="server"> </asp:TextBox>

    <asp:Label ID="lblMaxAge" runat="server" Text="Maximum Age: "></asp:Label>
    <asp:TextBox ID="txtMaxAge" Text="100" runat="server"></asp:TextBox>

    <!----------Commitment---------->

    <br>
    <asp:Label ID="lblSearchByCommitment" runat="server" Text="Commitment: "></asp:Label>
    
    <asp:CheckBox ID="cbCommintmentUnsure" Text="Unsure" runat="server" />
    <asp:CheckBox ID="cbCommintmentFriends" Text="Friends" runat="server" />
    <asp:CheckBox ID="cbCommintmentRelationship" Text="Relationship" runat="server" />
    <asp:CheckBox ID="cbCommintmentMarriage" Text="Marriage" runat="server" />
    <br>

    <!----------Weight----------->
    
    <asp:Label ID="lblSearchByWeight" runat="server" Text="Weight: "></asp:Label>
    <br>
    <asp:Label ID="lblMinWeight" runat="server" Text="Minimum Weight: "></asp:Label>
    <asp:TextBox ID="txtMinWeight" Text="0" runat="server"> </asp:TextBox>

    <asp:Label ID="lblMaxWeight" runat="server" Text="Maximum Weight: "></asp:Label>
    <asp:TextBox ID="txtMaxWeight" Text="100" runat="server"></asp:TextBox>

    <br>

    <!----------Height----------->
    <asp:Label ID="lblSearchByHeight" runat="server" Text="Height: "></asp:Label>
    
    <br>

    <asp:Label ID="lblMinHeight" runat="server" Text="Minimum Height: "></asp:Label>
    <asp:TextBox ID="txtMinHeight" Text="0" runat="server"> </asp:TextBox>

    <asp:Label ID="lblMaxHeight" runat="server" Text="Maximum Height: "></asp:Label>
    <asp:TextBox ID="txtMaxHeight" Text="100" runat="server"></asp:TextBox>


    <!----------Religion----------->

    <asp:Label ID="lblSearchByReligion" runat="server" Text="Religion: "></asp:Label>
    <br>

    <asp:CheckBox ID="cbReligionNonReligious" runat="server" Text="Non-religious" />
    <asp:CheckBox ID="cbReligionJudaism" Text="Judaism" runat="server" />
    <br>
    <asp:CheckBox ID="cbReligionIslam" Text="Islam" runat="server" />
    <asp:CheckBox ID="cbReligionHinduism" Text="Hinduism" runat="server" />
    <br>
    <asp:CheckBox ID="cbReligionChristianity" Text="Christianity" runat="server" />
    <asp:CheckBox ID="cbReligionChinesetraditionalreligion" Text="Chinese traditional religion" runat="server" />
    <br>
    <asp:CheckBox ID="cbReligionBuddhism" Text="Buddhism" runat="server" />
    <asp:CheckBox ID="cbReligionAtheist" Text="Atheist" runat="server" />
    <br>
    <asp:CheckBox ID="cbReligionAgnostic" Text="Agnostic" runat="server" />
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

        <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
    <br>
    </div>

    <hr>

    <asp:Repeater ID="rpProfiles" runat="server">

               <ItemTemplate>
               
                    <div class="col-lg-8 col-md-2 col-sm-4">

                            <div class="card " style="text-align:center;background-color:lightgray;border-radius: 5px;">

                                <br>
                                <asp:Image style=" margin: auto;width: 50%; border: 3px solid white;  padding: 10px;" ID="imgRpt" runat="server" ImageUrl='<%#Eval("Userimage")%>' Width="160px" Height="160px" ></asp:Image>
                                
                                <div class="card-header" >
                            
                                <asp:Label ID="lblFirstName"  runat="server" Text='<%#Eval("Firstname")%>'></asp:Label>
                                <br>

                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                            
                                </div>
                            
                               <div class="card-body" style="text-align: center">
                                
                               <p class="card-text "> <asp:Label ID="lblFovorite" runat="server" Text='<%#Eval("Favorites")%>'></asp:Label> </p>
                            
                                </div>
                            
                                <div class="card-footer" style="text-align: center">
                            
                                <asp:Button class="btn btn-success" ID="btnRptLike" runat="server" Text="Like" />
                                
                                <asp:Button class="btn btn-danger" ID="btnRptDislike" runat="server" Text="Not Like" />
                                
                                </div>
                        
                        </div>
                    </div>
            <br>
                    </ItemTemplate>
        
    </asp:Repeater>

</asp:Content>
