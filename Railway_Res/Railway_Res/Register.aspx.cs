using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Railway_Res
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userPanel.Visible = false;
        }

        protected void addT_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            bool flag2 = true;
            try
            {
                using (con)
                {
                    string query = "SELECT * FROM Users WHERE uName = @uname";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@uName", uName.Text);
                        SqlDataReader rd = cmd.ExecuteReader();
                        bool flag = false;
                       
                        while (rd.Read())
                        {
                            flag = true;
                        }

                        if (flag)
                        {
                            userPanel.Visible = true;
                            flag2 = false;
                        }
                        con.Close();
                    };

                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors is" + exception.Message);
            }

            if (flag2)
            {

                con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;

                try
                {
                    using (con)
                    {
                        string query = "INSERT INTO Users (fName, lName, uName, Password, Email, DOB, Phone, Address) VALUES(@fname, @lname, @uname, @password, @email, @dob, @phone, @addr)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@fname", fName.Text);
                            cmd.Parameters.AddWithValue("@lname", lName.Text);
                            cmd.Parameters.AddWithValue("@uname", uName.Text);
                            cmd.Parameters.AddWithValue("@password", Page.Request.Form["password"]);
                            cmd.Parameters.AddWithValue("@email", Page.Request.Form["email"]);
                            cmd.Parameters.AddWithValue("@dob", Page.Request.Form["dob"]);
                            cmd.Parameters.AddWithValue("@phone", phone.Text);
                            cmd.Parameters.AddWithValue("@addr", Page.Request.Form["addr"]);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("Login.aspx");
                        };

                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors" + exception.Message);
                }
            }
        }
        public void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}