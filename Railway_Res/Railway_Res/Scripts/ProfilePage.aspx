<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Railway_Res.Scripts.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="container w-50 mt-5">
        <form runat="server">
            <div class="mt-3">
                <div class="row">
                    <div class="col">
                        <label for="fName" class="form-label">First Name : </label>
                        <asp:TextBox class="form-control" ID="fName" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="lName" class="form-label">Last Name : </label>
                        <asp:TextBox class="form-control" ID="lName" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="uName" class="form-label">User Name : </label>
                        <asp:TextBox class="form-control" ID="uName" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="password" class="form-label">Password : </label>
                        <input runat="server" id="password" class="form-control" type="password" />
                    </div>
                   
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="email" class="form-label">Email : </label>
                        <input runat="server" id="email" class="form-control" type="email" />
                    </div>
                    <div class="col">
                        <label for="dob" class="form-label">DOB : </label>
                        <input runat="server" id="dob" class="form-control" type="date" />
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="phone" class="form-label">Phone (+91) : </label>
                        <asp:TextBox class="form-control" ID="phone" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="addr" class="form-label">Address : </label>
                        <textarea id="addr" runat="server" class="form-control" cols="60" rows="4"></textarea>
                    </div>
                </div>

            </div>
            

                <asp:Button type="submit" runat="server" class="btn btn-primary mt-3" Text="Submit" ID="addT" OnClick="addT_Click"></asp:Button>
        </form>
    </div>

</body>
</html>
