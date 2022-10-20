﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticket_PDF.aspx.cs" Inherits="Railway_Res.Ticket_PDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="page">
        
      <table align="center" id="PanelTable" cellspacing="0" cellpadding="0" border="0">
        <tr style="margin-top: 5px;">
            <td>
                <div style="border: none 1px transparent; background-color: transparent;">
                    <asp:Label Width="100%" Style="text-align: justify;" ID="label6" runat="server" Text="Click the button to view a PDF document generated by Essential PDF.  Please note that Adobe Reader or its equivalent is required to view the resultant document."></asp:Label>
                </div>
                <br />
                <div style="border: solid 1px #788DB3; padding: 5px 7px 5px 7px; background-color: #EDF0F7;">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td align="center">
                                <asp:Button Width="100px" Style="margin-left: 3px" ID="Button1" Height="27px" runat="server"
                                    Text="Create PDF" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
