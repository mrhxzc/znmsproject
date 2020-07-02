﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="ZNMS.Registered.Web.Registered" %>
<%@ Import Namespace="ZNMS.Model" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" /> 
    <title></title>
       
    <script src="js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        function changeInfo() {
            form1.action = "ChangeInfo.ashx";
            form1.submit();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>项目名称</td>
                    <td>
                        <textarea name="Proj_Name_Web" class="my" rows="3" style="width:172px;"><%=registeredInfo.Proj_Name%></textarea></td>
                </tr>
                <tr>
                    <td>项目编号</td>
                    <td>
                        <input type="text" name="Proj_Number_Web" style="width:170px;" value="<%=registeredInfo.Proj_Number%>" /></td>
                </tr>
                <tr>
                    <td>项目地址</td>
                    <td>
                        <textarea name="Proj_Address_Web"  rows="3" style="width:172px;" ><%=registeredInfo.Proj_Address%></textarea></td>
                </tr>
                <tr>
                    <td>三方对接人及联系方式</td>
                    <td>
                        <textarea name="Proj_Link_Web"  rows="3" style="width:172px;" ><%=registeredInfo.Proj_Link%></textarea></td>
                </tr>
                <tr>
                    <td>安装人员</td>
                    <td>
                        <input type="text" name="Install_Man_Web" style="width:170px;" value="<%=registeredInfo.Install_Man%>" /></td>
                </tr>
                <tr>
                    <td>安装时间</td>
                    <td>
                        <input type="text" name="Install_Time_Web" style="width:170px;" value="<%=registeredInfo.Install_Time%>" /></td>
                </tr>
                <tr>
                    <td>安装点位</td>
                    <td>
                        <input type="text" name="Install_Address_Web" style="width:170px;" value="<%=registeredInfo.Install_Address%>" /></td>
                </tr>
                <tr>
                    <td>设备类型</td>
                    <td>
                        <input type="text" name="Dev_Type_Web" style="width:170px;" value="<%=registeredInfo.Dev_Type%>" /></td>
                </tr>
                <tr>
                    <td>设备厂家</td>
                    <td>
                        <input type="text" name="Dev_Factory_Web" style="width:170px;" value="<%=registeredInfo.Dev_Factory%>" /></td>
                </tr>
                <tr>
                    <td>设备品牌</td>
                    <td>
                        <input type="text" name="Dev_Brand_Web" style="width:170px;" value="<%=registeredInfo.Dev_Brand%>" /></td>
                </tr>
                <tr>
                    <td>设备型号</td>
                    <td>
                        <input type="text" name="Dev_Model_Web" style="width:170px;" value="<%=registeredInfo.Dev_Model%>" /></td>
                </tr>
                <tr>
                    <td>设备价格</td>
                    <td>
                        <input type="text" name="Dev_Price_Web" style="width:170px;" value="<%=registeredInfo.Dev_Price%>" /></td>
                </tr>
                <tr>
                    <td>设备编号</td>
                    <td>
                        <input type="text" name="Dev_Number_Web" style="width:170px;" value="<%=registeredInfo.Dev_Number%>" /></td>
                </tr>
                <tr>
                    <td>IMEI</td>
                    <td>
                        <input type="text" readonly="true" style="width:170px;" name="Dev_Imei_Web" value="<%=registeredInfo.Dev_Imei%>" /></td>
                </tr>
                <tr>
                    <td>CCID</td>
                    <td>
                        <input type="text" name="Dev_Ccid_Web" style="width:170px;" value="<%=registeredInfo.Dev_Ccid%>" /></td>
                </tr>
                <tr>
                    <td>NB卡号</td>
                    <td>
                        <input type="text" name="Dev_NB_Number_Web" style="width:170px;" value="<%=registeredInfo.Dev_NB_Number%>" /></td>
                </tr>
                <tr>
                    <td>NB卡有效期</td>
                    <td>
                        <input type="text" name="Dev_NB_ExpirationDate_Web" style="width:170px;" value="<%=registeredInfo.Dev_NB_ExpirationDate%>" /></td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td>
                        <textarea name="Remarks_Web"  rows="3" style="width:172px;" ><%=registeredInfo.Remarks%></textarea></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div align='right'>
                            <input type="button" id="btn_change" value="修改" onclick="changeInfo();" />
                            <input type="submit" value="注册" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
