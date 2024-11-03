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
        protected void HRButton_Click(object sender, EventArgs e)
        {
            Session["UserRole"] = "HR"; 
            Response.Redirect("ReviewClaims.aspx");  // Redirect to the review Claims page
        }
      
        protected void LecturerButton_Click(object sender, EventArgs e)
        { 
            Session["UserRole"] = "Lecturer";  
            Response.Redirect("ClaimForm.aspx");  // Redirect to the claim form page
        }

        
        protected void PCButton_Click(object sender, EventArgs e)
        {
            Session["UserRole"] = "PC";  
            Response.Redirect("ReviewClaims.aspx");  // Redirect to review claims page
        }


        protected void AMButton_Click(object sender, EventArgs e)
        {
            Session["UserRole"] = "AM"; 
            Response.Redirect("ReviewClaims.aspx");  // Redirect to review claims page
        }
    }
}