using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZNMS.Model;

namespace ZNMS.Registered.Web
{
    /// <summary>
    /// ChangeInfo 的摘要说明
    /// </summary>
    public class ChangeInfo : IHttpHandler
    {
        string devImei = "";
        string projNumber = "";
        DevInfo registeredInfo = null;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.DevInfoBll registeredInfoBll = new BLL.DevInfoBll();
            try
            {
                devImei = context.Request.Form["Dev_Imei_Web"].Trim();
                projNumber = context.Request.Form["Proj_Number_Web"].Trim();
                registeredInfo = registeredInfoBll.GetRegisteredInfo(devImei, projNumber);

                if (registeredInfo != null)
                {
                    registeredInfo.Proj_Name = context.Request.Form["Proj_Name_Web"];
                    registeredInfo.Proj_Number = context.Request.Form["Proj_Number_Web"];
                    registeredInfo.Proj_Address = context.Request.Form["Proj_Address_Web"];
                    registeredInfo.Proj_Link = context.Request.Form["Proj_Link_Web"];
                    registeredInfo.Install_Man = context.Request.Form["Install_Man_Web"];
                    registeredInfo.Install_Time = DateTime.Now;
                    registeredInfo.Install_Address = context.Request.Form["Install_Address_Web"];
                    registeredInfo.Dev_Type = context.Request.Form["Dev_Type_Web"];
                    registeredInfo.Dev_Factory = context.Request.Form["Dev_Factory_Web"];
                    registeredInfo.Dev_Brand = context.Request.Form["Dev_Brand_Web"];
                    registeredInfo.Dev_Model = context.Request.Form["Dev_Model_Web"];
                    registeredInfo.Dev_Price = context.Request.Form["Dev_Price_Web"];
                    registeredInfo.Dev_Number = context.Request.Form["Dev_Number_Web"];
                    registeredInfo.Dev_Imei = context.Request.Form["Dev_Imei_Web"];
                    registeredInfo.Dev_Ccid = context.Request.Form["Dev_Ccid_Web"];
                    registeredInfo.Dev_NB_Number = context.Request.Form["Dev_NB_Number_Web"];
                    registeredInfo.Dev_NB_ExpirationDate = context.Request.Form["Dev_NB_ExpirationDate_Web"];
                    registeredInfo.Dev_Ex1 = "1";  //注册：1，修改：2，验收：3
                    registeredInfo.Dev_Ex2 = string.Empty;
                    registeredInfo.Dev_Ex3 = string.Empty;
                    registeredInfo.Remarks = context.Request.Form["Remarks_Web"];

                    if (registeredInfoBll.UpdateRegisteredInfo(registeredInfo))
                    {
                        Alert("修改成功！！");
                    }
                    else
                    {
                        Alert("修改失败！！");
                    }
                }
                else
                {
                    Alert("修改失败！！");
                }
            }
            catch { Alert("修改失败！！"); }
        }

        public void Alert(string message)
        {
            ResponseScript("alert('" + message + "');window.location = 'Registered.aspx?DevImei=" + devImei + "&ProjNumber=" + projNumber + "';");
        }
        public void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n//<![CDATA[\n");
            HttpContext.Current.Response.Write(script);
            HttpContext.Current.Response.Write("\n//]]>\n</script>\n");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}