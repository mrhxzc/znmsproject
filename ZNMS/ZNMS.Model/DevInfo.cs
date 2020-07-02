using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNMS.Model
{
    public class DevInfo
    {
        //ID号
        public int ID { get; set; } 

        //项目名称
        public string Proj_Name { get; set; }

        //项目编号
        public string Proj_Number { get; set; }

        //项目地址
        public string Proj_Address { get; set; }

        //三方对接人及联系方式
        public string Proj_Link { get; set; }

        //安装人员
        public string Install_Man { get; set; }

        //安装时间
        public DateTime Install_Time { get; set; }

        //安装点位
        public string Install_Address { get; set; }

        //设备类型
        public string Dev_Type { get; set; }

        //设备厂家
        public string Dev_Factory { get; set; }

        //设备品牌
        public string Dev_Brand { get; set; }

        //设备型号
        public string Dev_Model { get; set; }

        //设备价格
        public string Dev_Price { get; set; }

        //设备编号
        public string Dev_Number { get; set; }

        //IMEI
        public string Dev_Imei { get; set; }

        //CCID
        public string Dev_Ccid { get; set; }

        //NB卡号
        public string Dev_NB_Number { get; set; }

        //NB卡有效期
        public string Dev_NB_ExpirationDate { get; set; }

        //EX1
        public string Dev_Ex1 { get; set; }

        //EX2
        public string Dev_Ex2 { get; set; }

        //EX3
        public string Dev_Ex3 { get; set; }

        //备注
        public string Remarks { get; set; }
    }
}
