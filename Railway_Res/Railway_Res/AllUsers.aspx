<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="Railway_Res.AllUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.bundle.js"></script>
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
                        <a class="nav-link" href="AddSchedule.aspx">Add Schedule</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AllTickets.aspx">All Tickets</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AllTrains.aspx">All Trains</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link active" href="AllUsers.aspx">All Users</a>
                    </li>

                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-4" value="Logout">Logout</a>
    </nav>

    <form id="form1" runat="server" class="mt-5" style="margin-top:90px!important">
        <div class="container">
            <asp:GridView ID="DisplayAllUsers" CssClass="my-4" AutoGenerateColumns="False" runat="server" CellPadding="10" HorizontalAlign="Center" Width="91%" ForeColor="#333333" BorderStyle="None" OnSelectedIndexChanged="DisplayAllUsers_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="uId" HeaderText="User Id" ReadOnly="True" />
                    <asp:BoundField DataField="uName" HeaderText="User Name" ReadOnly="True" />
                    <asp:BoundField DataField="fName" HeaderText="First Name" ReadOnly="True" />
                    <asp:BoundField DataField="lName" HeaderText="Last Name" ReadOnly="True" />
                    <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" />
                    <asp:BoundField DataField="dob" HeaderText="DOB" ReadOnly="True" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" ReadOnly="True" />
                    <asp:BoundField DataField="address" HeaderText="Address" ReadOnly="True" />
                    <asp:CommandField ControlStyle-CssClass="btn btn-danger" ItemStyle-HorizontalAlign="Center" ControlStyle-ForeColor="White" SelectText="Delete" ShowSelectButton="true">
                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
       </div>
    </form>
</body>
</html>
