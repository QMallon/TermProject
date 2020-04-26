using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization; //Json serialization
using System.IO; // Stream reader and Stream
using System.Net; // Web Request 
using System.Data.SqlClient;
using Utilities;

namespace TermProject
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Validation val = new Validation();
        

        protected void Page_Load(object sender, EventArgs e)
        {

            WebRequest request = WebRequest.Create("https://localhost:44345/api/profile"); //webrequest for the api localhost
        
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Profile[] profile = js.Deserialize<Profile[]>(data);

            rpProfiles.DataSource = profile;
            rpProfiles.DataBind();
         
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {

         
            
        }

        protected void btnSrcName_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://localhost:44337/api/Search/GetProfilesByName/" + txtSrcName.Text); //webrequest for the api localhost

            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Profile[] profile = js.Deserialize<Profile[]>(data);

            rpProfiles.DataSource = profile;
            rpProfiles.DataBind();

        }

        protected void btnSrcByAge_Click(object sender, EventArgs e)
        {

            WebRequest request = WebRequest.Create("https://localhost:44337/api/Search/GetProfilesByAge/" + txtMinAge.Text + "/" + txtMaxAge.Text); //webrequest for the api localhost

            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Profile[] profile = js.Deserialize<Profile[]>(data);

            rpProfiles.DataSource = profile;
            rpProfiles.DataBind();

        }
        
        protected void btnFindByLocation_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://localhost:44337/api/Search/GetProfilesByLocation/" + txtSrcCity.Text + "/" + ddlSearchState.SelectedValue); //webrequest for the api localhost



            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Profile[] profile = js.Deserialize<Profile[]>(data);

            rpProfiles.DataSource = profile;
            rpProfiles.DataBind();
        }

        protected void btnSrcOptions_Click(object sender, EventArgs e)

        {

            WebRequest request = WebRequest.Create("https://localhost:44337/api/Search/GetProfilesByOptions/" +
              rbCommintment.SelectedValue + "/" + rbKids.SelectedValue + "/" + rbWantKids.SelectedValue + "/"); //webrequest for the api localhost

            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Profile[] profile = js.Deserialize<Profile[]>(data);

            rpProfiles.DataSource = profile;
            rpProfiles.DataBind();


        }

        protected void btnFindByReligion_Click(object sender, EventArgs e)
        {

            WebRequest request = WebRequest.Create("https://localhost:44337/api/Search/GetProfilesByReligion/" + ddlReligion.SelectedValue); //webrequest for the api localhost

            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Profile[] profile = js.Deserialize<Profile[]>(data);

            rpProfiles.DataSource = profile;
            rpProfiles.DataBind();
            
        }

        protected void btnWipetables_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "sp_WipeSQLtables";

            objDB.DoUpdateUsingCmdObj(objCommand);

        }

        

    }


}