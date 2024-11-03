using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PART2_POE_PROG6212
{
    public partial class ReviewClaims : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClaims();
            }
        }

        private void LoadClaims()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ClaimID, LecturerName, LecturerEmail, Module, ClaimDate, HoursWorked, HourlyRate, TotalClaim, ClaimStatus, SupportingDocuments FROM Claims";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ClaimsGridView.DataSource = dt;
                    ClaimsGridView.DataBind();
                }
            }
        }

        protected void ClaimsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);
                UpdateClaimStatus(claimId, "Approved");
            }
            else if (e.CommandName == "Reject")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);
                UpdateClaimStatus(claimId, "Rejected");
            }
            else if (e.CommandName == "DownloadInvoice")
            {
                int invoiceClaimId = Convert.ToInt32(e.CommandArgument);
                GenerateInvoice(invoiceClaimId);
            }

            else if (e.CommandName == "Edit")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditClaim.aspx?ClaimID={claimId}");
            }
        }

        private void UpdateClaimStatus(int claimId, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Claims SET ClaimStatus = @Status WHERE ClaimID = @ClaimID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ClaimID", claimId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadClaims();
        }

        // New method to implement Download functionality
        private void GenerateInvoice(int invoiceClaimId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            Claim claim = null;

            // Step 1: Retrieve claim details from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ClaimID, LecturerName, LecturerEmail, Module, ClaimDate, HoursWorked, HourlyRate, TotalClaim, ClaimStatus FROM Claims WHERE ClaimID = @ClaimID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClaimID", invoiceClaimId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate claim object using data from the database
                            claim = new Claim
                            {
                                ClaimID = reader.GetInt32(0),
                                LecturerName = reader.GetString(1),
                                LecturerEmail = reader.GetString(2),
                                Module = reader.GetString(3),
                                ClaimDate = reader.GetDateTime(4),
                                HoursWorked = reader.GetInt32(5),
                                HourlyRate = reader.GetDecimal(6),
                                TotalClaim = reader.GetDecimal(7),
                                ClaimStatus = reader.GetString(8),
                            };
                        }
                    }
                }
            }

            //Generates the HTML for the invoice
            if (claim != null)
            {
                string html = $@"
            <html>
            <head>
                <title>Invoice #{claim.ClaimID}</title>
                <style>
                    body {{ font-family: Arial, sans-serif; }}
                    .invoice {{ margin: 20px; padding: 20px; border: 1px solid #ccc; }}
                    .header {{ text-align: center; }}
                    .details {{ margin: 20px 0; }}
                    .details div {{ margin: 5px 0; }}
                    .total {{ font-weight: bold; }}
                </style>
            </head>
            <body>
                <div class='invoice'>
                    <div class='header'>
                        <h1>Invoice</h1>
                        <h2>Claim ID: {claim.ClaimID}</h2>
                    </div>
                    <div class='details'>
                        <div>Lecturer Name: {claim.LecturerName}</div>
                        <div>Lecturer Email: {claim.LecturerEmail}</div>
                        <div>Module: {claim.Module}</div>
                        <div>Claim Date: {claim.ClaimDate.ToShortDateString()}</div>
                        <div>Hours Worked: {claim.HoursWorked}</div>
                        <div>Hourly Rate: {claim.HourlyRate:C}</div>
                        <div class='total'>Total Claim: {claim.TotalClaim:C}</div>
                        <div> Claim Status: {claim.ClaimStatus}</div> 
                    </div>
                </div>
            </body>
            </html>";

                //Serve the HTML for download
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/html";
                HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment; filename=Invoice_{claim.ClaimID}.html");
                HttpContext.Current.Response.Write(html);
                HttpContext.Current.Response.End();
            }
            else
            {
                // Handle case where claim is not found
                HttpContext.Current.Response.Write("Claim not found.");
                HttpContext.Current.Response.End();
            }
        }


        protected bool ShowActionButtons()
        {
            string userRole = Session["UserRole"] != null ? Session["UserRole"].ToString() : string.Empty;
            return userRole == "PC" || userRole == "AM";
        }

        protected bool ShowActionButtonsForPending(object claimStatus)
        {
            string status = claimStatus.ToString();
            return status == "Pending" && ShowActionButtons();
        }

        //method to control HR-specific button visibility
        protected bool ShowHRButtons()
        {
            return Session["UserRole"] != null && Session["UserRole"].ToString() == "HR";
        }
    }
}
