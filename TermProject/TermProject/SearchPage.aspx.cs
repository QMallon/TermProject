﻿using System;
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
using System.Drawing;
using Utilities;
using System.Runtime.Serialization.Formatters.Binary;

namespace TermProject
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Validation val = new Validation();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
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
            



        }

        protected void btnFind_Click(object sender, EventArgs e)
        {

         
            
        }

        protected void btnSrcName_Click(object sender, EventArgs e)
        {
            if (txtSrcName.Text != "")
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
            else {

                lblSearchName.ForeColor = Color.Red;
                lblSearchName.Text = "Please type the name of the person:";

            }
        }

        protected void btnSrcByAge_Click(object sender, EventArgs e)
        {
            if (txtMinAge.Text != null || txtMaxAge.Text == null)
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
            else {

                lblMaxAge.ForeColor = Color.Red;
                lblMinAge.ForeColor = Color.Red;
                lblSearhByAge.ForeColor = Color.Red;
                lblSearhByAge.Text = "Please type the right age range.";

            }

        }
        
        protected void btnFindByLocation_Click(object sender, EventArgs e)
        {

            if (txtSrcCity.Text != "" || ddlSearchState.SelectedValue != "")
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
            else
            {

                lblSearchByCity.ForeColor = Color.Red;
                lblSearchByState.ForeColor = Color.Red;
                lblSearchByCity.Text = "You need to select a valid state and type a valid city.";
                
            }

        }

        protected void btnSrcOptions_Click(object sender, EventArgs e)

        {

            if (rbCommintment.SelectedValue == null || rbKids.SelectedValue == null || rbWantKids.Text == null)
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
            else {

                lblSearchWantKids.ForeColor = Color.Red;
                lblSearchByKids.ForeColor = Color.Red;
                lblSearchByCommitment.ForeColor = Color.Red;

                lblSearchByCommitment.Text = "Please check all the requirements. Commitment:";


            }


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

        

        protected void rpProfiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            int y = Convert.ToInt32((rpProfiles.Items[rowIndex].FindControl("ProfileID") as HiddenField).Value);
            string x = e.CommandName;
            if(x == "Like")
            {
                //lblTest.Text = "Like Happened";
                likeProfile(y);
            }
            else if (x == "Pass")
            {
                //lblTest.Text = "Pass Happened";
                PassProfile(y);
            }
            if (x == "ViewProfile")
            {
                Session["CurrentUserID"] = y;
                Response.Redirect("ProfileView.aspx");
                //lblTest.Text = "View Happened";
            }

            //lblTest.Text = x.ToString();
        }


        private void likeProfile(int ID)
        {
            //Add current profile to like
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_getLikes";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Likes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> likeList = (List<int>)deSerializer.Deserialize(memStream);

            likeList.Add(Convert.ToInt32(Session["CurrentUserID"]));

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, likeList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StoreLikes";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());
            objCommand.Parameters.AddWithValue("@Likes", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        private void PassProfile(int ID)
        {
            //Add current profile to dislike
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPass";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Passes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> passList = (List<int>)deSerializer.Deserialize(memStream);

            passList.Add(Convert.ToInt32(Session["CurrentUserID"]));

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, passList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StorePass";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());
            objCommand.Parameters.AddWithValue("@Pass", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }


    }


}