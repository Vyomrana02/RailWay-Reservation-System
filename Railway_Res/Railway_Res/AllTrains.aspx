<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllTrains.aspx.cs" Inherits="Railway_Res.AllTrains1" %>

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
                        <a class="nav-link active" href="AllTrains.aspx">All Trains</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AllUsers.aspx">All Users</a>
                    </li>

                </ul>
            </div>
        </div>
        <a id="logout" href="logout.aspx" class="btn btn-outline-success mr-4" value="Logout">Logout</a>
    </nav>

    <form id="form1" runat="server" class="mt-5" style="margin-top: 90px!important">

        <div class="container w-50">
            <asp:Panel ID="mesPanelResetTrain" runat="server">
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <asp:Label ID="lbErrorUpdateemp" runat="server">Train reseted Successfully..</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            </asp:Panel>
        </div>

        <div class="container">
            <asp:GridView ID="DisplayAllTrains" CssClass="my-4" AutoGenerateColumns="False" runat="server" CellPadding="4" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="DisplayAllTrains_SelectedIndexChanged" ForeColor="#333333" GridLines="None" OnRowUpdating="DisplayAllTrains_RowUpdating">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="tId" HeaderText="Train Id" ReadOnly="True" />
                    <asp:BoundField DataField="Train_Number" HeaderText="Train Number" ReadOnly="True" />
                    <asp:BoundField DataField="Train_Name" HeaderText="Train Name" ReadOnly="True" />
                    <asp:BoundField DataField="Train_Class" HeaderText="Class" ReadOnly="True" />
                    <asp:BoundField DataField="seats" HeaderText="Total Seats" ReadOnly="True" />
                    <%--<asp:CommandField ControlStyle-CssClass="btn btn-primary" ItemStyle-HorizontalAlign="Center" ControlStyle-ForeColor="White" SelectText="Update" ShowSelectButton="true">
                        <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:CommandField>--%>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:Button ID="update" CssClass="btn btn-primary" OnClick="update_Click" CommandArgument='<%# Bind("tid") %>' runat="server" CausesValidation="false" Text="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reset">
                        <ItemTemplate>
                            <asp:Button ID="reset" CssClass="btn btn-secondary" OnClick="reset_Click" CommandArgument='<%# Bind("tid") %>' runat="server" CausesValidation="false" Text="Reset" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ControlStyle-CssClass="btn btn-danger" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ControlStyle-ForeColor="White" SelectText="Delete" ShowSelectButton="true">
                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
