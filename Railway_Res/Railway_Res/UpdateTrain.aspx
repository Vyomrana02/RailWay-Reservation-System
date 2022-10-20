<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTrain.aspx.cs" Inherits="Railway_Res.UpdateTrain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body>

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
                        <a class="nav-link active" href="MyTickets.aspx">My Tickets</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ProfilePage.aspx">My Profile</a>
                    </li>

                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-3" value="Logout">Logout</a>
    </nav>
    <div class="container w-50 mt-5">
        <form runat="server">
            <asp:Panel ID="mesPanelUpdateTrain" runat="server">
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <asp:Label ID="lbErrorUpdateemp" runat="server">Train Updated Successfully..</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <asp:Button Text="Homepage" class="btn btn-primary" runat="server" ID="Home" OnClick="Home_Click" />
            </asp:Panel>
            <asp:Panel ID="UpdateTrainPanel" runat="server">
            <div class="mb-3">
                <label for="tNumber" class="form-label">Train Number</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tNumber" ErrorMessage="train number cant contain characters and should be of length 5" ForeColor="Red" ValidationExpression="[0-9]{5}"></asp:RegularExpressionValidator>
                <%--<input type="text" class="form-control" ID="tNumber" aria-describedby="tNumber">--%>

                <asp:TextBox class="form-control" ID="tNumber" runat="server"  required="required"></asp:TextBox>

            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Train Name</label>
                <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
                <asp:TextBox class="form-control" ID="tName" required="required" runat="server"></asp:TextBox>
            </div>
            <label for="tClasses" class="form-label">Classes</label>

            <asp:DropDownList class="form-select" aria-label="Default select example" ID="tClasses" runat="server">
                <asp:ListItem  Value="0">--Select--</asp:ListItem>
                <asp:ListItem >AC First Class</asp:ListItem>
                <asp:ListItem>Ac 2 Tier</asp:ListItem>
                <asp:ListItem>AC 3 Tier</asp:ListItem>
                <asp:ListItem>Sleeper</asp:ListItem>
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tClasses" ErrorMessage="Please select the train class" ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
            <br />

            <label for="tSeat" class="form-label mt-3">Seats</label>
            <asp:TextBox ID="tSeat" class="form-control" type="number" required="required" runat="server"></asp:TextBox>
            <%--<input id="tSeat" class="form-control" type="number" runat="server"/>--%>

                <asp:Button type="submit" runat="server" class="btn btn-primary mt-3" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click"></asp:Button>
                </asp:Panel>
        </form>
    </div>

</body>
</html>
