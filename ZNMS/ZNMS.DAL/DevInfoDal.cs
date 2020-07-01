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
        /// <param name="imei">IMEI值</param>
        /// <param name="xmbh">项目编号</param>
        /// <returns>注册信息</returns>
        public DevInfo GetInfo(string imei, int xmbh)
        {
            string sql = "select ID,AZSJ,AZDW,SBLX,SBBH,IMEI,CCID,NBKH,NBYXQ,EX1,EX2,EX3,BZ from DevInfo where IMEI=@IMEI";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@IMEI", imei));
            DevInfo devInfo = new DevInfo();
            if (da.Rows.Count > 0)
            {
                LoadInfo(da.Rows[0], devInfo);
            }
            else
            {
                devInfo.IMEI = imei;
                devInfo.AZSJ = DateTime.Now;
            }

            sql = "select TOP 1 XMBH,SBXMMC,XMDZ,DJRLXFS,AZRY from DevInfo where XMBH=@XMBH";
            DataTable dabh = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@XMBH", xmbh));
            if (dabh.Rows.Count > 0)
            {
                LoadXmbhInfo(dabh.Rows[0], devInfo);
            }
            return devInfo;
        }

        public DevInfo GetInfo(string imei)
        {
            string sql = "select * from DevInfo where IMEI=@IMEI";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@IMEI", imei));
            DevInfo devInfo = null;
            if (da.Rows.Count > 0)
            {
                devInfo = new DevInfo();
                LoadInfo(da.Rows[0], devInfo);
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
            string sql = "insert into DevInfo(XMBH,SBXMMC,XMDZ,DJRLXFS,AZRY,AZSJ,AZDW,SBLX,SBBH,IMEI,CCID,NBKH,NBYXQ,EX1,EX2,EX3,BZ) values(@XMBH,@SBXMMC,@XMDZ,@DJRLXFS,@AZRY,@AZSJ,@AZDW,@SBLX,@SBBH,@IMEI,@CCID,@NBKH,@NBYXQ,@EX1,@EX2,@EX3,@BZ)";

            SqlParameter[] pars = {
                                      new SqlParameter("@XMBH",devInfo.XMBH),
                                      new SqlParameter("@SBXMMC",devInfo.SBXMMC),
                                      new SqlParameter("@XMDZ",devInfo.XMDZ),
                                      new SqlParameter("@DJRLXFS",devInfo.DJRLXFS),
                                      new SqlParameter("@AZRY",devInfo.AZRY),
                                      new SqlParameter("@AZSJ",devInfo.AZSJ),
                                      new SqlParameter("@AZDW",devInfo.AZDW),
                                      new SqlParameter("@SBLX",devInfo.SBLX),
                                      new SqlParameter("@SBBH",devInfo.SBBH),
                                      new SqlParameter("@IMEI",devInfo.IMEI),
                                      new SqlParameter("@CCID",devInfo.CCID),
                                      new SqlParameter("@NBKH",devInfo.NBKH),
                                      new SqlParameter("@NBYXQ",devInfo.NBYXQ),
                                      new SqlParameter("@EX1",devInfo.EX1),
                                      new SqlParameter("@EX2",devInfo.EX2),
                                      new SqlParameter("@EX3",devInfo.EX3),
                                      new SqlParameter("@BZ",devInfo.BZ),
                                  };

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="imei"></param>
        /// <returns></returns>
        public int DeleteInfo(string imei)
        {
            string sql = "delete from DevInfo where IMEI=@IMEI";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@IMEI", imei));
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="devInfo"></param>
        /// <returns></returns>
        public int UpdateInfo(DevInfo devInfo)
        {
            string sql = "update DevInfo set XMBH=@XMBH,SBXMMC=@SBXMMC,XMDZ=@XMDZ,DJRLXFS=@DJRLXFS,AZRY=@AZRY,AZSJ=@AZSJ,AZDW=@AZDW,SBLX=@SBLX,SBBH=@SBBH,IMEI=@IMEI,CCID=@CCID,NBKH=@NBKH,NBYXQ=@NBYXQ,EX1=@EX1,EX2=@EX2,EX3=@EX3,BZ=@BZ where ID=@ID";

            SqlParameter[] pars = {
                                      new SqlParameter("@XMBH",devInfo.XMBH),
                                      new SqlParameter("@SBXMMC",devInfo.SBXMMC),
                                      new SqlParameter("@XMDZ",devInfo.XMDZ),
                                      new SqlParameter("@DJRLXFS",devInfo.DJRLXFS),
                                      new SqlParameter("@AZRY",devInfo.AZRY),
                                      new SqlParameter("@AZSJ",devInfo.AZSJ),
                                      new SqlParameter("@AZDW",devInfo.AZDW),
                                      new SqlParameter("@SBLX",devInfo.SBLX),
                                      new SqlParameter("@SBBH",devInfo.SBBH),
                                      new SqlParameter("@IMEI",devInfo.IMEI),
                                      new SqlParameter("@CCID",devInfo.CCID),
                                      new SqlParameter("@NBKH",devInfo.NBKH),
                                      new SqlParameter("@NBYXQ",devInfo.NBYXQ),
                                      new SqlParameter("@EX1",devInfo.EX1),
                                      new SqlParameter("@EX2",devInfo.EX2),
                                      new SqlParameter("@EX3",devInfo.EX3),
                                      new SqlParameter("@BZ",devInfo.BZ),
                                      new SqlParameter("@ID",devInfo.ID)
                                  };

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);

        }

        private void LoadInfo(DataRow dataRow, DevInfo devInfo)
        {
            devInfo.ID = Convert.ToInt32(dataRow["ID"]);
            devInfo.AZSJ = Convert.ToDateTime(dataRow["AZSJ"]);
            devInfo.AZDW = dataRow["AZDW"].ToString();
            devInfo.SBLX = dataRow["SBLX"].ToString();
            devInfo.SBBH = dataRow["SBBH"].ToString();
            devInfo.IMEI = dataRow["IMEI"].ToString();
            devInfo.CCID = dataRow["CCID"].ToString();
            devInfo.NBKH = dataRow["NBKH"].ToString();
            devInfo.NBYXQ = dataRow["NBYXQ"].ToString();
            devInfo.EX1 = dataRow["EX1"].ToString();
            devInfo.EX2 = dataRow["EX2"].ToString();
            devInfo.EX3 = dataRow["EX3"].ToString();
            devInfo.BZ = dataRow["BZ"].ToString();
        }

        private void LoadXmbhInfo(DataRow dataRow, DevInfo devInfo)
        {
            devInfo.XMBH = Convert.ToInt32(dataRow["XMBH"]);
            devInfo.SBXMMC = dataRow["SBXMMC"].ToString();
            devInfo.XMDZ = dataRow["XMDZ"].ToString();
            devInfo.DJRLXFS = dataRow["DJRLXFS"].ToString();
            devInfo.AZRY = dataRow["AZRY"].ToString();
        }
    }
}
