using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PART2_POE_PROG6212
{
    public partial class HOME : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ViewProfileButton_Click(object sender, EventArgs e)
        {
            // Redirect to Review Claim page
            Response.Redirect("ReviewCLaims.aspx");
        }

        // Lecturer role selected
        protected void LecturerButton_Click(object sender, EventArgs e)
        {
            Session["UserRole"] = "Lecturer";  // Set role to Lecturer
            Response.Redirect("ClaimForm.aspx");  // Redirect to the claim form page
        }

        // Program Coordinator role selected
        protected void PCButton_Click(object sender, EventArgs e)
        {
            Session["UserRole"] = "PC";  // Set role to Program Coordinator
            Response.Redirect("ReviewClaims.aspx");  // Redirect to review claims page
        }

        // Academic Manager role selected
        protected void AMButton_Click(object sender, EventArgs e)
        {
            Session["UserRole"] = "AM";  // Set role to Academic Manager
            Response.Redirect("ReviewClaims.aspx");  // Redirect to review claims page
        }
    }
}