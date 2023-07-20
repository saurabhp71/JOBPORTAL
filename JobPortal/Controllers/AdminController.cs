using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using JobPortalLibrary.Admin;
using JobPortalLibrary.JobSeeker;
using System.Threading.Tasks;
using JobPortalLibrary.Employer;
using Newtonsoft.Json;

namespace JobPortal.Controllers
{
    public class AdminController : Controller
    {
        int SubscriptionId;
        // GET: Admin
        public ActionResult Index()
        {
        
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult AdminIndex()
        {

            return View();
        }

        ///------------AdminDashbord-------------------///
        public ActionResult view()
        {
            AdminUser obj = new AdminUser();
            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.RPTotalJobsPosted();
            while (dr.Read())
            {
                @ViewBag.count = dr["ApprovalJobs"].ToString();
            }
            dr.Close();

            BALAdmin obj2 = new BALAdmin();
            SqlDataReader dt;
            dt = obj2.RPTotalSeekerRegister();
            while (dt.Read())
            {
                @ViewBag.Seeker = dt["seekerRegister"].ToString();
            }
            dt.Close();

            BALAdmin obj3 = new BALAdmin();
            SqlDataReader de;
            de = obj3.RPTotalEmployerRegister();
            while (de.Read())
            {
                @ViewBag.Employer = de["Employer"].ToString();
            }
            de.Close();

            BALAdmin obj4 = new BALAdmin();
            SqlDataReader da;
            da = obj4.RPTotalApplicationAppvalAndReject();
            while (da.Read())
            {
                @ViewBag.Application = da["Applications"].ToString();
            }
            da.Close();


            List<AdminUser> Aprovelst = new List<AdminUser>();

            //List<AdminUser> Aprovelist = new List<AdminUser DataSet ds = new DataSet();
            BALAdmin objadmin1 = new BALAdmin();
            DataSet ds2 = new DataSet();
            ds2 = objadmin1.getearningvsemp();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                AdminUser objb = new AdminUser();
                objb.Pay = Convert.ToInt32(ds2.Tables[0].Rows[i]["payment"].ToString());
                objb.Empname = ds2.Tables[0].Rows[i]["CompanyName"].ToString();
                Aprovelst.Add(objb);
            }
            AdminUser objc = new AdminUser();
            objc.LstUser = Aprovelst;
            ViewBag.listt = JsonConvert.SerializeObject(Aprovelst.Select(prop => new
            {
                lable = prop.Empname,
                y = prop.Pay
            }).ToList());
            return View();
           
        }

        //----------------------------------Admin Jov Application---------------------------------------------/

        [HttpGet]
        public async Task<ActionResult> ApplicationApprovel()
        {
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.RPJobStatusApprovle();
            AdminUser objuser = new AdminUser();
            List<AdminUser> users1 = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();
                obju.PostJobCode = ds.Tables[0].Rows[i]["PostJobCode"].ToString();
                obju.JobTitle = ds.Tables[0].Rows[i]["JobTitle"].ToString();
                obju.JobDescription = ds.Tables[0].Rows[i]["JobDescription"].ToString();
                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[i]["ApplicationStartDate"].ToString());
                obju.Rdate = date.ToShortDateString();

