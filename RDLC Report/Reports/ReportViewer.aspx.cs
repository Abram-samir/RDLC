﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDLC_Report.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            var reportParam = (dynamic)HttpContext.Current.Session["ReportParam"];
            if (reportParam!=null&&!string.IsNullOrEmpty(reportParam.RptFileName))
            {
                Page.Title = "Report|" + reportParam.ReportTitle;
                var dt = new DataTable();
                dt = reportParam.DataSource;
                if (dt.Rows.Count>0)
                {
                    GenerateReportDocument(reportParam,reportParam.ReportType,dt);
                }
                else
                {
                    showErrorMessage();
                }
            }
        }
        public void GenerateReportDocument(dynamic reportParam,string reportType,DataTable data)
        {
            string dsName = reportParam.DataSetName;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(dsName,data));
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~" + "/Reports//rpt//" + reportParam.RptFileName);
            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.Refresh();
        }
        public void showErrorMessage()
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("",new DataTable()));
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/" + "Reports//rpt//blank.rdlc" );
            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.Refresh();
        }
    }
}