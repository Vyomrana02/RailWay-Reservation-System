<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Railway_Res.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body style="background: linear-gradient(to right, #a8ff78, #78ffd6); background-size: cover;">
    <div class="container w-25 mt-5">
        <form runat="server">

            <asp:Panel ID="userPanel" runat="server">
                <div class="alert alert-danger alert-dismissible fade show" role="alert">
                    <asp:Label ID="passwordCheckemp" runat="server">UserName or Password is InCorrect...</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            </asp:Panel>
            <div class="mt-3">

                <label for="uName" class="form-label">User Name : </label>
                <asp:TextBox class="form-control" ID="uName" runat="server" required="required"></asp:TextBox>

                <br />

                <label for="password" class="form-label">Password : </label>
                <input runat="server" id="password" class="form-control" type="password" required="required"/>

            </div>


            <asp:Button type="submit" runat="server" class="btn btn-primary mt-3" Text="Login" ID="login" OnClick="login_Click"></asp:Button>
        <asp:Button runat="server" class="btn btn-primary mt-3" Text="Register" ID="Register" OnClick="Register_Click"></asp:Button>
        </form>
    </div>
</body>
</html>
