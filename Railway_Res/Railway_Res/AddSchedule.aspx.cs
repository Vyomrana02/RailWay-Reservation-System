using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.Login;

namespace Railway_Res
{
    public partial class AddSchedule : System.Web.UI.Page
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
            mesPanelAddSchedule.Visible = false;
            AddSchedulePanel.Visible = true;

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            //try
            //{
            //    using (con)
            //    {
            //        string query = "SELECT * FROM Trains";
            //        using (SqlCommand cmd = new SqlCommand(query))
            //        {
            //            cmd.Connection = con;
            //            con.Open();
            //            SqlDataReader rd = cmd.ExecuteReader();
            //            Trains = new List<Train>();
            //            while (rd.Read())
            //            {
            //                Train tr = new Train();
            //                tr.id = Convert.ToInt32(rd["id"]);
            //                tr.tName = Convert.ToString(rd["tName"]);
            //                tr.tNumber = Convert.ToString(rd["tNumber"]);
            //                Trains.Add(tr);
            //            }
            //            //this.DataBind();
            //            con.Close();
            //        };

            //    }
            //}
            //catch (Exception exception)
            //{
            //    Response.Write("Erro rs" + exception.Message);
            //}
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
                            while (rd.Read())
                            {
                                String tName = Convert.ToString(rd["tName"]);
                                String id = Convert.ToString(rd["Id"]);
                                tSelect.Items.Add(new ListItem(tName, id));
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
        protected void Add_srcDest(int tid)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "INSERT INTO DestSrc (Source,Destination,Tid) VALUES(@Src,@Dest,@tid)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        Response.Write("1");
                        cmd.Parameters.AddWithValue("@Src", tSource.Text);
                        cmd.Parameters.AddWithValue("@Dest", tDest.Text);
                        cmd.Parameters.AddWithValue("@tid", tid);

                        //Response.Write(Page.Request.Form["tSeat"]);

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }
        }
        protected void inserttrain(int Sid)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "UPDATE Trains SET Sid = @Sid WHERE id = @Tid";
                    using (SqlCommand cmd3 = new SqlCommand(query))
                    {
                        Response.Write("3");
                        cmd3.Connection = con;
                        con.Open();
                        //cmd3.Connection = con;
                        cmd3.Parameters.AddWithValue("@Sid", Sid);
                        cmd3.Parameters.AddWithValue("@Tid", tSelect.SelectedItem.Value);
                        Response.Write(tSelect.SelectedItem.Value);
                        Response.Write(Sid);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                        Add_srcDest(Convert.ToInt32(tSelect.SelectedItem.Value));
                        mesPanelAddSchedule.Visible = true;
                        AddSchedulePanel.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }
        }

        protected void takeMaxSid()
        {
            int Sid = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {
                using (con)
                {
                    string query;
                    query = "SELECT MAX(Sid) FROM Schedule";
                    using (SqlCommand cmd2 = new SqlCommand(query))
                    {
                        Response.Write("2");
                        cmd2.Connection = con;
                        con.Open();
                        //cmd2.Connection = con;
                        SqlDataReader rd = cmd2.ExecuteReader();
                        while (rd.Read())
                        {
                        //Sid = rd["Sid"];
                        Sid = Convert.ToInt32(rd.GetValue(0));
                            Response.Write("BCSs1  " + Sid);
                        }

                        //rd.Close();

                        //Response.
                        //con.Close();
                        inserttrain(Sid);
                    }


                }

            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }
        }
            protected void addSchedule_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {
                using (con)
                {
                    string query;
                    query = "INSERT INTO Schedule (aTime) VALUES(@aTime)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        Response.Write("1");
                        cmd.Parameters.AddWithValue("@aTime", Page.Request.Form["tSchedule"]);

                        //Response.Write(Page.Request.Form["tSeat"]);

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //con.Close();
                    };

                }
                takeMaxSid();
                //con.Open();
                
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