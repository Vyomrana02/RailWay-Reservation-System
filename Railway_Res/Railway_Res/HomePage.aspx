<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Railway_Res.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>

    <style>
        .card{
            background-color : antiquewhite;
        }
    </style>

</head>
<body style="background: url('https://wallpapercave.com/wp/wp4822676.jpg'); background-size: cover; background-repeat: no-repeat;">
    <nav class="navbar navbar-expand-lg fixed-top bg-dark navbar-dark">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">Welcome <%=Session["uname"] %></a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-center order-2" id="navbarSupportedContent">
                <ul class="navbar-nav navbar-center me-auto navbar-center text-center mb-2 mb-lg-0" style="position: absolute; left: 50%; transform: translatex(-50%);">

                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="HomePage.aspx">Home</a>
                    </li>
                    <%if (Convert.ToInt32(Session["UserType"]) == 0) { %>
                    <%--<button class="btn btn-primary mt-5">Simple User</button>--%>
                    <li class="nav-item">
                        <a class="nav-link" href="BookTicket.aspx">Book Ticket</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="MyTickets.aspx">My Tickets</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ProfilePage.aspx">My Profile</a>
                    </li>
                    <% }%>
                    <%else
                    {%>
                    <li class="nav-item">
                        <a class="nav-link" href="AddTrain.aspx">Add Train</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AddSchedule.aspx">Add Schedule</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AllTickets.aspx">All Tickets</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AllTrains.aspx">All Trains</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AllUsers.aspx">All Users</a>
                    </li>

                    <% }%>
                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-4" value="Logout">Logout</a>
    </nav>
    <form id="form1" runat="server">

        <div class="mt-5" style="margin-top: 100px!important">
            <%if (Convert.ToInt32(Session["UserType"]) == 0)
                { %>
            <%--<button class="btn btn-primary mt-5">Simple User</button>--%>

            <div class="container">
                <div class="row">
                    <div class="col">
                         <a href="BookTicket.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://media.gettyimages.com/vectors/old-steam-train-vector-id472388307?s=2048x2048" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">Schedule Your Journey..</h5>
                                        <p class="card-text">Book Tickets for your next trip.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                             </a>
                    </div>
                    <div class="col">
                         <a href="MyTickets.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://img.freepik.com/free-vector/printing-invoices-concept-illustration_114360-1750.jpg?w=740&t=st=1664685353~exp=1664685953~hmac=9400d6c26382a1f1b9437e525833d022c4647ee643ed35430d9028d21e3e901d" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">My Tickets</h5>
                                        <p class="card-text">See your all previous tickets.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                             </a>
                    </div>
                    <div class="col">
                         <a href="ProfilePage.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://i.pinimg.com/736x/8b/16/7a/8b167af653c2399dd93b952a48740620.jpg" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">My Profile</h5>
                                        <p class="card-text">Manage your profile here.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                             </a>
                    </div>
                </div>
            </div>

            <% }%>
            <%else
            {%>
            
             <div class="container">
                <div class="row">
                    <div class="col">
                        <a href="AddTrain.aspx"style="text-decoration: none!important; color: black">
                            <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://media.gettyimages.com/vectors/old-steam-train-vector-id472388307?s=2048x2048" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">Add Train..</h5>
                                        <p class="card-text">Add new trains for the passengers.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </a>
                    </div>
                    <div class="col">
                        <a href="AddSchedule.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://img.freepik.com/free-vector/schedule-concept-illustration_114360-1531.jpg?w=740&t=st=1664685901~exp=1664686501~hmac=de4dd5a5d4018f983ec6d933467db6854e14c7c5626bcb27049af764d674030c" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">Add Schedule..</h5>
                                        <p class="card-text">Add schedule for the trains.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </a>
                    </div>
                    <div class="col">
                        <a href="AllTickets.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://img.freepik.com/free-vector/printing-invoices-concept-illustration_114360-1750.jpg?w=740&t=st=1664685353~exp=1664685953~hmac=9400d6c26382a1f1b9437e525833d022c4647ee643ed35430d9028d21e3e901d" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">All Tickets</h5>
                                        <p class="card-text">Manage all tickets booked by the passengers.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </a>
                    </div>
                </div>
                 <div class="row mt-5">
                     <div class="col-2"></div>
                    <div class="col-4">
                        <a href="AllTrains.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://img.freepik.com/free-vector/pack-great-trains-flat-design_23-2147620625.jpg?w=740&t=st=1664686262~exp=1664686862~hmac=de1a17b81adcdd2879edecd19ba2b06cbf23c04f1a029d51d27fccd7edfc4a6c" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">All Trains..</h5>
                                        <p class="card-text">Manage all trains added by you.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </a>
                    </div>
                    <div class="col-4">
                        <a href="AllUsers.aspx"style="text-decoration: none!important; color: black">
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row">
                                <div class="col">
                                    <img src="https://img.freepik.com/free-vector/follow-me-social-business-theme-design_24877-50426.jpg?w=740&t=st=1664686367~exp=1664686967~hmac=d6866f9a7905a64ac636dd04d2e7f2dca6fc7ad99995ee89e733e5559bd9e6e1" class="img-fluid rounded-start" alt="..." />
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">All Users..</h5>
                                        <p class="card-text">Manage all users present on your system.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </a>
                    </div>
                     <div class="col-2"></div>
                </div>
            </div>

            <% }%>
        </div>
    </form>
</body>
</html>
