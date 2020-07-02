using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNMS.Model;

namespace ZNMS.BLL
{
    public class DevInfoBll
    {
        DAL.DevInfoDal devInfoDal = new DAL.DevInfoDal();

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="devImei"></param>
        /// <returns></returns>
        public DevInfo GetRegisteredInfo(string devImei, string projNumber)
        {
            return devInfoDal.GetInfo(devImei, projNumber);
        }

        /// <summary>
        /// 判断是否查询到数据
        /// </summary>
        /// <param name="devImei"></param>
        /// <returns></returns>
        public bool IsGetRegisteredInfo(string devImei)
        {
            DevInfo registeredInfo = null;
            registeredInfo = devInfoDal.GetInfo(devImei);
            if (registeredInfo != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="registeredInfo"></param>
        /// <returns></returns>
        public bool InsertRegisteredInfo(DevInfo registeredInfo)
        {
            return devInfoDal.InsertInfo(registeredInfo) > 0;
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="registeredInfo"></param>
        /// <returns></returns>
        public bool UpdateRegisteredInfo(DevInfo registeredInfo)
        {
            return devInfoDal.UpdateInfo(registeredInfo) > 0;
        }
    }
}
