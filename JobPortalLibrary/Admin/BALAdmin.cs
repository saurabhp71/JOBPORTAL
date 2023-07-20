using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JobPortalLibrary.Admin
{
    public class BALAdmin
    {
        // SqlConnection con = new SqlConnection("Data Source=DESKTOP-B3UBKFN;Initial Catalog=\"Job Portal\";Integrated Security=True");
        static string CS = ConfigurationManager.ConnectionStrings["RSJP"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        public void ManageConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            else
            {
                con.Close();
            }
        }
        //------------------Rita Start-----------------------------------------//

        //--------------------Admin Jov Application---------------------------------------------------------/

        public DataSet RPJobStatusApprovle()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "RPJobStatusApprovle");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public void RPUpdateJobStatusApprovle(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPUpdateJobStatusApprovle");
            cmd.Parameters.AddWithValue("@PostJobCode", objAdmin.PostJobCode);
            cmd.Parameters.AddWithValue("@StatusId", objAdmin.StatusId);
            cmd.ExecuteNonQuery();

        }
        public void RPUpdatejobRejectionReason(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPUpdatejobRejectionReason");
            cmd.Parameters.AddWithValue("@PostJobCode", objAdmin.PostJobCode);
            cmd.Parameters.AddWithValue("@StatusId", objAdmin.StatusId);
            cmd.Parameters.AddWithValue("@RejectionReason", objAdmin.RejectionReason);
            cmd.ExecuteNonQuery();

        }

        public SqlDataReader RPJobDetails(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPJobDetails");
            cmd.Parameters.AddWithValue("@PostJobCode", objAdmin.PostJobCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader RejectStatusGet(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RejectStatusGet");
            cmd.Parameters.AddWithValue("@PostJobCode", objAdmin.PostJobCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        //------------------------Admin Company Reviews----------------------------------------------------/

        public DataSet RPCompanyGridview()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "RPCompanyGridview");
            //cmb.Parameters.AddWithValue("@ReviewId", ReviewId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public void RPCompanyIsDelete(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPCompanyIsDelete");
            //cmd.Parameters.AddWithValue("@isDelete", isDelete);
            cmd.Parameters.AddWithValue("@ReviewId", objAdmin.ReviewId);
            cmd.ExecuteNonQuery();

        }
        public void RPCompanyReviewStatusUpdate(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPCompanyReviewStatusUpdate");
            cmd.Parameters.AddWithValue("@StatusId", objAdmin.StatusId);
            cmd.Parameters.AddWithValue("@ReviewId", objAdmin.ReviewId);
            cmd.ExecuteNonQuery();

        }
        public SqlDataReader RPCompanyGridviewDetails(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPCompanyGridviewDetails");
            cmd.Parameters.AddWithValue("@ReviewId", objAdmin.ReviewId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }

        // --------------------Admin--Employers-----------//
        public DataSet RPAdminEmployeGrid()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "RPAdminEmployeGrid");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        public void RPPaymentStatusUpdate(AdminUser objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPPaymentStatusUpdate");
            cmd.Parameters.AddWithValue("@StatusId", objAdmin.StatusId);
            cmd.Parameters.AddWithValue("@EmployeerCode", objAdmin.Employercode);
            cmd.ExecuteNonQuery();

        }



        //---------------------- Admin DashBord Count------------///
        public SqlDataReader RPTotalJobsPosted()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPTotalJobsPosted");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader RPTotalSeekerRegister()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPTotalSeekerRegister");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader RPTotalEmployerRegister()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPTotalEmployerRegister");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader RPTotalApplicationAppvalAndReject()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RPTotalApplicationAppvalAndReject");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public DataSet RPGetStatus()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "RPGetStatus");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        //----------------Admin Jobs------------///
        public DataSet RPAdminJobsGrid()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "RPAdminJobsGrid");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

        //----------Rita End------------------------------------------//
        public DataSet SiteEarningEmp()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "SiteearningEmp");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet SiteEarningSeeker()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "SiteearningSeek");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet TotalAmountE()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "TotalAmountEmp");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet TotalAmountS()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "TotalAmountSeek");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

        public DataSet MonthlyEarningE()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "MonthlyEarningEmp");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

        public DataSet MonthlyEarningS()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "MonthlyEarningSeek");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        //--------------------Mitali Start----------------------------//
        public void Subscription(AdminUser sub)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Subscription");
            cmd.Parameters.AddWithValue("@SubscriptionName", sub.SubscriptionName);
            cmd.Parameters.AddWithValue("@UserCategory", sub.UserCategory);
            cmd.Parameters.AddWithValue("@Benefits", sub.Benefits);
            cmd.Parameters.AddWithValue("@SubscriptionDetails", sub.SubscriptionDetails);
            cmd.Parameters.AddWithValue("@SubscriptionDuration", sub.SubscriptionDuration);
            cmd.Parameters.AddWithValue("@PlanPricing", sub.PlanPricing);
            cmd.Parameters.AddWithValue("@IsOffer", sub.IsOffer);
            cmd.Parameters.AddWithValue("@Offer", sub.Offer);
            cmd.Parameters.AddWithValue("@OfferedPrice", sub.OfferedPrice);
            cmd.ExecuteNonQuery();
         

        }

        public void AddBenefits(AdminUser sub)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AddBenefits");
            cmd.Parameters.AddWithValue("@Benefits", sub.Benefits);
            cmd.ExecuteNonQuery();
            

        }
        public DataSet GetBenefits()                           // multiselect dropdown
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetBenefits");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet PlanGrid()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PlanGrid");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

        public SqlDataReader PlanDetails(AdminUser obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PlanDetails");
            cmd.Parameters.AddWithValue("@SubscriptionId", obj.SubscriptionId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            
        }
        public void UpdatePlan(AdminUser obj)
        {

            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Updateplan");
            cmd.Parameters.AddWithValue("@SubscriptionId", obj.SubscriptionId);
            cmd.Parameters.AddWithValue("@SubscriptionName", obj.SubscriptionName);
            cmd.Parameters.AddWithValue("@Benefits", obj.Benefits);
            cmd.Parameters.AddWithValue("@SubscriptionDetails", obj.SubscriptionDetails);
            cmd.Parameters.AddWithValue("@SubscriptionDuration", obj.SubscriptionDuration);
            cmd.Parameters.AddWithValue("@PlanPricing", obj.PlanPricing);
            cmd.Parameters.AddWithValue("@Offer", obj.Offer);
            cmd.Parameters.AddWithValue("@OfferedPrice", obj.OfferedPrice);
            cmd.ExecuteNonQuery();
            
        }
        public DataSet getbenifits(int benifitsid)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "getbenifits");
            cmd.Parameters.AddWithValue("@BenefitId", benifitsid);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        public void DeletePlan(AdminUser ad)
        {

            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeletePlan");
            cmd.Parameters.AddWithValue("@SubscriptionId", ad.SubscriptionId);
            cmd.ExecuteNonQuery();
       

        }
        public DataSet Jobseekargrid()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Jobseekargrid");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet getearningvsemp()
        {
            ManageConnection();
            SqlCommand cmb = new SqlCommand("SPAdmin", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "Top10EarningvsEmployer");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
    }
}
