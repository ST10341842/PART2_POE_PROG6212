using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PART2_POE_PROG6212
{
    public partial class ClaimForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateModules();
                ClaimDateTextBox.Attributes.Add("placeholder", "dd/MM/yyyy");
            }
        }

        private void PopulateModules()
        {
            ModuleDropDownList.Items.Clear();
            ModuleDropDownList.Items.Add(new ListItem("HCIN6222", "HCIN6222"));
            ModuleDropDownList.Items.Add(new ListItem("PROG6212", "PROG6212"));
            ModuleDropDownList.Items.Add(new ListItem("DATA6222", "DATA6222"));
            ModuleDropDownList.Items.Add(new ListItem("IPMA6212", "IPMA6212"));
        }

        protected void CalculateTotalClaim(object sender, EventArgs e)
        {
            if (double.TryParse(HoursTextBox.Text, out double hoursWorked) && double.TryParse(RateTextBox.Text, out double hourlyRate))
            {
                double totalClaim = hoursWorked * hourlyRate;
                TotalClaimTextBox.Text = totalClaim.ToString("F2");
                ShowMessage(""); // Clear previous messages
            }
            else
            {
                ShowMessage("Please enter valid numeric values for hours worked and hourly rate.");
            }
        }

        protected void SubmitClaimButton_Click(object sender, EventArgs e)
        {
            string lecturerID = LecturerIDTextBox.Text;
            string lecturerName = LecturerNameTextBox.Text;
            string lecturerEmail = LecturerEmailTextBox.Text;
            string selectedModule = ModuleDropDownList.SelectedValue;

            if (!DateTime.TryParse(ClaimDateTextBox.Text, out DateTime claimDateValue))
            {
                ShowMessage("Please enter a valid date in the format dd/MM/yyyy.");
                return;
            }

            if (!double.TryParse(HoursTextBox.Text, out double hoursWorked) || !double.TryParse(RateTextBox.Text, out double hourlyRate))
            {
                ShowMessage("Please enter valid numeric values for hours worked and hourly rate.");
                return;
            }

            double totalClaim = hoursWorked * hourlyRate;
            string fileName = "";

            if (SupportingDocumentsFileUpload.HasFile)
            {
                string fileExtension = Path.GetExtension(SupportingDocumentsFileUpload.FileName).ToLower();
                if (fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".jpg" || fileExtension == ".png")
                {
                    fileName = Path.GetFileName(SupportingDocumentsFileUpload.FileName);
                    string savePath = Server.MapPath("~/UploadedFiles/") + fileName;
                    SupportingDocumentsFileUpload.SaveAs(savePath);
                }
                else
                {
                    ShowMessage("Invalid file type. Only PDF, DOC, DOCX, JPG, and PNG files are allowed.");
                    return;
                }
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Claims (LecturerID, LecturerName, LecturerEmail, ClaimDate, Module, HoursWorked, HourlyRate, TotalClaim, SupportingDocuments) " +
                                   "VALUES (@LecturerID, @LecturerName, @LecturerEmail, @ClaimDate, @Module, @HoursWorked, @HourlyRate, @TotalClaim, @SupportingDocuments)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", lecturerID);
                        cmd.Parameters.AddWithValue("@LecturerName", lecturerName);
                        cmd.Parameters.AddWithValue("@LecturerEmail", lecturerEmail);
                        cmd.Parameters.AddWithValue("@ClaimDate", claimDateValue);
                        cmd.Parameters.AddWithValue("@Module", selectedModule);
                        cmd.Parameters.AddWithValue("@HoursWorked", hoursWorked);
                        cmd.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                        cmd.Parameters.AddWithValue("@TotalClaim", totalClaim);
                        cmd.Parameters.AddWithValue("@SupportingDocuments", fileName);

                        cmd.ExecuteNonQuery();
                        ShowMessage("Claim submitted successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error submitting claim: " + ex.Message);
            }
        }

        protected void GoHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private void ShowMessage(string message)
        {
            MessageLabel.Text = message;
            MessageLabel.Visible = !string.IsNullOrEmpty(message);
        }
    }
}
