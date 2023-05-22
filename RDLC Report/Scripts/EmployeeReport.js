$(document).ready(function () {
    $("#btnGenerate").click(function () {
        ReportManger.GenerateReport();
    });
});

var ReportManger = {
    GenerateReport: function () {
        var jsonParam = "";
        var serviceUrl = "../Home/GetEmployeeReport";
        ReportManger.GetReport(serviceUrl, jsonParam, onFailed);
        function onFailed(error) {
            alert(error);
        }
    },
    GetReport: function (serviceUrl, jsonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json;charset=utf-8",
            success: function () {
                window.open('../Reports/ReportViewer.aspx', '_newtab');
            },
            error:errorCallback
        })
    }
};

var ReprotHelper = {

};