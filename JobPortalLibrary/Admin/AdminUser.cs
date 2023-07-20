using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalLibrary.Admin
{
    public class AdminUser
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }

        public string EmailId { get; set; }

        public Int64 ContactNo { get; set; }

        public string ProfilePicture { get; set; }

        public string Password { get; set; }
        public int BenefitId { get; set; }
        public string Benefit { get; set; }

        public int PlanId { get; set; }

        public string Plans { get; set; }

        public string PlanPrice { get; set; }

        public string PlanDuration { get; set; }

        public DateTime PlanRegistrationDate{ get; set; }

        public string Planfor { get; set; }

        public int PaymentId { get; set; }

        public string Seekercode { get; set; }

        public string Employercode { get; set; }

        public string PaymentMode { get; set; }
        public DateTime SubscriptionDate { get; set; }

        public string TransactionId { get; set; }

        public int StatusId { get; set; }

        public string Status { get; set; }


        //rita patil
        public List<AdminUser> Users { get; set; }
        public string PostJobCode { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public string RejectionReason { get; set; }
        public string Statusname { get; set; }

        public string CompanyName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AboutCompany { get; set; }
        public string Rating { get; set; }
        public string Review { get; set; }
        public int isDelete { get; set; }
        public int CompanyId { get; set; }
        public int ReviewId { get; set; }
        public string Rdate { get; set; }
        public string EmployerName { get; set; }

        public string StatusType { get; set; }
        public string ContactPerson { get; set; }
        public string JobCategory { get; set; }
        public string OpportunityType { get; set; }
        public string WorkingShifts { get; set; }
        public string NoOfOpenings { get; set; }
        public string Address { get; set; }
        public string Salary { get; set; }
        public string TotalExperience { get; set; }
        public string ExpectedJoiningDate { get; set; }
        public string ApplicationEndDate { get; set; }
        public string JobType { get; set; }
        public string CompanyLogo { get; set; }
        public string Location { get; set; }
        public string applicationcount { get; set; }
        public string Hire { get; set; }
        public List<AdminUser> User { get; set; }

     
       
        public string HRName { get; set; }
        //---------Mitali Start--------//
        public int SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }

        public string Benefits { get; set; }
        public string SubscriptionDetails { get; set; }
        [Required]
        public string SubscriptionDuration { get; set; }
        [Required]
        public Int64 PlanPricing { get; set; }

        public int Offer { get; set; }

        public Int64 OfferedPrice { get; set; }


        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [DataType(DataType.Date)]
        public DateTime To { get; set; }
        public string[] BenifitList { get; set; }

        public string[] SeekerBenifitList { get; set; }

        public List<AdminUser> joblist { get; set; }

        public string UserCategory { get; set; }

        public List<AdminUser> planlist { get; set; }

        public string IsOffer { get; set; }
        //-------------Mitali End--------------//
        public string subDate { get; set; }
      //  public string SeekerCode { get; set; }
        public string SeekerName { get; set; }
        public string Designation { get; set; }
        public string Empname { get; set; }
        public int Pay { get; set; }

        public List<AdminUser> LstUser { get; set; }
    }
}