                //obju.ApplicationStartDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ApplicationStartDate"].ToString());
                //obju.StatusId = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusId"].ToString());
                obju.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                users1.Add(obju);
            }
            objuser.Users = users1;
            return await Task.Run(() => View(objuser));
        }

        public ActionResult Update(AdminUser obj, string PostJobCode)
        {
            obj.StatusId = 9;
            //obj.PostJobCode = PostJobCode;
            //if (ViewBag.Approve == true)
            //{
            //    obj.StatusId = 9;
            //}
            //else
            //{
            //    obj.StatusId = 10;
            //}
            BALAdmin obj1 = new BALAdmin();
            obj1.RPUpdateJobStatusApprovle(obj);
            return RedirectToAction("ApplicationApprovel");
        }
        public ActionResult UpdateReject(AdminUser obj)
        {
            obj.StatusId = 10;

            BALAdmin obj1 = new BALAdmin();
            obj1.RPUpdateJobStatusApprovle(obj);
            return RedirectToAction("ApplicationApprovel");
        }


        [HttpGet]
        public async Task<ActionResult> Details(string PostJobCode)
        {
            AdminUser obj = new AdminUser();
            obj.PostJobCode = PostJobCode;
            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.RPJobDetails(obj);
            while (dr.Read())
            {
                obj.CompanyLogo = dr["CompanyLogo"].ToString();
                obj.CompanyName = dr["CompanyName"].ToString();
                obj.ContactPerson = dr["ContactPerson"].ToString();
                obj.JobTitle = dr["JobTitle"].ToString();
                obj.JobDescription = dr["JobDescription"].ToString();
                obj.JobCategory = dr["JobCategory"].ToString();
                obj.OpportunityType = dr["OpportunityType"].ToString();
                obj.WorkingShifts = dr["WorkingShifts"].ToString();
                obj.NoOfOpenings = dr["NoOfOpenings"].ToString();
                obj.Address = dr["Address"].ToString();
                obj.Salary = dr["Salary"].ToString();
                obj.TotalExperience = dr["TotalExperience"].ToString();
                obj.JobType = dr["JobType"].ToString();
                obj.ExpectedJoiningDate = dr["ExpectedJoiningDate"].ToString();
                obj.ApplicationEndDate = dr["ApplicationEndDate"].ToString();

            }
            dr.Close();
            return await Task.Run(() => PartialView(obj));

        }

        [HttpGet]
        public async Task<ActionResult> RejectionReason(string PostJobCode)
        {
            AdminUser obj = new AdminUser();
            obj.PostJobCode = PostJobCode;
            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.RejectStatusGet(obj);
            while (dr.Read())
            {
                obj.PostJobCode = dr["PostJobCode"].ToString();
                obj.JobTitle = dr["JobTitle"].ToString();
                obj.JobDescription = dr["JobDescription"].ToString();
                obj.ApplicationStartDate = Convert.ToDateTime(dr["ApplicationStartDate"].ToString());
                //obju.StatusId = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusId"].ToString());
                obj.Status = dr["Status"].ToString();

            }
            dr.Close();
            return await Task.Run(() => PartialView(obj));

        }
        //[HttpGet]
        //public ActionResult RejectionReason1()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult RejectionReason1(AdminUser obj)
        {
            obj.StatusId = 10;
            BALAdmin obj1 = new BALAdmin();
            obj1.RPUpdatejobRejectionReason(obj);
            return RedirectToAction("ApplicationApprovel");
        }

        //-----------------------------------Admin Company Reviews-----------------------------------------------------------/
        [HttpGet]
        public async Task<ActionResult> RPCompanyGridview()
        {
            //AdminUser obj1 = new AdminUser();
            //obj1.ReviewId = reviewId;
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.RPCompanyGridview();
            AdminUser objuser = new AdminUser();
            List<AdminUser> users1 = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();
                obju.ReviewId = Convert.ToInt32(ds.Tables[0].Rows[i]["ReviewId"].ToString());
                obju.CompanyName = ds.Tables[0].Rows[i]["CompanyName"].ToString();
                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[i]["RegistrationDate"].ToString());
                obju.Rdate = date.ToShortDateString();
                obju.AboutCompany = ds.Tables[0].Rows[i]["AboutCompany"].ToString();
                obju.Rating = ds.Tables[0].Rows[i]["Rating"].ToString();
                obju.Review = ds.Tables[0].Rows[i]["Review"].ToString();
                obju.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                users1.Add(obju);
            }
            objuser.Users = users1;
            return await Task.Run(() => View(objuser));
        }
        [HttpGet]
        public ActionResult RPCompanyIsDelete(AdminUser obj, int ReviewId)
        {
            // obj.isDelete = 1;
            obj.ReviewId = ReviewId;
            BALAdmin obj1 = new BALAdmin();
            obj1.RPCompanyIsDelete(obj);
            return RedirectToAction("RPCompanyGridview");
        }
        public ActionResult RPCompanyReviewStatusApprove(AdminUser obj)
        {
            obj.StatusId = 9;

            BALAdmin obj1 = new BALAdmin();
            obj1.RPCompanyReviewStatusUpdate(obj);
            return RedirectToAction("RPCompanyGridview");
        }
        public ActionResult RPCompanyReviewStatusReject(AdminUser obj)
        {
            obj.StatusId = 10;

            BALAdmin obj1 = new BALAdmin();
            obj1.RPCompanyReviewStatusUpdate(obj);
            return RedirectToAction("RPCompanyGridview");
        }
        [HttpGet]
        public async Task<ActionResult> RPCompanyGridviewDetails(int ReviewId)
        {
            AdminUser obj = new AdminUser();
            obj.ReviewId = ReviewId;
            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.RPCompanyGridviewDetails(obj);
            while (dr.Read())
            {
                obj.ReviewId = Convert.ToInt32(dr["ReviewId"].ToString());
                obj.CompanyName = dr["CompanyName"].ToString();
                DateTime date = Convert.ToDateTime(dr["RegistrationDate"].ToString());
                obj.Rdate = date.ToShortDateString();
                //obj.RegistrationDate = Convert.ToDateTime(dr["RegistrationDate"].ToString());
                obj.AboutCompany = dr["AboutCompany"].ToString();
                obj.Rating = dr["Rating"].ToString();
                obj.Review = dr["Review"].ToString();
                obj.Status = dr["Status"].ToString();

            }
            dr.Close();
            return await Task.Run(() => PartialView(obj));

        }

        // --------------------Admin--Employers-----------//

        public async Task<ActionResult> RPAdminEmployeGrid()
        {
            //var list = new List<string>() { "Active","Inactive","Hold" };
            //ViewBag.list = list;
            // dropdownlist();
            RPGetStatus();
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.RPAdminEmployeGrid();
            AdminUser objuser = new AdminUser();
            List<AdminUser> users1 = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();
                obju.Employercode = ds.Tables[0].Rows[i]["EmployerCode"].ToString();
                obju.EmployerName = ds.Tables[0].Rows[i]["EmployerName"].ToString();
                obju.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                obju.SubscriptionName = ds.Tables[0].Rows[i]["SubscriptionName"].ToString();
               

                //string date = (ds.Tables[0].Rows[i]["SubscriptionDate"].ToString());
                //DateTime SubscriptionDuration = Convert.ToDateTime(date);

                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[i]["SubscriptionDate"].ToString());
                obju.subDate = date.ToShortDateString();

             //   obju.SubscriptionDate = Convert.ToDateTime(SubscriptionDuration.ToShortDateString());
                //DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[i]["SubscriptionDate"].ToString());
                //obju.Rdate = date.ToShortDateString();
                obju.SubscriptionDuration = ds.Tables[0].Rows[i]["SubscriptionDuration"].ToString();
                obju.Status = ds.Tables[0].Rows[i]["Status"].ToString();

               

                users1.Add(obju);
            }
            objuser.Users = users1;
            //ViewBag.Status = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Value="Select",Text="Select"},
            //    new SelectListItem(){Value="Active",Text="Active"},
            //    new SelectListItem(){Value="InActive",Text="InActive"},
            //     new SelectListItem(){Value="Hold",Text="Hold"}
            //};
            return await Task.Run(() => View(objuser));
        }
        public ActionResult dropdownlist()
        {


            //var items = new List<string>(){ "Active","Inactive","Hold"};
            //ViewBag.Status = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Value= null,Text="Select"},
            //    new SelectListItem(){Value="Active",Text="Active"},
            //    new SelectListItem(){Value="InActive",Text="InActive"},
            //     new SelectListItem(){Value="Hold",Text="Hold"}
            //};

            //List<SelectListItem> items = new List<SelectListItem>();

            //items.Add(new SelectListItem { Text = "Select", Value = "Select" });
            //items.Add(new SelectListItem { Text = "Active", Value = "Active" });
            //items.Add(new SelectListItem { Text = "In Active", Value = "In Active" });
            //items.Add(new SelectListItem { Text = "Hold", Value = "Hold" });



            return View();
        }
        public void RPGetStatus()
        {
            BALAdmin objbal = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objbal.RPGetStatus();
            List<SelectListItem> countryList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                countryList.Add(new SelectListItem
                {
                    Text = ds.Tables[0].Rows[i][1].ToString(),
                    Value = ds.Tables[0].Rows[i][0].ToString()
                });
                ViewBag.slist = countryList;

            }
        }

        public ActionResult EmployerStatus(AdminUser obj)
        {
            if (obj.StatusId == 1)
            {
                BALAdmin obj1 = new BALAdmin();
                obj1.RPPaymentStatusUpdate(obj);
            }
            if (obj.StatusId == 2)
            {
                BALAdmin obj1 = new BALAdmin();
                obj1.RPPaymentStatusUpdate(obj);
            }
            if (obj.StatusId == 3)
            {
                BALAdmin obj1 = new BALAdmin();
                obj1.RPPaymentStatusUpdate(obj);
            }

            return RedirectToAction("RPAdminEmployeGrid");
            //BALAdmin obj1 = new BALAdmin();
            //obj1.RPPaymentStatusUpdate(obj.Employercode,obj.)
            //return View();
        }
        ///------------Admin jobs-------------------///
        [HttpGet]
        public async Task<ActionResult> RPAdminJobsGrid()
        {
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.RPAdminJobsGrid();
            AdminUser objuser = new AdminUser();
            List<AdminUser> users1 = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();
                obju.CompanyName = ds.Tables[0].Rows[i]["CompanyName"].ToString();
                obju.JobTitle = ds.Tables[0].Rows[i]["JobTitle"].ToString();
                obju.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                obju.applicationcount = ds.Tables[0].Rows[i]["applicationcount"].ToString();               
                obju.Hire = ds.Tables[0].Rows[i]["hire"].ToString();

                users1.Add(obju);
            }
            objuser.Users = users1;
            return await Task.Run(() => View(objuser));
        }
        [HttpGet]
        public async Task<ActionResult> siteEarningE()
        {

            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.SiteEarningEmp();
            AdminUser objuser = new AdminUser();
            List<AdminUser> User = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();

                //obju.SubscriptionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubscriptionId"].ToString());
                obju.Employercode = ds.Tables[0].Rows[i]["EmployerCode"].ToString();
                //obju.HRName = ds.Tables[0].Rows[i]["HRName"].ToString();
                //obju.CompanyName = ds.Tables[0].Rows[i]["CompanyName"].ToString();
                obju.SubscriptionName = ds.Tables[0].Rows[i]["SubscriptionName"].ToString();

                obju.SubscriptionDuration = ds.Tables[0].Rows[i]["SubscriptionDuration"].ToString();
                obju.Offer = Convert.ToInt32(ds.Tables[0].Rows[i]["Offer"].ToString());
                obju.PlanPricing = Convert.ToInt64(ds.Tables[0].Rows[i]["PlanPricing"].ToString());
                obju.OfferedPrice = Convert.ToInt64(ds.Tables[0].Rows[i]["OfferedPrice"].ToString());
                User.Add(obju);
            }
            objuser.User = User;
            BALAdmin objE = new BALAdmin();
            DataSet ds1 = new DataSet();

            ds1 = objE.TotalAmountE();
            @ViewBag.TotalAmount = ds1.Tables[0].Rows[0]["TotalEmpAmount"].ToString();


            BALAdmin objee = new BALAdmin();
            DataSet ds2 = new DataSet();

            ds2 = objE.MonthlyEarningE();
            @ViewBag.Currentmonth = ds2.Tables[0].Rows[0]["CurrentMonth"].ToString();
            return await Task.Run(() => View(objuser));
        }


        [HttpGet]
        public async Task<ActionResult> siteEarningS()
        {
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.SiteEarningSeeker();
            AdminUser objuser = new AdminUser();
            List<AdminUser> User = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();

                obju.Seekercode = ds.Tables[0].Rows[i]["SeekerCode"].ToString();
                obju.SubscriptionName = ds.Tables[0].Rows[i]["SubscriptionName"].ToString();
                obju.SubscriptionDuration = ds.Tables[0].Rows[i]["SubscriptionDuration"].ToString();
                obju.Offer = Convert.ToInt32(ds.Tables[0].Rows[i]["Offer"].ToString());
                obju.PlanPricing = Convert.ToInt64(ds.Tables[0].Rows[i]["PlanPricing"].ToString());
                obju.OfferedPrice = Convert.ToInt64(ds.Tables[0].Rows[i]["OfferedPrice"].ToString());



                User.Add(obju);
            }
            objuser.Users = User;
            objuser.User = User;
            BALAdmin objE = new BALAdmin();
            DataSet ds1 = new DataSet();

            ds1 = objE.TotalAmountS();
            @ViewBag.TotalAmount = ds1.Tables[0].Rows[0]["TotalSeekAmount"].ToString();

            BALAdmin objee = new BALAdmin();
            DataSet ds2 = new DataSet();

            ds2 = objE.MonthlyEarningS();
            @ViewBag.Currentmonth = ds2.Tables[0].Rows[0]["CurrentMonth"].ToString();
            return await Task.Run(() => View(objuser));

            return await Task.Run(() => View(objuser));

        }
        //------------------------Mitali Start---------------------------//
        [HttpGet]
        public ActionResult Subscription()
        {
            AllList();
            DurationList();
            GetBenefits();
            return view();
        }
        [HttpPost]
        public ActionResult Subscription(AdminUser subscription)
        {

            AdminUser subp = new AdminUser();
            BALAdmin objB = new BALAdmin();
            // subscription.SubscriptionDuration = subscription.From + " - " + subscription.To;
            subscription.OfferedPrice = subscription.PlanPricing - (subscription.PlanPricing * subscription.Offer / 100);
            subscription.Benefits = string.Join(",", subscription.BenifitList);
            objB.Subscription(subscription);
            return RedirectToAction("Plangrid");


        }
        public async Task<ActionResult> AllList()                                                                // hardcoded dropdown
        {
            var list = new List<string>() { "Employer", "JobSeeker" };
            ViewBag.Category = list;
            return await Task.Run(() => View());
        }


        [HttpGet]
        public ActionResult AddBenefits()
        {

            return view();
        }
        [HttpPost]
        public ActionResult AddBenefits(AdminUser benefit)
        {
            AdminUser subp = new AdminUser();
            BALAdmin objB = new BALAdmin();
            objB.AddBenefits(benefit);
            return RedirectToAction("Subscription");


        }
        public async Task<ActionResult> GetBenefits()                        //multiselect dropdown
        {
            BALAdmin objB = new BALAdmin();
            EmployerUser obj = new EmployerUser();
            DataSet ds = objB.GetBenefits();
            List<SelectListItem>
            BenifitList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BenifitList.Add(new SelectListItem
                {
                    Text = dr["Benefits"].ToString(),
                    Value = dr["BenefitId"].ToString()
                });
            }
            ViewBag.BenifitList = new SelectList(BenifitList, "Value", "Text");
            return await Task.Run(() => View());
        }
        public async Task<ActionResult> Plangrid()
        {
            BALAdmin plan = new BALAdmin();
            DataSet ds = new DataSet();
            ds = plan.PlanGrid();
            AdminUser users = new AdminUser();
            List<AdminUser> planlst = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser user = new AdminUser();
                user.SubscriptionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubscriptionId"].ToString());
                user.SubscriptionName = ds.Tables[0].Rows[i]["SubscriptionName"].ToString();
                //   user.Benefits = ds.Tables[0].Rows[i]["Benefits"].ToString();
                user.PlanPricing = Convert.ToInt64(ds.Tables[0].Rows[i]["PlanPricing"].ToString());
                user.Offer = Convert.ToInt32(ds.Tables[0].Rows[i]["Offer"].ToString());
                user.OfferedPrice = Convert.ToInt64(ds.Tables[0].Rows[i]["OfferedPrice"].ToString());
                planlst.Add(user);
            }
            users.planlist = planlst;
            // result = jobgridlst.Where(a => a.Address.ToLower().Contains(searchtext));
            return await Task.Run(() => View(users));

        }
        [HttpGet]
        public async Task<ActionResult> PlanDetails(int SubscriptionId)
        {
            AdminUser objA = new AdminUser();
            objA.SubscriptionId = SubscriptionId;
            BALAdmin obj2 = new BALAdmin();
            SqlDataReader dr;
            dr = obj2.PlanDetails(objA);
            while (dr.Read())
            {
                objA.SubscriptionId = Convert.ToInt32(dr["SubscriptionId"].ToString());
                objA.SubscriptionName = dr["SubscriptionName"].ToString();
                objA.Benefits = dr["Benefits"].ToString();
                objA.SubscriptionDuration = dr["SubscriptionDuration"].ToString();
                objA.SubscriptionDetails = dr["SubscriptionDetails"].ToString();
                objA.PlanPricing = Convert.ToInt64(dr["PlanPricing"].ToString());
                objA.Offer = Convert.ToInt32(dr["Offer"].ToString());
                objA.OfferedPrice = Convert.ToInt64(dr["OfferedPrice"].ToString());
                objA.Benefits = dr["Benefits"].ToString();

            }
            dr.Close();
            var bbbbb = objA.Benefits;
            char[] seprator = { ',' };
            string[] ben = null;
            ben = bbbbb.Split(seprator);
            string benifit1 = null;
            string benifit2 = null;
            AdminUser obbj = new AdminUser();
            BALAdmin fun = new BALAdmin();
            for (int i = 0; i < ben.Length; i++)
            {
                DataSet ds2 = new DataSet();
                int BenifitsId = Convert.ToInt32(ben[i]);
                ds2 = fun.getbenifits(BenifitsId);
                benifit1 = ds2.Tables[0].Rows[0][0].ToString();

                if (i == ben.Length - 1)
                {
                    benifit2 = string.Concat(benifit2, benifit1);
                }
                else
                {
                    benifit2 = string.Concat(benifit2, benifit1, " ✔");
                }
                objA.Benefits = benifit2;
            }
            return await Task.Run(() => View(objA));
        }
        [HttpGet]
        public async Task<ActionResult> EditPlan(int SubscriptionId)
        {

            DurationList();
            GetBenefits();
            TempData["SubscriptionId"] = SubscriptionId;
            AdminUser objA = new AdminUser();
            objA.SubscriptionId = SubscriptionId;
            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.PlanDetails(objA);
            while (dr.Read())
            {
                AdminUser user = new AdminUser();
                objA.SubscriptionId = Convert.ToInt32(dr["SubscriptionId"].ToString());
                objA.SubscriptionName = dr["SubscriptionName"].ToString();
                objA.Benefits = dr["Benefits"].ToString();
                objA.SubscriptionDuration = dr["SubscriptionDuration"].ToString();
                objA.SubscriptionDetails = dr["SubscriptionDetails"].ToString();
                objA.PlanPricing = Convert.ToInt64(dr["PlanPricing"].ToString());
                objA.Offer = Convert.ToInt32(dr["Offer"].ToString());
                objA.OfferedPrice = Convert.ToInt64(dr["OfferedPrice"].ToString());

            }
            dr.Close();
            ViewBag.SubscriptionDetails = objA.SubscriptionDetails;


            return await Task.Run(() => View(objA));
        }

        [HttpPost]
        public async Task<ActionResult> EditPlan(AdminUser objA)
        {
            if (TempData.ContainsKey("SubscriptionId"))
                SubscriptionId = Convert.ToInt32(TempData["SubscriptionId"].ToString());
            objA.SubscriptionId = SubscriptionId;
            //AdminUser obj = new AdminUser();
            //objA.SubscriptionId=SubscriptionId;
            BALAdmin obj1 = new BALAdmin();
            objA.OfferedPrice = objA.PlanPricing - (objA.PlanPricing * objA.Offer / 100);
            objA.Benefits = string.Join(",", objA.BenifitList);
            obj1.UpdatePlan(objA);


            return await Task.Run(() => RedirectToAction("Plangrid"));

        }

        public async Task<ActionResult> DurationList()                                                                // hardcoded dropdown
        {
            var list = new List<string>() { "1 Month", "3 Month", "6 Month", " 1 Year" };
            ViewBag.DurationList = list;
            return await Task.Run(() => View());
        }

        public ActionResult DeletePlan(AdminUser obj, int SubscriptionId)
        {

            obj.SubscriptionId = SubscriptionId;
            BALAdmin obj1 = new BALAdmin();
            obj1.DeletePlan(obj);
            return RedirectToAction("Plangrid");
        }
        public async Task<ActionResult> Jobseekargrid()
        {
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.Jobseekargrid();
            AdminUser objuser = new AdminUser();
            List<AdminUser> users1 = new List<AdminUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AdminUser obju = new AdminUser();
                obju.Seekercode = ds.Tables[0].Rows[i]["SeekerCode"].ToString();
                obju.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                obju.SeekerName = ds.Tables[0].Rows[i]["SeekerName"].ToString();
                obju.ContactNo = Convert.ToInt64(ds.Tables[0].Rows[i]["ContactNo"].ToString());
                obju.Designation = ds.Tables[0].Rows[i]["Designation"].ToString();
                string Rdate = (ds.Tables[0].Rows[i]["SubscriptionDate"].ToString());
                obju.Rdate = Rdate;
                //   DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[i]["SubscriptionDate"].ToString());
                //   obju.Rdate = date.ToShortDateString();
                obju.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                users1.Add(obju);
            }
            objuser.Users = users1;
            return await Task.Run(() => View(objuser));
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Account");
        }
    }
}