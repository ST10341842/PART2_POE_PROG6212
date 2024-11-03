using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace PART2_POE_PROG6212
{
    public partial class EditClaim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ClaimID"] != null)
                {
                    int claimId = Convert.ToInt32(Request.QueryString["ClaimID"]);
                    LoadClaim(claimId);
                }
            }
        }

        private void LoadClaim(int claimId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ClaimID, LecturerName, LecturerEmail, Module, ClaimDate, HoursWorked, HourlyRate, TotalClaim, ClaimStatus FROM Claims WHERE ClaimID = @ClaimID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClaimID", claimId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtClaimID.Text = reader["ClaimID"].ToString();
                            txtLecturerName.Text = reader["LecturerName"].ToString();
                            txtLecturerEmail.Text = reader["LecturerEmail"].ToString();
                            ddlModule.SelectedValue = reader["Module"].ToString(); 
                            txtClaimDate.Text = reader["ClaimDate"].ToString();
                            txtHoursWorked.Text = reader["HoursWorked"].ToString();
                            txtHourlyRate.Text = reader["HourlyRate"].ToString();
                            txtTotalClaim.Text = reader["TotalClaim"].ToString();
                            txtClaimStatus.Text = reader["ClaimStatus"].ToString();
                        }
                    }
                }
            }
        }
        // Event handler for the Update button to update claim information in the database
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // SQL query to update the claim details in the database
                string query = "UPDATE Claims SET LecturerName = @LecturerName, LecturerEmail = @LecturerEmail, Module = @Module, ClaimDate = @ClaimDate, HoursWorked = @HoursWorked, HourlyRate = @HourlyRate, TotalClaim = @TotalClaim, ClaimStatus = @ClaimStatus WHERE ClaimID = @ClaimID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LecturerName", txtLecturerName.Text);
                    cmd.Parameters.AddWithValue("@LecturerEmail", txtLecturerEmail.Text);
                    cmd.Parameters.AddWithValue("@Module", ddlModule.SelectedValue);
                    cmd.Parameters.AddWithValue("@ClaimDate", DateTime.Parse(txtClaimDate.Text));
                    cmd.Parameters.AddWithValue("@HoursWorked", int.Parse(txtHoursWorked.Text));
                    cmd.Parameters.AddWithValue("@HourlyRate", decimal.Parse(txtHourlyRate.Text));
                    cmd.Parameters.AddWithValue("@TotalClaim", decimal.Parse(txtTotalClaim.Text));
                    cmd.Parameters.AddWithValue("@ClaimStatus", txtClaimStatus.Text);
                    cmd.Parameters.AddWithValue("@ClaimID", int.Parse(txtClaimID.Text));

                    cmd.ExecuteNonQuery(); // Execute the update command
                }
            }

            // Redirect back to ReviewClaims page
            Response.Redirect("ReviewClaims.aspx");
        }
        // Event handler for the Cancel button to return to the ReviewClaims page without saving changes
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewClaims.aspx");
        }
    }
}
