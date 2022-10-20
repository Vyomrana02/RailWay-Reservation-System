<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="Railway_Res.AddSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body style="background: linear-gradient(to right, #a8ff78, #78ffd6); background-size: cover;">
    <nav class="navbar navbar-expand-lg fixed-top bg-dark navbar-dark">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">Welcome <%=Session["uname"] %></a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-center order-2" id="navbarSupportedContent">
                <ul class="navbar-nav navbar-center me-auto navbar-center text-center mb-2 mb-lg-0" style="position: absolute; left: 50%; transform: translatex(-50%);">
                    <li class="nav-item">
                        <a class="nav-link" aria-current="page" href="HomePage.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AddTrain.aspx">Add Train</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="AddSchedule.aspx">Add Schedule</a>
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

                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-4" value="Logout">Logout</a>
    </nav>

    <form id="form1" runat="server" class="mt-5" style="margin-top: 90px!important;">
        <div class="container w-50">
            <asp:Panel ID="mesPanelAddSchedule" runat="server">
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <asp:Label ID="lbErrorUpdateemp" runat="server">Schedule Added Successfully..</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <asp:Button Text="Homepage" class="btn btn-primary" runat="server" ID="Home" OnClick="Home_Click" />
            </asp:Panel>
        <asp:Panel ID="AddSchedulePanel" runat="server">
        </div>
        <div class="container w-50 mt-5">
            <label for="tSchedule" class="form-label">Time :</label>
            <input id="tSchedule" class="form-control" type="time" runat="server" required="required"/>
            <label for="tSource" class="form-label mt-3">Source :</label>
            <asp:TextBox ID="tSource" class="form-control" runat="server" required="required"></asp:TextBox>
            <label for="tDest" class="form-label mt-3">Destination :</label>
            <asp:TextBox ID="tDest" class="form-control" runat="server" required="required"></asp:TextBox>

            <label for="tSelect" class="form-label mt-3">Trains :</label>
            <asp:DropDownList  class="form-select" ID="tSelect" runat="server" required="required">
                <asp:ListItem Selected="True" Value="0">--Select</asp:ListItem>
            </asp:DropDownList>

            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tSelect" CssClass="mt-2" ErrorMessage="Please select the train" ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
            <br />

            <asp:Button type="submit" runat="server" class="btn btn-primary mt-3" Text="Add Schedule" ID="addSchedule" OnClick="addSchedule_Click"></asp:Button>
        </div>
                </asp:Panel>
    </form>
</body>
</html>
