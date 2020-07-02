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

            string devImei = Request.QueryString["devImei"];
            string projNumber = Request.QueryString["ProjNumber"];

            registeredInfo.Dev_Imei = devImei;
            registeredInfo.Proj_Number = projNumber;

            if (!IsPostBack)
            {
                registeredInfo.Install_Time = DateTime.Now;

                if (devImei != null)
                {
                    if (registeredInfoBll.GetRegisteredInfo(devImei, projNumber) != null)
                    {
                        registeredInfo = registeredInfoBll.GetRegisteredInfo(devImei, projNumber);
                    }
                }
            }
            else
            {
                if (devImei != null)
                {
                    try
                    {
                        if (!registeredInfoBll.IsGetRegisteredInfo(devImei))
                        {
                            registeredInfo.Proj_Name = Request.Form["Proj_Name_Web"];
                            registeredInfo.Proj_Number = Request.Form["Proj_Number_Web"];
                            registeredInfo.Proj_Address = Request.Form["Proj_Address_Web"];
                            registeredInfo.Proj_Link = Request.Form["Proj_Link_Web"];
                            registeredInfo.Install_Man = Request.Form["Install_Man_Web"];
                            registeredInfo.Install_Time = DateTime.Now;
                            registeredInfo.Install_Address = Request.Form["Install_Address_Web"];
                            registeredInfo.Dev_Type = Request.Form["Dev_Type_Web"];
                            registeredInfo.Dev_Factory = Request.Form["Dev_Factory_Web"];
                            registeredInfo.Dev_Brand = Request.Form["Dev_Brand_Web"];
                            registeredInfo.Dev_Model = Request.Form["Dev_Model_Web"];
                            registeredInfo.Dev_Price = Request.Form["Dev_Price_Web"];
                            registeredInfo.Dev_Number = Request.Form["Dev_Number_Web"];
                            registeredInfo.Dev_Imei = Request.Form["Dev_Imei_Web"];
                            registeredInfo.Dev_Ccid = Request.Form["Dev_Ccid_Web"];
                            registeredInfo.Dev_NB_Number = Request.Form["Dev_NB_Number_Web"];
                            registeredInfo.Dev_NB_ExpirationDate = Request.Form["Dev_NB_ExpirationDate_Web"];
                            registeredInfo.Dev_Ex1 = string.Empty;
                            registeredInfo.Dev_Ex2 = string.Empty;
                            registeredInfo.Dev_Ex3 = string.Empty;
                            registeredInfo.Remarks = Request.Form["Remarks_Web"];

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
                            registeredInfo = registeredInfoBll.GetRegisteredInfo(devImei, projNumber);
                            MsgBox("已注册！！");
                        }
                    }
                    catch(Exception EX) { MsgBox("注册失败！！"); }
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