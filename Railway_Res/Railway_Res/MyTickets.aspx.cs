using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Railway_Res.BookTicket;
using static Railway_Res.Login;

namespace Railway_Res
{
    public partial class MyTickets : System.Web.UI.Page
    {
        public class Ticket
        {
            public int Id { get; set; }
            public int tNumber { get; set; }
            public string tName { get; set; }
            public string tClass { get; set; }

            public string src { get; set; }
            public string dest { get; set; }
            public int seats { get; set; }
            public string date { get; set; }
            public string depTime { get; set; }

        }

        public List<Ticket> tickets = new List<Ticket>();
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

            if (!this.IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT * FROM Tickets INNER JOIN Trains ON Tickets.tId = Trains.Id WHERE Tickets.uId = @uid";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@uid", ((User)Session["user"]).Uid);
                            SqlDataReader rd = cmd.ExecuteReader();
                            int id = 1;
                            while (rd.Read())
                            {
                               Ticket ticket = new Ticket();
                                ticket.Id = id;
                                ticket.tNumber = Convert.ToInt32(rd["tNumber"]);
                                ticket.tName = Convert.ToString(rd["tName"]);
                                ticket.tClass = Convert.ToString(rd["tClass"]);
                                ticket.seats = Convert.ToInt32(rd["sSeats"]);
                                ticket.src = Convert.ToString(rd["Source"]);
                                ticket.dest = Convert.ToString(rd["Destination"]);
                                ticket.date = Convert.ToString(rd["Date"]);
                                ticket.depTime = Convert.ToString(rd["aTime"]);
                                id++;

                                tickets.Add(ticket);
                            }
                            con.Close();
                            DisplayTrains.DataSource = tickets;
                            DisplayTrains.DataBind();
                        };

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