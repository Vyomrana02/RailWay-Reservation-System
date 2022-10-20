<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Railway_Res.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
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
                        <a class="nav-link" href="BookTicket.aspx">Book Ticket</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="MyTickets.aspx">My Tickets</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="ProfilePage.aspx">My Profile</a>
                    </li>

                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-3" value="Logout">Logout</a>
    </nav>
    <div class="container w-50 mt-5" style="margin-top: 90px!important;">
        <form runat="server">
            <asp:Panel ID="mesPanelUpdateProfile" runat="server">
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <asp:Label ID="lbErrorUpdateemp" runat="server">Profile Updated Successfully..</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <asp:Button Text="Homepage" class="btn btn-primary" runat="server" ID="Home" OnClick="Home_Click" />
            </asp:Panel>
            <asp:Panel ID="editProfilePanel" runat="server">
            <div class="mt-3">
                <div class="row">
                    <div class="col">
                        <label for="fName" class="form-label">First Name : </label>
                        <asp:TextBox class="form-control" ID="fName" runat="server" required="required"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="lName" class="form-label">Last Name : </label>
                        <asp:TextBox class="form-control" ID="lName" runat="server"  required="required"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="uName" class="form-label">User Name : </label>
                        <asp:TextBox class="form-control" ID="uName" runat="server"  required="required"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="email" class="form-label">Email : </label>
                        <asp:TextBox runat="server" ID="email" class="form-control"  required="required" type="email"/>
                    </div>
                    <div class="col">
                        <label for="dob" class="form-label">DOB : </label>
                        <asp:TextBox runat="server" ID="dob" class="form-control"  required="required"/>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="phone" class="form-label">Phone (+91) : </label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="phone" ErrorMessage="Phone number should only contain numbers and must have 10 digits" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        <asp:TextBox class="form-control" ID="phone" runat="server"  required="required"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="addr" class="form-label">Address : </label>
                        <asp:TextBox ID="addr" runat="server" class="form-control" cols="60" rows="4"  required="required"></asp:TextBox>
                    </div>
                </div>

            </div>
            

                <asp:Button type="submit" runat="server" class="btn btn-primary mt-3" Text="Update" ID="update" OnClick="update_Click"></asp:Button>
        </asp:Panel>
                </form>
    </div>

</body>
</html>
