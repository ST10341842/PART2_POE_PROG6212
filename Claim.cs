using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PART2_POE_PROG6212
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string LecturerName { get; set; }
        public string LecturerEmail { get; set; }
        public string Module { get; set; }
        public DateTime ClaimDate { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalClaim { get; set; }

        public string ClaimStatus { get; set; }

        // Parameterless constructor
        public Claim() { }

        // Parameterized constructor
        public Claim(int claimId, string lecturerName, string lecturerEmail, string module, DateTime claimDate,
                     int hoursWorked, decimal hourlyRate, decimal totalClaim)
        {
            ClaimID = claimId;
            LecturerName = lecturerName;
            LecturerEmail = lecturerEmail;
            Module = module;
            ClaimDate = claimDate;
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
            TotalClaim = totalClaim;
        }
    }
}