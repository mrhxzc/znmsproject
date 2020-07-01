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

        //项目编号
        public int XMBH { get; set; }

        //设备项目名称
        public string SBXMMC { get; set; }

        //项目地址
        public string XMDZ { get; set; }

        //三方对接人及联系方式
        public string DJRLXFS { get; set; }

        //安装人员
        public string AZRY { get; set; }

        //安装时间
        public DateTime AZSJ { get; set; }

        //安装点位
        public string AZDW { get; set; }

        //设备类型
        public string SBLX { get; set; }

        //设备编号
        public string SBBH { get; set; }

        //IMEI
        public string IMEI { get; set; }

        //CCID
        public string CCID { get; set; }

        //NB卡号
        public string NBKH { get; set; }

        //NB卡有效期
        public string NBYXQ { get; set; }

        //EX1
        public string EX1 { get; set; }

        //EX2
        public string EX2 { get; set; }

        //EX3
        public string EX3 { get; set; }

        //备注
        public string BZ { get; set; }
    }
}
