using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using static Railway_Res.Login;

namespace Railway_Res
{

    public partial class BookTicket : System.Web.UI.Page
    {
        public class Passenger
        {
            public string pName { get; set; }
            public string pAge { get; set; }

        }
        public class Train
        {
            public int Id { get; set; }
            public int Train_Number { get; set; }
            public string Train_Name { get; set; }
            public string Train_Class { get; set; }
            public int Seat_available { get; set; }
            public string Arrival_time { get; set; }
            //public RadioButton Book { get; set; }

        }

        public class TicketPDF
        {
            public Train train { get; set; }

            public List<Passenger> passengers { get; set; }
            public string src { get; set; }
            public string dest { get; set; }
            public int seats { get; set; }
            public string date { get; set; }

        }

        public TicketPDF ticketpdf = new TicketPDF();
        public List<Train> Trains = new List<Train>();
        public Train train = new Train();
        public List<String> src = new List<String>();
        public List<String> dest = new List<String>();

        protected void panelerror(bool flag)
        {
            if (!flag) { error.Visible = false; }
            else { error.Visible = true; }
        }

        private List<string> TextBoxIdCollection
        {
            get
            {
                var collection = ViewState["TextBoxIdCollection"] as List<string>;
                return collection ?? new List<string>();
            }
            set { ViewState["TextBoxIdCollection"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");

            }

            User user = (User)Session["user"];
            string uname = user.uName;
            if (user.UserType == 1)
            {
                Response.Redirect("HomePage.aspx");
            }
            BookTicketPanel.Visible = true;
            mesPanelBookTicket.Visible = false;
            DateTime dNow = DateTime.Now;

            tDate.Value = dNow.ToString("yyyy-MM-dd");
            
            var i = 0;
            foreach (string textboxId in TextBoxIdCollection)
            {
                var textbox = new TextBox { ID = textboxId };
                textbox.CssClass = "form-control mt-3 col-6";
                if (i % 2 == 0)
                {
                    textbox.Attributes.Add("placeholder", "Passenger " + (i + 1) + " Name");
                }
                else
                {
                    textbox.Attributes.Add("placeholder", "Passenger " + (i + 1) + " Age");
                    textbox.Attributes.Add("type", "number");
                }
                TextBoxPlaceHolder.Controls.Add(textbox);
                i++;

                //textbox = new TextBox { ID = textboxId };
                //textbox.CssClass = "form-control";
                //TextBoxPlaceHolder.Controls.Add(textbox);
            }

            //addPassenger.Visible = false;
            panelerror(false);

            if (!this.IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT * FROM DestSrc";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                String tDestination = Convert.ToString(rd["Destination"]);
                                String tSource = Convert.ToString(rd["Source"]);
                                //int id = Convert.ToInt32(rd["id"]);
                                src.Add(tSource);
                                dest.Add(tDestination);
                                //tSrc.Items.Add(tSource);
                                //tDest.Items.Add(tDestination);
                            }
                            var unique_items = new HashSet<string>(src);
                            foreach (string s in unique_items)
                            {
                                tSrc.Items.Add(s);
                            }

                            unique_items = new HashSet<string>(dest);
                            foreach (string s in unique_items)
                            {
                                tDest.Items.Add(s);
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

        public void SendMail(string from, string to, string password)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    User user = (User)Session["user"];
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"<br />");
                    sb.Append($"<h1>Hello {user.uName} Thanks for booking.</h1>");
                    sb.Append($"<br>");
                    sb.Append($"<h3><b>Source : </b>{ticketpdf.src}</h3>");
                    sb.Append($"<br />");
                    sb.Append($"<h3><b>Destination : </b>{ticketpdf.dest}</h3>");
                    sb.Append($"<br />");
                    sb.Append($"<h3><b>Total Seats : </b>{ticketpdf.seats}</h3>");
                    sb.Append($"<br>");
                    sb.Append($"<div style='padding: 60px;'>");
                    sb.Append($"<table border=1>");
                    sb.Append($"<tr>");
                    sb.Append($"<td><b>Name</b></td>");
                    sb.Append($"<td><b>Age</b></td>");
                    sb.Append($"</tr>");
                    foreach (Passenger pas in ticketpdf.passengers)
                    {
                        sb.Append($"<tr>");
                        sb.Append($"<td>{pas.pName}</td>");
                        sb.Append($"<td>{pas.pAge}</td>");
                        sb.Append($"</tr>");
                    }

                    sb.Append($"</table>");
                    sb.Append($"</div>");
                    sb.Append($"<br />");
                    sb.Append($"<br />");
                    sb.Append($"<div style='padding: 60px;'>");
                    sb.Append($"<table border=1>");
                    sb.Append($"<thead>");
                    sb.Append($"<tr>");
                    sb.Append($"<td><b>Train Number</b></td>");
                    sb.Append($"<td><b>Train Name</b></td>");
                    sb.Append($"<td><b>Train Class</b></td>");
                    sb.Append($"<td><b>Departure Time</b></td>");
                    sb.Append($"</tr>");
                    sb.Append($"</thead>");
                    sb.Append($"<tbody>");
                    sb.Append($"<tr>");
                    sb.Append($"<td>{ticketpdf.train.Train_Number}</td>");
                    sb.Append($"<td>{ticketpdf.train.Train_Name}</td>");
                    sb.Append($"<td>{ticketpdf.train.Train_Class}</td>");
                    sb.Append($"<td>{ticketpdf.train.Arrival_time}</td>");
                    sb.Append($"</tr>");
                    sb.Append($"</tbody>");
                    sb.Append($"</table>");
                    sb.Append($"</div>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        MailMessage mm = new MailMessage(new MailAddress(from, "Railway Project"), new MailAddress(to, user.uName));
                        mm.Subject = "Railway Reservation";
                        mm.Body = "Thanks <h2>" + user.uName + "</h2> for boking the ticket";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Ticket.pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = from;
                        NetworkCred.Password = password;
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
        

            //User user = (User)Session["user"];
            //MailMessage mail = new MailMessage(new MailAddress(from, "Railway Project"), new MailAddress(to, user.uName));
            //mail.Subject = "Railway Reservation";
            //mail.Body = "Thanks <h2>" + user.uName + "</h2> for boking the ticket";
            //mail.IsBodyHtml = true;

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = ConfigurationManager.AppSettings["SMTP"];
            //smtp.EnableSsl = true;
            //NetworkCredential NetworkCred = new NetworkCredential(from, password);
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = NetworkCred;
            //smtp.Port = 587;
            //smtp.Send(mail);
            //Response.Write("mail sent");
        }

        //protected void logout_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Response.Redirect("Login.aspx");
        //}

        protected void tSrc_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {
                using (con)
                {
                    string query;

                    if (tDest.SelectedIndex == 0)
                    {
                        query = "SELECT * FROM Trains inner join Schedule on Trains.Sid = Schedule.Sid WHERE TRAINS.Id IN (SELECT Tid FROM DestSrc WHERE DestSrc.Source = @src)";
                    }
                    else
                    {
                        Trains.Clear();
                        query = "SELECT * FROM Trains inner join Schedule on Trains.Sid = Schedule.Sid WHERE TRAINS.Id IN (SELECT Tid FROM DestSrc WHERE DestSrc.Source = @src AND DestSrc.Destination = @dest)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        if (tDest.SelectedIndex != 0)
                            cmd.Parameters.AddWithValue("@Dest", tDest.Text);

                        cmd.Parameters.AddWithValue("@src", tSrc.Text);


                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            Train t = new Train();
                            t.Id = Convert.ToInt32(rd["Id"]);
                            t.Train_Number = Convert.ToInt32(rd["tNumber"]);
                            t.Train_Name = Convert.ToString(rd["tName"]);
                            t.Train_Class = Convert.ToString(rd["tClass"]);
                            t.Seat_available = Convert.ToInt32(rd["tASeat"]);
                            t.Arrival_time = Convert.ToString(rd["aTime"]);
                            //t.Book = new Button();
                            //Button btn = new Button();
                            //btn.Text = "Approve";
                            //btn.ID = "Approve";
                            //btn.Visible = true;

                            //t.Book = btn;



                            Trains.Add(t);

                        }


                        DisplayList.DataSource = Trains;
                        DisplayList.DataBind();
                        con.Close();
                    };

                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors is" + exception.Message);
            }
        }

        protected void tDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
            try
            {
                using (con)
                {
                    string query;https://localhost:44371/BookTicket.aspx.cs

                    if (tSrc.SelectedIndex == 0)
                    {
                        query = "SELECT * FROM Trains inner join Schedule on Trains.Sid = Schedule.Sid WHERE TRAINS.Id IN (SELECT Tid FROM DestSrc WHERE DestSrc.Destination = @dest)";
                    }
                    else
                    {
                        Trains.Clear();

                        query = "SELECT * FROM Trains inner join Schedule on Trains.Sid = Schedule.Sid WHERE TRAINS.Id IN (SELECT Tid FROM DestSrc WHERE DestSrc.Source = @src AND DestSrc.Destination = @dest)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        if (tSrc.SelectedIndex != 0)
                            cmd.Parameters.AddWithValue("@src", tSrc.Text);

                        cmd.Parameters.AddWithValue("@dest", tDest.Text);


                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            Train t = new Train();
                            t.Id = Convert.ToInt32(rd["Id"]);
                            t.Train_Number = Convert.ToInt32(rd["tNumber"]);
                            t.Train_Name = Convert.ToString(rd["tName"]);
                            t.Train_Class = Convert.ToString(rd["tClass"]);
                            t.Seat_available = Convert.ToInt32(rd["tASeat"]);
                            t.Arrival_time = Convert.ToString(rd["aTime"]);

                            Trains.Add(t);
                        }
                        DisplayList.DataSource = Trains;
                        DisplayList.DataBind();

                        con.Close();
                    };

                }
            }
            catch (Exception exception)
            {
                Response.Write("Errors is" + exception.Message);
            }
        }

