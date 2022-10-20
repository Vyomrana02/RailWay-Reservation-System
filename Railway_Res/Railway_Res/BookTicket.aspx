<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookTicket.aspx.cs" Inherits="Railway_Res.BookTicket" %>

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
                        <a class="nav-link active" href="BookTicket.aspx">Book Ticket</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="MyTickets.aspx">My Tickets</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ProfilePage.aspx">My Profile</a>
                    </li>

                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-4" value="Logout">Logout</a>
    </nav>

    <form id="form1" class="mt-5" runat="server" style="margin-top: 80px!important;">
        <asp:Panel ID="mesPanelBookTicket" runat="server">
            <div class="container w-50">
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <asp:Label ID="lbErrorUpdateemp" runat="server">Ticket Booked Successfully..</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <asp:Button Text="My Tickets" class="btn btn-primary mt-3" runat="server" ID="Book" OnClick="BookTicket_Click" />
            </div>
        </asp:Panel>
        <asp:Panel ID="BookTicketPanel" runat="server">


            <asp:Panel ID="error" runat="server">
                <div class="container">
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        <strong>Holy guacamole!</strong> You should check in on some of those fields below.
                  <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                </div>
            </asp:Panel>

            <%--<form id="form1" runat="server">--%>
            <div class="container w-50">

                <div class="row">
                    <div class="col">
                        <label for="tSrc" class="form-label mt-3">Source :</label>
                        <asp:DropDownList class="form-select" aria-label="Default select example" ID="tSrc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tSrc_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                            <%--<asp:ListItem Selected="True" Value="0"><asp:TextBox runat="server"></asp:TextBox></asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tSrc" CssClass="p-2" ForeColor="Red" ErrorMessage="Select Source"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <label for="tDest" class="form-label mt-3">Destination :</label>
                        <asp:DropDownList class="form-select" aria-label="Default select example" ID="tDest" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tDest_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tdest" ErrorMessage="Select Destination" CssClass="p-2" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="tSeat" class="form-label">No Of Seats :</label>
                        <%--<input id="tSeat" class="form-control" type="number" runat="server" />--%>
                        <asp:TextBox ID="tSeat" class="form-control" type="number" AutoPostBack="true" runat="server" OnTextChanged="tSeat_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tSeat" ErrorMessage="Enter Seats" CssClass="p-2" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <label for="tDate" class="form-label">Date :</label>
                        <input id="tDate" class="form-control" type="Date" runat="server" onchange="input_change" />
                    </div>
                </div>

                <%--<asp:Panel ID="addPassenger" class="form-label ml-3 mt-4 w-100" runat="server" Visible="true"></asp:Panel>--%>
                <asp:PlaceHolder runat="server" ID="TextBoxPlaceHolder" />
                <br />

                <asp:GridView ID="DisplayList" CssClass="my-4" AutoGenerateColumns="False" runat="server" CellPadding="4" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="DisplayList_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" />
                        <asp:BoundField DataField="Train_Number" HeaderText="Train Number" ReadOnly="True" />
                        <asp:BoundField DataField="Train_Name" HeaderText="Train Name" ReadOnly="True" />
                        <asp:BoundField DataField="Train_Class" HeaderText="Class" ReadOnly="True" />
                        <%--<asp:BoundField DataField="Code" HeaderText="Seats" ReadOnly="True" />--%>
                        <asp:BoundField DataField="Seat_available" HeaderText="Available Seats" ReadOnly="True" />
                        <%--<asp:BoundField DataField="Code" HeaderText="sId" ReadOnly="True" />--%>
                        <asp:BoundField DataField="Arrival_time" HeaderText="Arrival Time" ReadOnly="True" />
                        <%--<input runat="server" type="button" text="Select" ShowSelectButton="true" />--%>
                        <asp:CommandField ControlStyle-CssClass="btn btn-success" ItemStyle-HorizontalAlign="Center" ControlStyle-ForeColor="White" SelectText="Select" ShowSelectButton="true">
                            <ControlStyle CssClass="btn btn-success"></ControlStyle>
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
                <%--<div class="row my-3">
                <div class="col-5"></div>
                <div class="col-2">
                    <asp:Button type="submit" runat="server" class="btn btn-primary w-100" Text="Book" ID="book" OnClick="book_Click"></asp:Button>
                </div>
                <div class="col-5"></div>
            </div>--%>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
