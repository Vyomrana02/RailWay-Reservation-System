using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.Login;

namespace Railway_Res
{
    public partial class UpdateTrain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Request.Form["tNumber"] = "123";
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            User user = (User)Session["user"];
            if (user.UserType == 0)
            {
                Response.Redirect("HomePage.aspx");
            }

            UpdateTrainPanel.Visible = true;
            mesPanelUpdateTrain.Visible = false;
            if (!this.IsPostBack)
            {
                int tid = Convert.ToInt32(Request.Params["id"]);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT * FROM Trains WHERE Id = @tid";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@tid", tid);
                            SqlDataReader rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                tName.Text = Convert.ToString(rd["tName"]);
                                tNumber.Text = Convert.ToString(rd["tNumber"]);
                                tClasses.Text = Convert.ToString(rd["tClass"]);
                                tSeat.Text = Convert.ToString(rd["tSeat"]);
                            }
                            con.Close();
                            
                        };

                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors is" + exception.Message);
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(Request.Params["id"]);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "UPDATE Trains SET tName=@tname,tNumber=@tnum,tClass=@tclass,tSeat=@tseat WHERE Id=@tid";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        //Response.Write("3");
                        cmd.Connection = con;
                        con.Open();
                        //cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tname", Page.Request.Form["tName"]);
                        cmd.Parameters.AddWithValue("@tnum", Page.Request.Form["tNumber"]);
                        cmd.Parameters.AddWithValue("@tclass", Page.Request.Form["tClasses"]);
                        cmd.Parameters.AddWithValue("@tSeat", Page.Request.Form["tSeat"]);
                        cmd.Parameters.AddWithValue("@tid", tid);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        UpdateTrainPanel.Visible = false;
                        mesPanelUpdateTrain.Visible = true;
                        //Response.Redirect("ProfilePage.aspx");

                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }
        }

        public void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}