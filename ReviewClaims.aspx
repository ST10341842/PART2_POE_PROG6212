<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewClaims.aspx.cs" Inherits="PART2_POE_PROG6212.ReviewClaims" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Review Claims</title>
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
            width: 100%;
            margin: 20px auto;
            padding: 20px;
            background-color: white;
            box-shadow: 0px 10px 20px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        .button-container {
            display: flex;
            gap: 10px; /* Add space between buttons */
        }
        .action-button {
            padding: 8px 16px;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-align: center;
        }
        .action-button:hover {
            background-color: #0056b3;
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="ClaimForm.aspx">New Claim</a> 
            <a href="Home.aspx">Exit</a>
        </div>
        <div class="container">
            <h2>Submitted Claims</h2>
            <asp:GridView ID="ClaimsGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="ClaimsGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ClaimID" HeaderText="Claim ID" />
                    <asp:BoundField DataField="LecturerName" HeaderText="Lecturer Name" />
                    <asp:BoundField DataField="LecturerEmail" HeaderText="Lecturer Email" />
                    <asp:BoundField DataField="Module" HeaderText="Module" />
                    <asp:BoundField DataField="ClaimDate" HeaderText="Claim Date" />
                    <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
                    <asp:BoundField DataField="HourlyRate" HeaderText="Hourly Rate" />
                    <asp:BoundField DataField="TotalClaim" HeaderText="Total Claim" />
                    <asp:BoundField DataField="ClaimStatus" HeaderText="Claim Status" />
                   <asp:TemplateField HeaderText="Supporting Documents">
                    <ItemTemplate>
                        <asp:HyperLink ID="SupportingDocLink" runat="server" 
                            NavigateUrl='<%# ResolveUrl("~/UploadedFiles/" + Eval("SupportingDocuments")) %>' 
                            Text="View Document" 
                            Target="_blank" 
                            Visible='<%# !string.IsNullOrEmpty(Eval("SupportingDocuments") as string) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
<asp:TemplateField HeaderText="Actions">
    <ItemTemplate>
        <div class="button-container">
            <asp:Button runat="server" CommandName="Approve" CommandArgument='<%# Eval("ClaimID") %>' Text="Approve" Visible='<%# ShowActionButtonsForPending(Eval("ClaimStatus")) %>' CssClass="action-button" />
            <asp:Button runat="server" CommandName="Reject" CommandArgument='<%# Eval("ClaimID") %>' Text="Reject" Visible='<%# ShowActionButtonsForPending(Eval("ClaimStatus")) %>' CssClass="action-button" />
        </div>
    </ItemTemplate>
</asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
