using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using JobPortalLibrary.JobSeeker;
using System.Runtime.Remoting.Messaging;
using System.Configuration;

namespace JobPortalLibrary.JobSeeker
{
    public class BALSeeker
    {
      //  SqlConnection con = new SqlConnection("Data Source=DESKTOP-B3UBKFN;Initial Catalog=\"Job Portal\";Integrated Security=True");
        static string CS = ConfigurationManager.ConnectionStrings["RSJP"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        public void ManageConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            //else
            //{
            //    con.Close();
            //}
        }

        //--------------------------------------Saurabh Start--------------------------------//

        //-------------------------Personal Details-------------------------//
        public void PersonalDetails(SeekerUser objsekUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PersonalDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            cmd.Parameters.AddWithValue("@SeekerName", objsekUser.SeekerName);
            cmd.Parameters.AddWithValue("@ContactNo", objsekUser.ContactNo);
            cmd.Parameters.AddWithValue("@DOB", objsekUser.DOB);
            cmd.Parameters.AddWithValue("@Gender", objsekUser.Gender);
            cmd.Parameters.AddWithValue("@CorrespondenceAddress", objsekUser.CorrespondenceAddress);
            cmd.Parameters.AddWithValue("@PermanentAddress", objsekUser.PermanantAddress);
            cmd.Parameters.AddWithValue("@Pincode", objsekUser.Pincode);
            cmd.Parameters.AddWithValue("@CityId", objsekUser.CityId);
            cmd.Parameters.AddWithValue("@LanguageID", objsekUser.LanguageId);
            cmd.Parameters.AddWithValue("@PhysicallyChallenged", objsekUser.PhysicallyChallenged);
            cmd.Parameters.AddWithValue("@CasteCategory", objsekUser.CasteCategory);
            cmd.Parameters.AddWithValue("@MaritalStatus", objsekUser.MaritalStatus);
            cmd.Parameters.AddWithValue("@ProfileSummary", objsekUser.ProfileSummary);
            cmd.ExecuteNonQuery();


        }
        public void updateIMG(SeekerUser objsekUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "updateIMG");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            cmd.Parameters.AddWithValue("@ProfileIMG", objsekUser.ProfileIMG);
            cmd.ExecuteNonQuery();

        }
        public void updateResume(SeekerUser objsekUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "updateResume");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            cmd.Parameters.AddWithValue("@ResumePDF", objsekUser.ResumePDF);
            cmd.ExecuteNonQuery();
        }
        public SqlDataReader SeekerDetails(SeekerUser objsekUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SeekerDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public DataSet CityBind()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "City");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet Language()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Language");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataTable LanguageShow(int languageid)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "LanguageShow");
            cmd.Parameters.AddWithValue("@LanguageID", languageid);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable ds = new DataTable();
            adpt.Fill(ds);
            return ds;

        }
        //-----------------------------------------Education--------------------------//
        public DataSet Qualification()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Qualification");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet Degree(int QualificationID)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Degree");
            cmd.Parameters.AddWithValue("@QualificationID", QualificationID);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet Specialization(int DegreeId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Specialization");
            cmd.Parameters.AddWithValue("@DegreeId", DegreeId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public SqlDataReader GetEducationDetails(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowEducationDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }

        public void AddSSC(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AddSSC");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@QualificationID", objseeker.QualificationId);
            cmd.Parameters.AddWithValue("@DegreeId", objseeker.DegreeId);
            cmd.Parameters.AddWithValue("@PassingYear", objseeker.PassingYear);
            cmd.Parameters.AddWithValue("@marks", objseeker.Marks);
            cmd.ExecuteNonQuery();

        }
        public void AddHSC(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AddHSC");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@QualificationID", objseeker.QualificationId);
            cmd.Parameters.AddWithValue("@DegreeId", objseeker.DegreeId);
            cmd.Parameters.AddWithValue("@PassingYear", objseeker.PassingYear);
            cmd.Parameters.AddWithValue("@marks", objseeker.Marks);
            cmd.ExecuteNonQuery();

        }
        public void AddUG(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AddUG");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@QualificationID", objseeker.QualificationId);
            cmd.Parameters.AddWithValue("@DegreeId", objseeker.DegreeId);
            cmd.Parameters.AddWithValue("@SpecalizationId", objseeker.SpecializationId);
            cmd.Parameters.AddWithValue("@University", objseeker.University);
            cmd.Parameters.AddWithValue("@PassingYear", objseeker.PassingYear);
            cmd.Parameters.AddWithValue("@marks", objseeker.Marks);
            cmd.Parameters.AddWithValue("@CourseType", objseeker.CourseType);
            cmd.ExecuteNonQuery();

        }
        public void AddGraduation(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AddGraduation");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@QualificationID", objseeker.QualificationId);
            cmd.Parameters.AddWithValue("@DegreeId", objseeker.DegreeId);
            cmd.Parameters.AddWithValue("@SpecalizationId", objseeker.SpecializationId);
            cmd.Parameters.AddWithValue("@University", objseeker.University);
            cmd.Parameters.AddWithValue("@PassingYear", objseeker.PassingYear);
            cmd.Parameters.AddWithValue("@marks", objseeker.Marks);
            cmd.Parameters.AddWithValue("@CourseType", objseeker.CourseType);
            cmd.ExecuteNonQuery();

        }
        public void AddPG(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AddPG");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@QualificationID", objseeker.QualificationId);
            cmd.Parameters.AddWithValue("@DegreeId", objseeker.DegreeId);
            cmd.Parameters.AddWithValue("@SpecalizationId", objseeker.SpecializationId);
            cmd.Parameters.AddWithValue("@University", objseeker.University);
            cmd.Parameters.AddWithValue("@PassingYear", objseeker.PassingYear);
            cmd.Parameters.AddWithValue("@marks", objseeker.Marks);
            cmd.Parameters.AddWithValue("@CourseType", objseeker.CourseType);
            cmd.ExecuteNonQuery();

        }
        //---------------------------Employment details----------------------------//
        public SqlDataReader GetEmploymentDetails(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetEmploymentDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public void UpdateEmploymentDetails(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateEmploymentDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@CurrentEmployement", objseeker.CurrentEmployement);
            cmd.Parameters.AddWithValue("@EmployementType", objseeker.EmployementType);
            cmd.Parameters.AddWithValue("@CompanyName", objseeker.CompanyName);
            cmd.Parameters.AddWithValue("@Designation", objseeker.Designation);
            cmd.Parameters.AddWithValue("@JoiningDate", objseeker.JoiningDate);
            cmd.Parameters.AddWithValue("@CurrentSalary", objseeker.CurrentSalary);
            cmd.Parameters.AddWithValue("@SkillName", objseeker.SkillId);
            cmd.Parameters.AddWithValue("@JobProfile", objseeker.JobProfile);
            cmd.Parameters.AddWithValue("@NoticePeriod", objseeker.NoticePeriod);
            cmd.ExecuteNonQuery();

        }
        public DataSet Skill()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Skill");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        //---------------------------Project Details-----------------------//
        public SqlDataReader GetProjectDetails(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetProjectDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public void UpdateProjectDetails(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateProjectDetails");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@ProjectTitle", objseeker.ProjectTitle);
            cmd.Parameters.AddWithValue("@ClientName", objseeker.ClientName);
            cmd.Parameters.AddWithValue("@ProjectStatus", objseeker.ProjectStatus);
            cmd.Parameters.AddWithValue("@TotalExperience", objseeker.TotalExperience);
            cmd.Parameters.AddWithValue("@ProjectDetails", objseeker.ProjectDetails);
            cmd.ExecuteNonQuery();

        }
        //---------------------------Career Profile-----------------------//
        public SqlDataReader CareerProfile(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CareerProfile");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public DataSet Industry()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Industry");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet JobCategory(int IndustryId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "JobCategory");
            cmd.Parameters.AddWithValue("@IndustryId", IndustryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataTable PreferredLocation(int CityId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PreferredLocation");
            cmd.Parameters.AddWithValue("@CityId", CityId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable ds = new DataTable();
            adpt.Fill(ds);
            return ds;

        }
        public void UpdateCareerProfile(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateCareerProfile");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd.Parameters.AddWithValue("@IndustryId", objseeker.IndustryID);
            cmd.Parameters.AddWithValue("@TotalExperience", objseeker.TotalExperience);
            cmd.Parameters.AddWithValue("@Location", objseeker.Location);
            cmd.Parameters.AddWithValue("@JobcategoryId", objseeker.JobCategoryId);
            cmd.Parameters.AddWithValue("@EmailId", objseeker.EmailId);
            cmd.Parameters.AddWithValue("@ContactNo", objseeker.ContactNo);
            cmd.ExecuteNonQuery();

        }
        //---------------------------Complete Profile-----------------------//
        public SqlDataReader CompleteProfile(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CompleteProfile");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        //---------------------------Preferred Job-----------------------//
        public DataSet PreferredJob(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PreferredJob");
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public SqlDataReader jobdetails(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "jobdetails");
            cmd.Parameters.AddWithValue("@PostJobCode", objseeker.PostJobCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        //---------------------------All Companys-----------------------//
        public DataSet AllCompanys()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AllCompanys");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public SqlDataReader CompanysDetails(SeekerUser objseeker)
        {
            try
            {
                ManageConnection();
                SqlCommand cmd = new SqlCommand("SPSeeker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "CompanysDetails");
                cmd.Parameters.AddWithValue("@CompanyId", objseeker.CompanyId);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //----------------------------company Follow & company Feedback----------------------//
        public SqlDataReader CompanyFeedback(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CompanyFeedback");
            cmd.Parameters.AddWithValue("@CompanyId", objseeker.CompanyId);
            cmd.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public void FollowCompany(SeekerUser objseeker)
        {
            try
            {
                ManageConnection();
                SqlCommand cmd2 = new SqlCommand("SPSeeker", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@flag", "FollowCompany");
                cmd2.Parameters.AddWithValue("@CompanyId", objseeker.CompanyId);
                cmd2.Parameters.AddWithValue("@EmployerCode", objseeker.EmployerCode);
                cmd2.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
                cmd2.Parameters.AddWithValue("@Follow", objseeker.Follow1);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void ReviewCompanyFeedback(SeekerUser objseeker)
        {
            try
            {
                ManageConnection();
                SqlCommand cmd2 = new SqlCommand("SPSeeker", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@flag", "ReviewCompanyFeedback");
                cmd2.Parameters.AddWithValue("@CompanyId", objseeker.CompanyId);
                cmd2.Parameters.AddWithValue("@EmployerCode", objseeker.EmployerCode);
                cmd2.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
                cmd2.Parameters.AddWithValue("@Review", objseeker.Review);
                cmd2.Parameters.AddWithValue("@Rating", objseeker.Rating);
                cmd2.Parameters.AddWithValue("@DoyouCurrentlyworkhere", objseeker.DoyouCurrentlyworkhere);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void SaveCompanyFeedback(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd1 = new SqlCommand("SPSeeker", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@flag", "SaveCompanyFeedback");
            cmd1.Parameters.AddWithValue("@CompanyId", objseeker.CompanyId);
            cmd1.Parameters.AddWithValue("@EmployerCode", objseeker.EmployerCode);
            cmd1.Parameters.AddWithValue("@Seekercode", objseeker.Seekercode);
            cmd1.Parameters.AddWithValue("@Follow", objseeker.Follow1);
            cmd1.Parameters.AddWithValue("@Rating", objseeker.Rating);
            cmd1.Parameters.AddWithValue("@Review", objseeker.Review);
            cmd1.ExecuteNonQuery();
        }
        public DataTable requiredQualification(int RequireQualificationId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "requiredQualification");
            cmd.Parameters.AddWithValue("@RequireQualificationId", RequireQualificationId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable ds = new DataTable();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet AllJobs()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AllJobs");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public DataSet SearchJobs(SeekerUser objseeker)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchJobs");
            cmd.Parameters.AddWithValue("@JobTitle", objseeker.JobTitle);
            cmd.Parameters.AddWithValue("@TotalExperience", objseeker.TotalExperience);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        //-----------------------------dashboard count---------------------------//
        public SqlDataReader totalcompany()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "totalcompany");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public SqlDataReader totaljobs()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "totaljobs");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public SqlDataReader totalapplyjobs(SeekerUser obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "totalapplyjobs");
            cmd.Parameters.AddWithValue("@Seekercode", obj.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public SqlDataReader ViewProfile(SeekerUser obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ViewProfile");
            cmd.Parameters.AddWithValue("@Seekercode", obj.Seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }


        //--------------------------------------Saurabh End--------------------------------//

        //--------------------------------------Sanket Start------------------------------//

        public DataSet FindJobs(SeekerUser objsekUser /*string postjobcode*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "FindJobs");
            //cmd.Parameters.AddWithValue("@PostJobCode", postjobcode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            
        }

        //------------------Search Jobs-------------------------------------------------//
        public DataSet FindJobs1(SeekerUser objsekUser /*string jobtitle,string joblocation,string salary*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "FindJobs1");
            cmd.Parameters.AddWithValue("@JobTitle", objsekUser.JobTitle);
            cmd.Parameters.AddWithValue("@CityId", objsekUser.CityId);
            cmd.Parameters.AddWithValue("@Salary", objsekUser.Salary);
            cmd.Parameters.AddWithValue("@TotalExperience", objsekUser.TotalExperience);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
           
        }

        //--------ApplyButton Jobs Popup---------------------------------//
        public SqlDataReader ApplyJobView(SeekerUser objsekUser /*string PostJobCode*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ApplyJobView");
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            
        }


        //-----------------ResumePDF----------------------------------------------//

        public void SubmitPDF(SeekerUser objsekUser /*string seekercode, string postjobcode, int statusid, DateTime applieddate, string resumepdf*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SubmitPDF");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@StatusID", objsekUser.StatusId);
            cmd.Parameters.AddWithValue("@AppliedDate", objsekUser.AppliedDate);
            cmd.Parameters.AddWithValue("@ResumePDF", objsekUser.ResumePDF);
            cmd.ExecuteNonQuery();
            
        }

        //----------ApplicationGriview--------------------------//
        public DataSet ApplicationGrid(SeekerUser objsekUser /*string seekercode*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ApplicationGrid");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            
        }

        //------------DeleteButtononGrid----------------//
        public void IsDelete(SeekerUser objsekUser /*int jobappliedid*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "IsDelete");
            cmd.Parameters.AddWithValue("@AppliedJobId", objsekUser.AppliedJobID);
            cmd.ExecuteNonQuery();
            
        }

        //-----------StatusUpdateonJobSubmit-----------//

        public SqlDataReader SubmitApplication(SeekerUser objsekUser /*int  jobappliedid,int statusid*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SubmitApplication");
            cmd.Parameters.AddWithValue("@StatusID", objsekUser.StatusId);
            cmd.Parameters.AddWithValue("@AppliedJobId", objsekUser.AppliedJobID);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            
        }

        //------------------DownloadPDF------------------------//
        public SqlDataReader DownloadPDF(SeekerUser objsekUser  /*int seekerid*/)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DownloadPDF");
            cmd.Parameters.AddWithValue("@SeekerId", objsekUser.SeekerId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            
        }

        //----------------------------Sanket End--------------------------------//
        public void Updateseeker(string seekercode, string EmailId, Int64 ContactNo, string Password)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateSeeker");
            cmd.Parameters.AddWithValue("@Seekercode", seekercode);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.ExecuteNonQuery();
            
        }
        //--------------------FetchSeeker-------------------------------------------------
        public SqlDataReader Fetchseeker(string seekercode)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "fetchseeker");
            cmd.Parameters.AddWithValue("@Seekercode", seekercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
           
        }
        //--------------------deleteemployer-------------------------------------------------

        //public void IsDeleteSeeker(int seekerid)
        //{
        //    con.Close();
        //    ManageConnection();
        //    SqlCommand cmd = new SqlCommand("SPSeeker", con);
        //    cmd.Parameters.AddWithValue("@flag", "Deleteseeker");
        //  //  cmd.Parameters.AddWithValue("@isDelete", isDelete);
        //    cmd.Parameters.AddWithValue("@SeekerId", seekerid);
        //    cmd.ExecuteNonQuery();
          
        //}
        //public DataSet fetchseekerId(SeekerUser objsekUser /*string jobtitle,string joblocation,string salary*/)
        //{
        //    ManageConnection();
        //    SqlCommand cmd = new SqlCommand("SPSeeker", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "fetchseekerId");
        //    cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
        //    SqlDataAdapter adpt = new SqlDataAdapter();
        //    adpt.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    adpt.Fill(ds);
        //    return ds;

        //}
        public void IsDeleteSeeker(SeekerUser obj)
        {
            con.Close();
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Deleteseeker");
            cmd.Parameters.AddWithValue("@SeekerId", obj.SeekerId);
            cmd.ExecuteNonQuery();

        }
        public DataSet fetchseekerId(SeekerUser objsekUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "fetchseekerId");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        //--------------------------------------Muskan End-----------------------------------------------------------------------//
        public void ReviewCompanyFeedback(int CompanyId, string EmployerCode, string SeekerCode, int Rating, string Review, int Follow, int StatusId, int DoyouCurrentlyWorkhere, int isDelete)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ReviewCompanyFeedback");
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            cmd.Parameters.AddWithValue("@EmployerCode", EmployerCode);
            cmd.Parameters.AddWithValue("@Seekercode", SeekerCode);
            cmd.Parameters.AddWithValue("@Rating", Rating);
            cmd.Parameters.AddWithValue("@Review", Review);
            cmd.Parameters.AddWithValue("@DoyouCurrentlyworkhere", DoyouCurrentlyWorkhere);
            cmd.Parameters.AddWithValue("@Follow", Follow);
            cmd.Parameters.AddWithValue("@StatusID", StatusId);
            cmd.Parameters.AddWithValue("@isDelete", isDelete);
            cmd.ExecuteNonQuery();
            
        }

        public SqlDataReader CheckAppliedSeeker(SeekerUser CAS)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CheckAppliedSeeker");
            cmd.Parameters.AddWithValue("@Seekercode", CAS.Seekercode);
            cmd.Parameters.AddWithValue("@PostJobCode", CAS.PostJobCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
    }
}

    

