<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditClaim.aspx.cs" Inherits="PART2_POE_PROG6212.EditClaim" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Edit Claim</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form div {
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            width: 400px; /* Increased width for better layout */
        }

        h2 {
            text-align: center;
            color: #333;
            font-size: 24px;
            margin-bottom: 20px;
        }

        label {
            display: block;
            color: #555;
            margin: 5px 0 2px;
            font-size: 14px;
        }

        input[type="text"], input[type="email"], select {
            width: 100%;
            padding: 10px; 
            margin-bottom: 15px; 
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }

        input[disabled] {
            background-color: #e9ecef;
        }

        input[type="submit"], input[type="button"], button {
            width: 100%;
            padding: 10px;
            margin-top: 10px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #btnUpdate {
            background-color: #28a745;
            color: white;
        }
        
        #btnUpdate:hover {
            background-color: #218838;
        }

        #btnCancel {
            background-color: #dc3545;
            color: white;
        }

        #btnCancel:hover {
            background-color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Claim</h2>

            <asp:Label ID="lblClaimID" runat="server" Text="Claim ID:" AssociatedControlID="txtClaimID" />
            <asp:TextBox ID="txtClaimID" runat="server" Enabled="false" />

            <asp:Label ID="lblLecturerName" runat="server" Text="Lecturer Name:" AssociatedControlID="txtLecturerName" />
            <asp:TextBox ID="txtLecturerName" runat="server" />

            <asp:Label ID="lblLecturerEmail" runat="server" Text="Lecturer Email:" AssociatedControlID="txtLecturerEmail" />
            <asp:TextBox ID="txtLecturerEmail" runat="server" />

            <asp:Label ID="lblModule" runat="server" Text="Module:" AssociatedControlID="ddlModule" />
            <asp:DropDownList ID="ddlModule" runat="server">
                <asp:ListItem Value="Prog6212">Prog6212</asp:ListItem>
                <asp:ListItem Value="Data6222">Data6222</asp:ListItem>
                <asp:ListItem Value="Hcin6222">Hcin6222</asp:ListItem>
                <asp:ListItem Value="IPMA6212">IPMA6212</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="lblClaimDate" runat="server" Text="Claim Date:" AssociatedControlID="txtClaimDate" />
            <asp:TextBox ID="txtClaimDate" runat="server" />

            <asp:Label ID="lblHoursWorked" runat="server" Text="Hours Worked:" AssociatedControlID="txtHoursWorked" />
            <asp:TextBox ID="txtHoursWorked" runat="server" />

            <asp:Label ID="lblHourlyRate" runat="server" Text="Hourly Rate:" AssociatedControlID="txtHourlyRate" />
            <asp:TextBox ID="txtHourlyRate" runat="server" />

            <asp:Label ID="lblTotalClaim" runat="server" Text="Total Claim:" AssociatedControlID="txtTotalClaim" />
            <asp:TextBox ID="txtTotalClaim" runat="server" />

            <asp:Label ID="lblClaimStatus" runat="server" Text="Claim Status:" AssociatedControlID="txtClaimStatus" />
            <asp:TextBox ID="txtClaimStatus" runat="server" Enabled="false" />

            <asp:Button ID="btnUpdate" runat="server" Text="Update Claim" OnClick="btnUpdate_Click" CssClass="btnUpdate" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btnCancel" />
        </div>
    </form>
</body>
</html>
