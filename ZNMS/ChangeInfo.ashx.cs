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
        string imei = "";
        int xmbh = 0;
        DevInfo registeredInfo = null;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.DevInfoBll registeredInfoBll = new BLL.DevInfoBll();
            try
            {
                imei = context.Request.Form["myImei"].Trim();
                xmbh = Convert.ToInt32(context.Request.Form["myXMBH"]);
                registeredInfo = registeredInfoBll.GetRegisteredInfo(imei, xmbh);

                if (registeredInfo != null)
                {
                    registeredInfo.XMBH = Convert.ToInt32(context.Request.Form["myXMBH"]);
                    registeredInfo.SBXMMC = context.Request.Form["mySBXMMC"];
                    registeredInfo.XMDZ = context.Request.Form["myXMDZ"];
                    registeredInfo.DJRLXFS = context.Request.Form["myDJRLXFS"];
                    registeredInfo.AZRY = context.Request.Form["myAZRY"];
                    registeredInfo.AZSJ = DateTime.Now;
                    registeredInfo.AZDW = context.Request.Form["myAZDW"];
                    registeredInfo.SBLX = context.Request.Form["mySBLX"];
                    registeredInfo.SBBH = context.Request.Form["mySBBH"];
                    registeredInfo.IMEI = context.Request.Form["myIMEI"];
                    registeredInfo.CCID = context.Request.Form["myCCID"];
                    registeredInfo.NBKH = context.Request.Form["myNBKH"];
                    registeredInfo.NBYXQ = context.Request.Form["myNBYXQ"];
                    registeredInfo.EX1 = context.Request.Form["myEX1"];
                    registeredInfo.EX2 = context.Request.Form["myEX2"];
                    registeredInfo.EX3 = context.Request.Form["myEX3"];
                    registeredInfo.BZ = context.Request.Form["myBZ"];

                    string a = registeredInfo.ID.ToString();
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
            catch
            { Alert("修改失败！！"); }
        }

        public void Alert(string message)
        {
            //ResponseScript("alert('" + message + "');window.location = 'Registered.aspx?IMEI=" + imei + "'&XMBH=" + xmbh + "';");
            ResponseScript("alert('" + message + "');window.location = 'Registered.aspx?IMEI=" + imei + "&XMBH=" + xmbh + "';");
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