        protected void DisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            User user = (User)Session["user"];
            int uid = user.Uid;
            int id = Convert.ToInt32(DisplayList.SelectedRow.Cells[0].Text);
            string Source = tSrc.Text;
            string Destination = tDest.Text;
            int sSeats = Convert.ToInt32(Page.Request.Form["tSeat"]);
            int aSeats = Convert.ToInt32(DisplayList.SelectedRow.Cells[4].Text);
            string aTime = Convert.ToString(DisplayList.SelectedRow.Cells[5].Text);
            string date = Convert.ToString(Page.Request.Form["tDate"]);
            //Response.Write(id + aTime);
            if (sSeats > aSeats)
            {
                //alert.Attributes("Class", "d-flex");
                //error.Visible = true;
                panelerror(true);
            }
            else
            {
                ticketpdf.src = Source;
                ticketpdf.dest = Destination;
                ticketpdf.seats = sSeats;
                train.Arrival_time = Convert.ToString(DisplayList.SelectedRow.Cells[5].Text);
                // ticketpdf.train.Arrival_time = Convert.ToString(DisplayList.SelectedRow.Cells[5].Text);
                ticketpdf.date = date;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                try
                {

                    using (con)
                    {

                        string query = "UPDATE Trains SET tASeat = @tAseats WHERE id = @Tid";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            //Response.Write("3");
                            cmd.Connection = con;
                            con.Open();
                            //cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tAseats", aSeats - sSeats);
                            cmd.Parameters.AddWithValue("@Tid", id);

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors " + exception.Message);
                }

                try
                {
                    con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                    using (con)
                    {
                        string query;
                        query = "SELECT * FROM Trains WHERE Id = @tid";
                        using (SqlCommand cmd2 = new SqlCommand(query))
                        {
                            cmd2.Connection = con;
                            con.Open();
                            cmd2.Parameters.AddWithValue("@tId", id);
                            SqlDataReader rd = cmd2.ExecuteReader();
                            while (rd.Read())
                            {
                                train.Train_Name = Convert.ToString(rd["tName"]);
                                train.Train_Number = Convert.ToInt32(rd["tNumber"]);
                                train.Train_Class = Convert.ToString(rd["tClass"]);
                                //ticketpdf.train.Train_Name = Convert.ToString(rd["tName"]);
                                //ticketpdf.train.Train_Number = Convert.ToInt32(rd["tNumber"]);
                                //ticketpdf.train.Train_Class = Convert.ToString(rd["tClass"]);
                            }

                        }


                    }

                }
                catch (Exception exception)
                {
                    Response.Write("Errors " + exception.Message);
                }

                try
                {
                    con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                    using (con)
                    {
                        string query = "INSERT INTO Tickets (uId, tId, Source, Destination, sSeats, Date, aTime, bDateTime) VALUES(@uId, @tId, @Source, @Destination, @sSeats, @Date, @aTime, @bDateTime)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            //cmd.Parameters.AddWithValue("@uId", uid);
                            //cmd.Parameters.AddWithValue("@tId", id);
                            //cmd.Parameters.AddWithValue("@Source", src);
                            //cmd.Parameters.AddWithValue("@Destination", dest);
                            //cmd.Parameters.AddWithValue("@sSeats", sSeats);
                            //cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@aTime", aTime);
                            //cmd.Parameters.AddWithValue("@bDateTime", now);

                            cmd.Parameters.AddWithValue("@uId", user.Uid);
                            cmd.Parameters.AddWithValue("@tId", Convert.ToInt32(DisplayList.SelectedRow.Cells[0].Text));
                            cmd.Parameters.AddWithValue("@Source", tSrc.Text);
                            cmd.Parameters.AddWithValue("@Destination", tDest.Text);
                            cmd.Parameters.AddWithValue("@sSeats", Convert.ToInt32(Page.Request.Form["tSeat"]));
                            cmd.Parameters.AddWithValue("@Date", Convert.ToString(Page.Request.Form["tDate"]));
                           // cmd.Parameters.AddWithValue("@aTime", Convert.ToString(DisplayList.SelectedRow.Cells[5].Text));
                            cmd.Parameters.AddWithValue("@bDateTime", Convert.ToDateTime(DateTime.Now));


                            
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        };

                    }
                }
                catch (Exception exception)
                {
                    Response.Write("Errors" + exception.Message);
                }
                int ticketID = 0;
                try
                {
                    con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                    using (con)
                    {
                        string query;
                        query = "SELECT MAX(Id) FROM Tickets";
                        using (SqlCommand cmd2 = new SqlCommand(query))
                        {
                            cmd2.Connection = con;
                            con.Open();
                            SqlDataReader rd = cmd2.ExecuteReader();
                            while (rd.Read())
                            {
                                ticketID = Convert.ToInt32(rd.GetValue(0));
                            }

                        }


                    }

                }
                catch (Exception exception)
                {
                    Response.Write("Errors " + exception.Message);
                }

                //Response.Write(ticketID);

                string pname = "";
                int page, i = 0;
                List<Passenger> passes = new List<Passenger>();
                foreach (Control ctr in TextBoxPlaceHolder.Controls)
                {
                    Passenger pas = new Passenger();
                    if (ctr is TextBox)
                    {
                        string value = ((TextBox)ctr).Text;
                        if (i % 2 == 0)
                        {
                            pname = value;
                            
                        }
                        else
                        {
                            page = Convert.ToInt32(value);
                            //Response.Write(page);

                            try
                            {
                                con = new SqlConnection();
                                con.ConnectionString = ConfigurationManager.ConnectionStrings["RailwayCon"].ConnectionString;
                                using (con)
                                {
                                    string query = "INSERT INTO Passenger (ticketId, Name, Age) VALUES(@tId, @name, @age)";
                                    using (SqlCommand cmd = new SqlCommand(query))
                                    {
                                        //Response.Write(pname + page);
                                        cmd.Parameters.AddWithValue("@tId", ticketID);
                                        cmd.Parameters.AddWithValue("@name", pname);
                                        cmd.Parameters.AddWithValue("@age", page);

                                        cmd.Connection = con;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();

                                        pas.pName = pname;
                                        pas.pAge = Convert.ToString(page);
                                    };

                                }
                            }
                            catch (Exception exception)
                            {
                                Response.Write("Errors" + exception.Message);
                            }
                        }
                        i++;
                        passes.Add(pas);
                        
                    }
                }

                ticketpdf.passengers = passes;
                ticketpdf.train = train;
                SendMail("dduprojects12@gmail.com", user.email, "titkoeapyppzfjuv");
                BookTicketPanel.Visible = false;
                mesPanelBookTicket.Visible = true;

            }

            }
            protected void tSeat_TextChanged(object sender, EventArgs e)
            {
                //Response.Write("change");
                //addPassenger.Visible = true;
                //int seats = Convert.ToInt32(tSeat.Text);
                //for(int i = 0; i < seats; i++)
                //{
                //    Panel p = new Panel();
                //    p.ID = "panel" + i;
                //    p.CssClass = "form-control my-3 row";
                //    p.Visible = true;

                //    TextBox t = new TextBox();
                //    t.ID = "pname" + i;
                //    t.CssClass = "form-control my-3 col";
                //    t.Attributes.Add("placeholder", "passenger " + (i+1) + " Name");
                //    //t.AutoPostBack = true;
                //    addPassenger.Visible = true;

                //    TextBox age = new TextBox();
                //    age.Attributes.Add("type", "number");
                //    age.ID = "page" + i;
                //    age.CssClass = "form-control my-3 col";
                //    //age.AutoPostBack = true;
                //    age.Attributes.Add("placeholder", "passenger " + (i + 1) + " Age");

                //    addPassenger.Controls.Add(p);
                //    p.Controls.Add(t);
                //    p.Controls.Add(age);
                //}

                var collection = new List<string>();
                int total;
                if (Int32.TryParse(tSeat.Text, out total))
                {
                    for (int i = 1; i <= total; i++)
                    {
                        var textbox = new TextBox { ID = "pName" + i };
                        textbox.CssClass = "form-control mt-3";
                        textbox.Attributes.Add("placeholder", "Passenger " + i + " Name");

                        // Collect this textbox id
                        collection.Add(textbox.ID);
                        TextBoxPlaceHolder.Controls.Add(textbox);

                        textbox = new TextBox { ID = "pAge" + i };
                        textbox.CssClass = "form-control mt-3 col-6";
                        textbox.Attributes.Add("placeholder", "Passenger " + i + " Age");
                        textbox.Attributes.Add("type", "number");
                        TextBoxPlaceHolder.Controls.Add(textbox);
                        collection.Add(textbox.ID);
                    }
                    TextBoxIdCollection = collection;
                }
        }
        protected void BookTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTickets.aspx");
        }
    }
}