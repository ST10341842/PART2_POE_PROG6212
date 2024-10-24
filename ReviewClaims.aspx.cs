using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            LoadClaims(); // Reload the claims after updating the status
        }

        protected bool ShowActionButtons()
        {
            // Show buttons only if the user is a Program Coordinator (PC) or Academic Manager (AM)
            string userRole = Session["UserRole"] != null ? Session["UserRole"].ToString() : string.Empty;
            return userRole == "PC" || userRole == "AM";
        }

        protected bool ShowActionButtonsForPending(object claimStatus)
        {
            string status = claimStatus.ToString();
            return status == "Pending" && ShowActionButtons(); // Only show for pending claims and authorized roles
        }
    }
}
