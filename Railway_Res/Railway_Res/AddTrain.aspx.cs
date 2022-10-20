using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.Login;

namespace Railway_Res   
{
    public partial class AddTrain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");

            }

            User user = (User)Session["user"];
            if (user.UserType == 0)
            {
                Response.Redirect("HomePage.aspx");
            }
            AddTrainPanel.Visible = true;
            mesPanelAddTrain.Visible = false;
        }

        protected void addT_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {
                using (con)
                {
                    //List<ListItem> selected = new List<ListItem>();
                    //foreach (ListItem item in tSeats.Items)
                    //{
                    //    if (item.Selected)
                    //    {
                    //        //selected.Add(item);
                    //        //Response.Write(item);


                    //    }
                    //}
                    string query = "INSERT INTO Trains (tNumber, tName, tClass, tSeat, tASeat) VALUES(@tNum, @tName, @tClass, @tSeat, @tASeat)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        
                        cmd.Parameters.AddWithValue("@tNum", tNumber.Text);
                        cmd.Parameters.AddWithValue("@tName", tName.Text);
                        cmd.Parameters.AddWithValue("@tClass", tClasses.Text);
                        cmd.Parameters.AddWithValue("@tSeat", Page.Request.Form["tSeat"]);
                        cmd.Parameters.AddWithValue("@tASeat", Page.Request.Form["tSeat"]);

                        //Response.Write(Page.Request.Form["tSeat"]);

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    };
                    AddTrainPanel.Visible = false;
                    mesPanelAddTrain.Visible = true;
                }
            }
            catch(Exception exception)
            {
               Response.Write("Errors" + exception.Message);
            }

        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


    }
}