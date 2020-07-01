using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZNMS.Model;

namespace ZNMS.Registered.Web
{
    public partial class Registered : System.Web.UI.Page
    {
        public DevInfo  registeredInfo { get; set; }
        public string msg { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.DevInfoBll registeredInfoBll = new BLL.DevInfoBll();
            registeredInfo = new DevInfo();

            string imei = Request.QueryString["IMEI"];
            int xmbh = Convert.ToInt32(Request.QueryString["XMBH"]);

            registeredInfo.IMEI = imei;
            registeredInfo.XMBH = xmbh;

            if (!IsPostBack)
            {
                registeredInfo.AZSJ = DateTime.Now;

                if (imei != null)
                {
                    if (registeredInfoBll.GetRegisteredInfo(imei, xmbh) != null)
                    {
                        registeredInfo = registeredInfoBll.GetRegisteredInfo(imei, xmbh);
                    }
                }
            }
            else
            {
                if (imei != null)
                {
                    try
                    {
                        if (!registeredInfoBll.IsGetRegisteredInfo(imei))
                        {
                            registeredInfo.XMBH = Convert.ToInt32(Request.Form["myXMBH"]);
                            registeredInfo.SBXMMC = Request.Form["mySBXMMC"];
                            registeredInfo.XMDZ = Request.Form["myXMDZ"];
                            registeredInfo.DJRLXFS = Request.Form["myDJRLXFS"];
                            registeredInfo.AZRY = Request.Form["myAZRY"];
                            registeredInfo.AZSJ = DateTime.Now;
                            registeredInfo.AZDW = Request.Form["myAZDW"];
                            registeredInfo.SBLX = Request.Form["mySBLX"];
                            registeredInfo.SBBH = Request.Form["mySBBH"];
                            registeredInfo.IMEI = Request.Form["myIMEI"];
                            registeredInfo.CCID = Request.Form["myCCID"];
                            registeredInfo.NBKH = Request.Form["myNBKH"];
                            registeredInfo.NBYXQ = Request.Form["myNBYXQ"];
                            registeredInfo.EX1 = Request.Form["myEX1"];
                            registeredInfo.EX2 = Request.Form["myEX2"];
                            registeredInfo.EX3 = Request.Form["myEX3"];
                            registeredInfo.BZ = Request.Form["myBZ"];

                            if (registeredInfoBll.InsertRegisteredInfo(registeredInfo))
                            {
                                MsgBox("注册成功！！");
                            }
                            else
                            {
                                MsgBox("注册失败！！");
                            }
                        }
                        else
                        {
                            registeredInfo = registeredInfoBll.GetRegisteredInfo(imei, xmbh);
                            MsgBox("已注册！！");
                        }
                    }
                    catch { MsgBox("注册失败！！"); }
                }
                else
                {
                    MsgBox("注册失败！！");

                }
            }
        }

        /// <summary>
        /// 页面显示信息
        /// </summary>
        /// <param name="msg"></param>
        private void MsgBox(string msg)
        {
            string strScript = "<script language='Javascript'>alert('" + msg + "');</script>";
            Page.RegisterStartupScript("alert", strScript);
        }
    }
}