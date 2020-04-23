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


            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;


            objCommand.CommandText = "TP_sp_SearchFiltering";

            objCommand.Parameters.AddWithValue("@FirstName", txtSrcName.Text);
            /*  objCommand.Parameters.AddWithValue("@LastName", txtSrcName.Text);
              objCommand.Parameters.AddWithValue("@City", txtSrcCity.Text);
              objCommand.Parameters.AddWithValue("@State", ddlSearchState.SelectedValue);


              objCommand.Parameters.AddWithValue("@minAge", int.Parse(txtMinAge.Text));
              objCommand.Parameters.AddWithValue("@maxAge", int.Parse(txtMaxAge.Text))


              objCommand.Parameters.AddWithValue("@minWeight", decimal.Parse(txtMinWeight.Text));
              objCommand.Parameters.AddWithValue("@maxWeight", decimal.Parse(txtMaxWeight.Text));

              objCommand.Parameters.AddWithValue("@minHeight", decimal.Parse(txtMinHeight.Text));
              objCommand.Parameters.AddWithValue("@@maxHeight", decimal.Parse(txtMaxHeight.Text));

              objCommand.Parameters.AddWithValue("@Religion", cbReligionBuddhism.Text);
              */


            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            rpProfiles.DataSource = ds;
            rpProfiles.DataBind();



        }




    }
}