<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Railway_Res.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body style="background: linear-gradient(to right, #a8ff78, #78ffd6); background-size: cover;">
    <div class="container w-50 mt-5">
        <form runat="server">
            <asp:Panel ID="userPanel" runat="server">
                <div class="alert alert-danger alert-dismissible fade show" role="alert">
                    <asp:Label ID="lbErrorUpdateemp" runat="server">Username is already taken...</asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            </asp:Panel>
            <div class="mt-3">
                <div class="row">
                    <div class="col">
                        <label for="fName" class="form-label">First Name : </label>
                        <asp:TextBox class="form-control" ID="fName" runat="server" required="required"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="lName" class="form-label">Last Name : </label>
                        <asp:TextBox class="form-control" ID="lName" runat="server" required="required"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="uName" class="form-label">User Name : </label>
                        <asp:TextBox class="form-control" ID="uName" runat="server" required="required"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="password" class="form-label">Password : 
                        </label>
                        <input runat="server" id="password" maxlength="6" minlength="6" class="form-control" type="password" required="required"/>
                    </div>
                   
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="email" class="form-label">Email : </label>
                        <input runat="server" id="email" class="form-control" type="email" required="required" />
                    </div>
                    <div class="col">
                        <label for="dob" class="form-label">DOB : </label>
                        <input runat="server" id="dob" class="form-control" type="date" required="required"/>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="phone" class="form-label">Phone (+91) : 
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="phone" ErrorMessage="Phone number should only contain numbers and must have 10 digits" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        </label>
                        <asp:TextBox class="form-control" ID="phone" runat="server" required="required"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="addr" class="form-label">Address : </label>
                        <textarea id="addr" runat="server" class="form-control" cols="60" rows="4" required="required"></textarea>
                    </div>
                </div>

            </div>
            

                <asp:Button type="submit" runat="server" class="btn btn-primary mt-3" Text="Register" ID="addT" OnClick="addT_Click"></asp:Button>
                <%--<asp:Button runat="server" class="btn btn-primary mt-3" Text="Login" ID="login" OnClick="login_Click"></asp:Button>--%>
                <a class="btn btn-primary mt-3" href="Login.aspx">Login</a>
        </form>
    </div>
</body>
</html>
