using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Railway_Res
{
    public partial class Login : System.Web.UI.Page
    {
        public class User
        {
            public int Uid;
            public string uName;
            public string password;
            public string fName;
            public string lName;
            public string email;
            public DateTime date;
            public long phone;
            public string address;
            public int UserType = 0;
            public User()
            {
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserType == 1)
                {
                    Response.Redirect("AddTrain.aspx");
                }
                else
                {
                    Response.Redirect("BookTicket.aspx");

                }
            }
            userPanel.Visible = false;

        }

        protected void login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            bool flag2 = true;
            
            try
            {
                using (con)
                {
                    string query = "SELECT * FROM Users WHERE uName = @uname AND Password=@psswd";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@uName", uName.Text);
                        cmd.Parameters.AddWithValue("@psswd", Page.Request["password"]);
                        SqlDataReader rd = cmd.ExecuteReader();
                        bool flag = false;

                        while (rd.Read())
                        {
                            flag = true;
                        }

                        if (!flag)
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
                        string query = "SELECT * FROM Users WHERE uName = @uname AND Password = @pass";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@uname", uName.Text);
                            cmd.Parameters.AddWithValue("@pass", Page.Request.Form["password"]);
                            SqlDataReader rd = cmd.ExecuteReader();
                            //while (rd.Read())
                            //{
                            //    String tName = Convert.ToString(rd["tName"]);
                            //    String id = Convert.ToString(rd["Id"]);
                            //    tSelect.Items.Add(new ListItem(tName, id));
                            //}
                            if (rd.Read())
                            {
                                User user = new User();
                                user.Uid = Convert.ToInt32(rd["Uid"]);
                                user.fName = Convert.ToString(rd["fName"]);
                                user.lName = Convert.ToString(rd["lName"]);
                                user.uName = Convert.ToString(rd["uName"]);
                                user.email = Convert.ToString(rd["Email"]);
                                user.password = Convert.ToString(rd["Password"]);
                                user.date = Convert.ToDateTime(rd["DOB"]);
                                user.phone = Convert.ToInt64(rd["Phone"]);
                                user.address = Convert.ToString(rd["Address"]);
                                user.UserType = Convert.ToInt32(rd["UserType"]);

                                Session["user"] = user;
                                Session["uname"] = user.uName;
                                Session["UserType"] = user.UserType;
                                //SqlDataReader rd1 = (SqlDataReader) Session["user"];
                                //Response.Write(((SqlDataReader)Session["user"])["uName"]);
                                //Response.Write((Session["user"])["uName"]);
                                //if (user.UserType == 1)
                                //{
                                //    Response.Redirect("AddTrain.aspx");
                                //}
                                //else
                                //{
                                //    Response.Redirect("BookTicket.aspx");
                                //}
                                Response.Redirect("HomePage.aspx");
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
        public void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}