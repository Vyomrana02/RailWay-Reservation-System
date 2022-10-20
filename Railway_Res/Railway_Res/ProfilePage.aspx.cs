using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.Login;

namespace Railway_Res
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");

            }
            User user = (User)Session["user"];
            if (user.UserType == 1)
            {
                Response.Redirect("HomePage.aspx");
            }
            mesPanelUpdateProfile.Visible = false;
            editProfilePanel.Visible = true;
            //User user = (User)Session["user"];
            fName.Text = Convert.ToString(user.fName); 
            lName.Text = user.lName;    
            uName.Text = user.uName;
            email.Text = user.email;
            string s = (user.date).ToString("dd/MM/yyyy");
            dob.Text = s;
            //Response.Write(dob.Text + Convert.ToString(user.date));
               
            phone.Text = Convert.ToString(user.phone);
            addr.Text = Convert.ToString(user.address);



        }

        protected void update_Click(object sender, EventArgs e)
        {
            //Response.Write("click");
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {

                using (con)
                {

                    string query = "UPDATE Users SET fName=@fName,lname=@lName,uName=@uName,Email=@Email,DOB=@DOB,Phone=@Phone,Address=@Address WHERE Uid=@uId";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        //Response.Write("3");
                        cmd.Connection = con;
                        con.Open();
                        //cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@fName", Page.Request.Form["fName"]);
                        cmd.Parameters.AddWithValue("@lName", Page.Request.Form["lName"]);
                        cmd.Parameters.AddWithValue("@uName", Page.Request.Form["uName"]);
                        cmd.Parameters.AddWithValue("@Email", Page.Request.Form["email"]);
                        //Convert.ToDateTime(dob.Text)
                        cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(Page.Request.Form["dob"]));
                        cmd.Parameters.AddWithValue("@Phone", Page.Request.Form["phone"]);
                        cmd.Parameters.AddWithValue("@Address", Page.Request.Form["addr"]);
                        cmd.Parameters.AddWithValue("@uId", ((User)Session["user"]).Uid);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        //Response.Write(fName.Text + lName.Text + uName.Text + email.Text + Convert.ToDateTime(dob.Text) + phone.Text + addr.Text + ((User)Session["user"]).Uid);

                        User user = (User)Session["user"];
                        user.fName = Page.Request.Form["fName"];
                        user.lName = Page.Request.Form["lName"];
                        user.uName = Page.Request.Form["uName"];
                        user.email = Page.Request.Form["email"];
                        //string s = (user.date).ToString("dd/MM/yyyy");
                        user.date = Convert.ToDateTime(Page.Request.Form["dob"]);
                        //Response.Write(dob.Text + Convert.ToString(user.date));

                        user.phone = Convert.ToInt64(Page.Request.Form["phone"]);
                        user.address = Page.Request.Form["addr"];
                        mesPanelUpdateProfile.Visible = true;
                        editProfilePanel.Visible = false;

//                        Response.Redirect("ProfilePage.aspx");

                    }
                    
                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors " + exception.Message);
            }

        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}