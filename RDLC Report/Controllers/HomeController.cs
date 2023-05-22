using RDLC_Report.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDLC_Report.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public void GetEmployeeReport()
        {
            ReportParams objReportParams = new ReportParams();
            var data = GetEmployeeInfo();
            objReportParams.DataSource = data.Tables[0];
            objReportParams.ReportTitle = "Employee Info Report";
            objReportParams.RptFileName = "";
            objReportParams.ReportType = "EmployeeInfoReport";
            objReportParams.DataSetName = "dsEmployeeReport";
            this.HttpContext.Session["ReportParam"] = objReportParams;

        }

        private DataSet GetEmployeeInfo()
        {
            string constr = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
            DataSet ds = new DataSet();
            string sql = "select * from Employee";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            return ds;
        }
    }
}