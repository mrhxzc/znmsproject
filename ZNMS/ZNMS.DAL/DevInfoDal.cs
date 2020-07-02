using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNMS.Model;

namespace ZNMS.DAL
{
    public class DevInfoDal
    {
        /// <summary>
        /// 查询并返回一条记录
        /// </summary>
        /// <param name="devImei">IMEI值</param>
        /// <param name="projNumber">项目编号</param>
        /// <returns>注册信息</returns>
        public DevInfo GetInfo(string devImei, string projNumber)
        {
            string sql = "select ID,Install_Man,Install_Time,Install_Address,Dev_Type,Dev_Factory,Dev_Brand,Dev_Model,Dev_Price,Dev_Number,Dev_Imei,Dev_Ccid,Dev_NB_Number,Dev_NB_ExpirationDate,Dev_Ex1,Dev_Ex2,Dev_Ex3,Remarks from DevInfo where Dev_Imei=@Dev_Imei";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Dev_Imei", devImei));
            DevInfo devInfo = new DevInfo();
            if (da.Rows.Count > 0)
            {
                LoadDevInfo(da.Rows[0], devInfo);
            }
            else
            {
                devInfo.Dev_Imei = devImei;
                devInfo.Install_Time = DateTime.Now;
            }

            sql = "select TOP 1 Proj_Name,Proj_Number,Proj_Address,Proj_Link from DevInfo where Proj_Number=@Proj_Number";
            DataTable dabh = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Proj_Number", projNumber));
            if (dabh.Rows.Count > 0)
            {
                LoadProjectInfo(dabh.Rows[0], devInfo);
            }
            else
            {
                devInfo.Proj_Number = projNumber;
            }
            return devInfo;
        }

