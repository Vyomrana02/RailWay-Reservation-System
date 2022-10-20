using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.Login;
using static Railway_Res.MyTickets;

namespace Railway_Res
{
    public partial class AllTrains : System.Web.UI.Page
    {
        public class AllTicket : Ticket
        {
            public int uId { get;set;}
            public string uName { get; set; }

        }

        public List<AllTicket> allTickets = new List<AllTicket>();
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
                        if (((User)Session["user"]).UserType == 1)
                        {
                            string query = "SELECT * FROM Tickets INNER JOIN Trains ON Tickets.tId = Trains.Id INNER JOIN Users ON Tickets.uId = Users.Uid";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                con.Open();
                                SqlDataReader rd = cmd.ExecuteReader();
                                int id = 1;
                                while (rd.Read())
                                {
                                    AllTicket ticket = new AllTicket();
                                    ticket.Id = id;
                                    ticket.uId = Convert.ToInt32(rd["Uid"]);
                                    ticket.uName = Convert.ToString(rd["uName"]);
                                    ticket.tNumber = Convert.ToInt32(rd["tNumber"]);
                                    ticket.tName = Convert.ToString(rd["tName"]);
                                    ticket.tClass = Convert.ToString(rd["tClass"]);
                                    ticket.seats = Convert.ToInt32(rd["sSeats"]);
                                    ticket.src = Convert.ToString(rd["Source"]);
                                    ticket.dest = Convert.ToString(rd["Destination"]);
                                    ticket.date = Convert.ToString(rd["Date"]);
                                    ticket.depTime = Convert.ToString(rd["aTime"]);
                                    id++;
                                    allTickets.Add(ticket);
                                }
                                con.Close();
                                DisplayAllTickets.DataSource = allTickets;
                                DisplayAllTickets.DataBind();
                            };

                        }
                        else
                        {
                            string query = "SELECT * FROM Tickets, Trains, Users WHERE Tickets.tId = Trains.Id AND Users.UserType = @utype AND @uid = Tickets.uId";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                con.Open();
                                cmd.Parameters.AddWithValue("@utype", 0);
                                cmd.Parameters.AddWithValue("@uid", ((User)Session["user"]).Uid);
                                SqlDataReader rd = cmd.ExecuteReader();
                                int id = 1;
                                while (rd.Read())
                                {
                                    AllTicket ticket = new AllTicket();
                                    ticket.Id = id;
                                    ticket.uId = Convert.ToInt32(rd["Uid"]);
                                    ticket.uName = Convert.ToString(rd["uName"]);
                                    ticket.tNumber = Convert.ToInt32(rd["tNumber"]);
                                    ticket.tName = Convert.ToString(rd["tName"]);
                                    ticket.tClass = Convert.ToString(rd["tClass"]);
                                    ticket.seats = Convert.ToInt32(rd["sSeats"]);
                                    ticket.src = Convert.ToString(rd["Source"]);
                                    ticket.dest = Convert.ToString(rd["Destination"]);
                                    ticket.date = Convert.ToString(rd["Date"]);
                                    ticket.depTime = Convert.ToString(rd["aTime"]);
                                    id++;
                                    allTickets.Add(ticket);
                                }
                                con.Close();
                                DisplayAllTickets.DataSource = allTickets;
                                DisplayAllTickets.DataBind();
                            };
                        }
                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors is" + exception.Message);
                }
            }
        }
    }
}