using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.Login;
using static Railway_Res.AllTrains;
using System.Reflection;

namespace Railway_Res
{
    public partial class AllUsers : System.Web.UI.Page
    {
        public class User1
        {
            public int id { get; set; }

            public int uId { get; set; }
            public string uName { get; set; }

            public string email { get; set; }
            public string dob { get; set; }


            public string fName { get; set; }
            public string lName { get; set; }

            public long phone { get; set; }
            public string address { get; set; }

        }

        public List<User1> users = new List<User1>();
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

            if (!this.IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT * FROM Users WHERE UserType = @utype";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@utype", 0);
                            SqlDataReader rd = cmd.ExecuteReader();
                            int id = 1;
                            while (rd.Read())
                            {
                                User1 user1 = new User1();
                                user1.id = id;
                                user1.uId = Convert.ToInt32(rd["Uid"]);
                                user1.dob = Convert.ToString(rd["DOB"]);
                                user1.uName = Convert.ToString(rd["uName"]);
                                user1.email = Convert.ToString(rd["Email"]);
                                user1.fName = Convert.ToString(rd["fName"]);
                                user1.lName = Convert.ToString(rd["lName"]);
                                user1.phone = Convert.ToInt64(rd["Phone"]);
                                user1.address = Convert.ToString(rd["Address"]);
                                id++;
                                users.Add(user1);
                            }
                            con.Close();
                            DisplayAllUsers.DataSource = users;
                            DisplayAllUsers.DataBind();
                        };

                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors is" + exception.Message);
                }
            }
        }
        protected void DisplayAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Write(DisplayAllUsers.SelectedRow.Cells[1].Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "DELETE FROM Users WHERE Uid = @uid";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        //Response.Write("3");
                        cmd.Connection = con;
                        con.Open();
                        //cmd.Connection = con
                        cmd.Parameters.AddWithValue("@uid", DisplayAllUsers.SelectedRow.Cells[1].Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("AllUsers.aspx");
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