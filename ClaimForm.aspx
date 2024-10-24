<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimForm.aspx.cs" Inherits="PART2_POE_PROG6212.ClaimForm" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Claim Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
        }
        .navbar {
            background-color: #007BFF;
            overflow: hidden;
            padding: 10px 20px;
        }
        .navbar a {
            color: white;
            padding: 14px 20px;
            text-decoration: none;
            float: left;
            font-size: 17px;
        }
        .navbar a:hover {
            background-color: #0056b3;
        }
        .container {
            width: 80%;
            margin: 20px auto;
            padding: 20px;
            background-color: white;
            box-shadow: 0px 10px 20px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }
        h2 {
            margin: 0 0 10px;
        }
        h3 {
            margin: 0 0 20px;
            color: #555;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
        }
        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        button {
            background-color: #007BFF;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
       
        }
        button:hover {
            background-color: #0056b3;
        }
        .message {
            color: red; 
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="ReviewClaims.aspx">View Claims</a> 
            <a href="home.aspx">Exit</a>
        </div>
        <div class="container">
            <h2>Welcome to Lecture Dashboard</h2>
            <h3>Please fill in the below information to make a claim</h3>

            <asp:Label ID="MessageLabel" runat="server" CssClass="message" Visible="false"></asp:Label>

            <div class="form-group">
                <label for="lecturerId">Lecture ID:</label>
                <asp:TextBox ID="LecturerIDTextBox" runat="server" />
            </div>

            <div class="form-group">
                <label for="name">Name:</label>
                <asp:TextBox ID="LecturerNameTextBox" runat="server" />
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="LecturerEmailTextBox" runat="server" />
            </div>

            <div class="form-group">
                <label for="claimDate">Claim Date:</label>
                <asp:TextBox ID="ClaimDateTextBox" runat="server" placeholder="dd/MM/yyyy" />
            </div>

              <div class="form-group">
                <label for="supportingDocuments">Supporting Documents:</label>
                <asp:FileUpload ID="SupportingDocumentsFileUpload" runat="server" />
                <asp:Label ID="FileUploadErrorLabel" runat="server" CssClass="message" Visible="false" />
            </div>

            <div class="form-group">
                <label for="moduleSelect">Select Module:</label>
                <asp:DropDownList ID="ModuleDropDownList" runat="server" />
            </div>

            <div class="form-group">
                <label for="hours">Hours Worked:</label>
                <asp:TextBox ID="HoursTextBox" runat="server" />
            </div>
            <div class="form-group">
                <label for="rate">Hourly Rate:</label>
                <asp:TextBox ID="RateTextBox" runat="server" />
            </div>
            <div class="form-group">
                <label for="total">Total Claim:</label>
                <asp:TextBox ID="TotalClaimTextBox" runat="server" ReadOnly="True" />
            </div>

            <asp:Button ID="CalculateTotalButton" runat="server" Text="Calculate Total" OnClick="CalculateTotalClaim" />
            <asp:Button ID="SubmitClaimButton" runat="server" Text="Submit Claim" OnClick="SubmitClaimButton_Click" />
            <asp:Button ID="GoHomeButton" runat="server" Text="Go to Home" OnClick="GoHomeButton_Click" />
        </div>
    </form>

    <script type="text/javascript">
        function closeWindow() {
            window.open('', '_self', '');
            window.close();
        }
    </script>
</body>
</html>
