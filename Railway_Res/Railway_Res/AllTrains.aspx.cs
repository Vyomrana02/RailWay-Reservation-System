using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.AllUsers;
using static Railway_Res.Login;

namespace Railway_Res
{
    public partial class AllTrains1 : System.Web.UI.Page
    {
        public class Train
        {
            public int id { get; set; }

            public int tId { get; set; }
            public int Train_Number { get; set; }

            public string Train_Name { get; set; }
            public string Train_Class { get; set; }


            public int seats { get; set; }
            
        }

        public List<Train> trains = new List<Train>();
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


            mesPanelResetTrain.Visible = false;
            if (!this.IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT * FROM Trains";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader rd = cmd.ExecuteReader();
                            int id = 1;
                            while (rd.Read())
                            {
                                Train train = new Train();
                                train.id = id;
                                train.tId = Convert.ToInt32(rd["Id"]);
                                train.Train_Number = Convert.ToInt32(rd["tNumber"]);
                                train.Train_Name = Convert.ToString(rd["tName"]);
                                train.Train_Class = Convert.ToString(rd["tClass"]);
                                train.seats = Convert.ToInt32(rd["tSeat"]);
                               // train.Arrival_time = Convert.ToString(rd["aTime"]);
                                id++;
                                trains.Add(train);
                            }
                            con.Close();
                            DisplayAllTrains.DataSource = trains;
                            DisplayAllTrains.DataBind();
                        };

                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors is" + exception.Message);
                }
            }
        }

        protected void DisplayAllTrains_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "DELETE FROM Trains WHERE Id = @tid";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        //Response.Write("3");
                        cmd.Connection = con;
                        con.Open();
                        //cmd.Connection = con
                        cmd.Parameters.AddWithValue("@tid", DisplayAllTrains.SelectedRow.Cells[1].Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("AllTrains.aspx");
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }
        }

        protected void DisplayAllTrains_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Write("updating");
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tid = btn.CommandArgument.ToString();
            Response.Write(tid);
            Response.Redirect($"UpdateTrain.aspx?id={tid}");
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tid = btn.CommandArgument.ToString();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "UPDATE Trains SET tASeat = (SELECT tSeat FROM Trains WHERE id = @ttid) WHERE id = @Tid";
                    using (SqlCommand cmd3 = new SqlCommand(query))
                    {
                        cmd3.Connection = con;
                        con.Open();
                        cmd3.Parameters.AddWithValue("@ttid", tid);
                        cmd3.Parameters.AddWithValue("@Tid", tid);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                        mesPanelResetTrain.Visible = true;
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }
        }
    }
}