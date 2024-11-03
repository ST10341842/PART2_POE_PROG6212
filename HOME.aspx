<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HOME.aspx.cs" Inherits="PART2_POE_PROG6212.HOME" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Home Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            flex-direction: column; 
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        h1 {
            color: #007bff; 
            margin-bottom: 10px; 
        }
        h2 {
            color: #555;
            margin-bottom: 40px; 
            font-weight: normal; 
            text-align: center; 
        }
        .grid-container {
            padding: 20px; 
            display: grid;
            grid-template-columns: 1fr 1fr;
            grid-gap: 30px; 
        }
        .grid-container .button-container {
            display: flex;
            flex-direction: column; 
            align-items: center; 
            border: 2px solid #007bff; 
            border-radius: 10px; 
            padding: 20px;
            background-color: white; 
            box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.1); 
        }
        .grid-container button {
            padding: 10px 20px; 
            font-size: 20px; 
            background-color: white;
            border: 2px solid #007bff; 
            box-shadow: 0px 10px 20px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            cursor: pointer;
            text-align: center;
            width: 150px; 
        }
        .grid-container .image-container img {
            width: 80px; 
            height: 80px;
            margin-bottom: 10px;
        }
        .grid-container button:hover {
            background-color: #f0f0f0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to the Lecture Claim System</h1> 
        <h2>Your Success is Our Mission</h2> 
        <div class="grid-container">
            <div class="button-container">
                <div class="image-container">
                    <img src="images/download%20(2).png"/>
                </div>
                 <asp:Button ID="HRButton" runat="server" OnClick="HRButton_Click" Text="Human Resources" />
            </div>
            <div class="button-container">
                <div class="image-container">
                    <img src="images/download%20(1).png" />
                </div>
                <asp:Button ID="LecturerButton" runat="server" Text="Make a Claim (Lecturer)" CssClass="roleButton" OnClick="LecturerButton_Click" />

            </div>
            <div class="button-container">
                <div class="image-container">
                    <img src="images/AM.png" />
                </div>
                <asp:Button ID="AMButton" runat="server" Text="Academic Manager (AM)" CssClass="roleButton" OnClick="AMButton_Click" />
            </div>
            <div class="button-container">
                <div class="image-container">
                    <img src="images/pc.png" />
                </div>
                <asp:Button ID="PCButton" runat="server" Text="Program Coordinator (PC)" CssClass="roleButton" OnClick="PCButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