        /// <summary>
        /// 查询并返回一条记录（Imei）
        /// </summary>
        /// <param name="devImei"></param>
        /// <returns></returns>
        public DevInfo GetInfo(string devImei)
        {
            string sql = "select * from DevInfo where Dev_Imei=@Dev_Imei";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Dev_Imei", devImei));
            DevInfo devInfo = null;
            if (da.Rows.Count > 0)
            {
                devInfo = new DevInfo();
                LoadDevInfo(da.Rows[0], devInfo);
            }
            return devInfo;
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="devInfo"></param>
        /// <returns></returns>
        public int InsertInfo(DevInfo devInfo)
        {
            string sql = "insert into DevInfo(Proj_Name,Proj_Number,Proj_Address,Proj_Link,Install_Man,Install_Time,Install_Address,Dev_Type,Dev_Factory,Dev_Brand,Dev_Model,Dev_Price,Dev_Number,Dev_Imei,Dev_Ccid,Dev_NB_Number,Dev_NB_ExpirationDate,Dev_Ex1,Dev_Ex2,Dev_Ex3,Remarks) values(@Proj_Name,@Proj_Number,@Proj_Address,@Proj_Link,@Install_Man,@Install_Time,@Install_Address,@Dev_Type,@Dev_Factory,@Dev_Brand,@Dev_Model,@Dev_Price,@Dev_Number,@Dev_Imei,@Dev_Ccid,@Dev_NB_Number,@Dev_NB_ExpirationDate,@Dev_Ex1,@Dev_Ex2,@Dev_Ex3,@Remarks)";

            SqlParameter[] pars = {
                                      new SqlParameter("@Proj_Name",devInfo.Proj_Name),
                                      new SqlParameter("@Proj_Number",devInfo.Proj_Number),
                                      new SqlParameter("@Proj_Address",devInfo.Proj_Address),
                                      new SqlParameter("@Proj_Link",devInfo.Proj_Link),
                                      new SqlParameter("@Install_Man",devInfo.Install_Man),
                                      new SqlParameter("@Install_Time",devInfo.Install_Time),
                                      new SqlParameter("@Install_Address",devInfo.Install_Address),
                                      new SqlParameter("@Dev_Type",devInfo.Dev_Type),
                                      new SqlParameter("@Dev_Factory",devInfo.Dev_Factory),
                                      new SqlParameter("@Dev_Brand",devInfo.Dev_Brand),
                                      new SqlParameter("@Dev_Model",devInfo.Dev_Model),
                                      new SqlParameter("@Dev_Price",devInfo.Dev_Price),
                                      new SqlParameter("@Dev_Number",devInfo.Dev_Number),
                                      new SqlParameter("@Dev_Imei",devInfo.Dev_Imei),
                                      new SqlParameter("@Dev_Ccid",devInfo.Dev_Ccid),
                                      new SqlParameter("@Dev_NB_Number",devInfo.Dev_NB_Number),
                                      new SqlParameter("@Dev_NB_ExpirationDate",devInfo.Dev_NB_ExpirationDate),
                                      new SqlParameter("@Dev_Ex1",devInfo.Dev_Ex1),
                                      new SqlParameter("@Dev_Ex2",devInfo.Dev_Ex2),
                                      new SqlParameter("@Dev_Ex3",devInfo.Dev_Ex3),
                                      new SqlParameter("@Remarks",devInfo.Remarks),
                                  };

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="devImei"></param>
        /// <returns></returns>
        public int DeleteInfo(string devImei)
        {
            string sql = "delete from DevInfo where Dev_Imei=@Dev_Imei";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@Dev_Imei", devImei));
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="devInfo"></param>
        /// <returns></returns>
        public int UpdateInfo(DevInfo devInfo)
        {
            string sql = "update DevInfo set Proj_Name=@Proj_Name,Proj_Number=@Proj_Number,Proj_Address=@Proj_Address,Proj_Link=@Proj_Link,Install_Man=@Install_Man,Install_Time=@Install_Time,Install_Address=@Install_Address,Dev_Type=@Dev_Type,Dev_Factory=@Dev_Factory,Dev_Brand=@Dev_Brand,Dev_Model=@Dev_Model,Dev_Price=@Dev_Price,Dev_Number=@Dev_Number,Dev_Imei=@Dev_Imei,Dev_Ccid=@Dev_Ccid,Dev_NB_Number=@Dev_NB_Number,Dev_NB_ExpirationDate=@Dev_NB_ExpirationDate,Dev_Ex1=@Dev_Ex1,Dev_Ex2=@Dev_Ex2,Dev_Ex3=@Dev_Ex3,Remarks=@Remarks where ID=@ID";

            SqlParameter[] pars = {
                                      new SqlParameter("@ID",devInfo.ID),
                                      new SqlParameter("@Proj_Name",devInfo.Proj_Name),
                                      new SqlParameter("@Proj_Number",devInfo.Proj_Number),
                                      new SqlParameter("@Proj_Address",devInfo.Proj_Address),
                                      new SqlParameter("@Proj_Link",devInfo.Proj_Link),
                                      new SqlParameter("@Install_Man",devInfo.Install_Man),
                                      new SqlParameter("@Install_Time",devInfo.Install_Time),
                                      new SqlParameter("@Install_Address",devInfo.Install_Address),
                                      new SqlParameter("@Dev_Type",devInfo.Dev_Type),
                                      new SqlParameter("@Dev_Factory",devInfo.Dev_Factory),
                                      new SqlParameter("@Dev_Brand",devInfo.Dev_Brand),
                                      new SqlParameter("@Dev_Model",devInfo.Dev_Model),
                                      new SqlParameter("@Dev_Price",devInfo.Dev_Price),
                                      new SqlParameter("@Dev_Number",devInfo.Dev_Number),
                                      new SqlParameter("@Dev_Imei",devInfo.Dev_Imei),
                                      new SqlParameter("@Dev_Ccid",devInfo.Dev_Ccid),
                                      new SqlParameter("@Dev_NB_Number",devInfo.Dev_NB_Number),
                                      new SqlParameter("@Dev_NB_ExpirationDate",devInfo.Dev_NB_ExpirationDate),
                                      new SqlParameter("@Dev_Ex1",devInfo.Dev_Ex1),
                                      new SqlParameter("@Dev_Ex2",devInfo.Dev_Ex2),
                                      new SqlParameter("@Dev_Ex3",devInfo.Dev_Ex3),
                                      new SqlParameter("@Remarks",devInfo.Remarks),
                                  };

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);

        }

        /// <summary>
        /// 项目信息
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="devInfo"></param>
        private void LoadProjectInfo(DataRow dataRow, DevInfo devInfo)
        {
            devInfo.Proj_Name = dataRow["Proj_Name"].ToString();
            devInfo.Proj_Number = dataRow["Proj_Number"].ToString();
            devInfo.Proj_Address = dataRow["Proj_Address"].ToString();
            devInfo.Proj_Link = dataRow["Proj_Link"].ToString();
        }

        /// <summary>
        /// 设备信息
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="devInfo"></param>
        private void LoadDevInfo(DataRow dataRow, DevInfo devInfo)
        {
            devInfo.ID = Convert.ToInt32(dataRow["ID"]);
            devInfo.Install_Man = dataRow["Install_Man"].ToString();
            devInfo.Install_Time = Convert.ToDateTime(dataRow["Install_Time"]);
            devInfo.Install_Address = dataRow["Install_Address"].ToString();
            devInfo.Dev_Type = dataRow["Dev_Type"].ToString();
            devInfo.Dev_Factory = dataRow["Dev_Factory"].ToString();
            devInfo.Dev_Brand = dataRow["Dev_Brand"].ToString();
            devInfo.Dev_Model = dataRow["Dev_Model"].ToString();
            devInfo.Dev_Price = dataRow["Dev_Price"].ToString();
            devInfo.Dev_Number = dataRow["Dev_Number"].ToString();
            devInfo.Dev_Imei = dataRow["Dev_Imei"].ToString();
            devInfo.Dev_Ccid = dataRow["Dev_Ccid"].ToString();
            devInfo.Dev_NB_Number = dataRow["Dev_NB_Number"].ToString();
            devInfo.Dev_NB_ExpirationDate = dataRow["Dev_NB_ExpirationDate"].ToString();
            devInfo.Dev_Ex1 = dataRow["Dev_Ex1"].ToString();
            devInfo.Dev_Ex2 = dataRow["Dev_Ex2"].ToString();
            devInfo.Dev_Ex3 = dataRow["Dev_Ex3"].ToString();
            devInfo.Remarks = dataRow["Remarks"].ToString();
        }
    }
}
