﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="ZNMS.Registered.Web.Registered" %>

<%@ Import Namespace="ZNMS.Model" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" />
    <title></title>
    <style type="text/css">
        input {
            height: 100%;
            width: 100%;
            box-sizing: border-box; /*宽就等于内边距+边框宽度*/
        }

        textarea {
            height: 100%;
            width: 100%;
            resize: none;
            box-sizing: border-box;
        }

        table {
            table-layout: fixed;
            width: 100%;
            border-collapse: collapse;
            border: none;
        }
    </style>
    <script src="js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var devStatus = '<%= registeredInfo.Dev_Ex1 %>';
            var existImei = '<%= ExistImei %>';
            if (existImei == 'True') {
                if (devStatus == '2') {   //表示当前为提交状态
                    $("#btn_change").hide();
                    $("#btn_Registered").hide();
                    $("#btn_Acceptance").show();
                }
                else if (devStatus == '3') {     //验收完成
                    $("#btn_change").hide();
                    $("#btn_Registered").hide();
                    $("#btn_Acceptance").hide();
                    $('input').attr("readonly", true);
                    $('textarea').attr("readonly", true);
                }
                else {   //更新安装信息
                    $("#btn_change").show();
                    $("#btn_Registered").hide();
                    $("#btn_Acceptance").hide();
                }
            }
            else {  //注册设备
                $("#btn_change").hide();
                $("#btn_Registered").show();
                $("#btn_Acceptance").hide();
            }
        });

        function changeInfo() {   //修改设备信息
            form1.action = "ChangeInfo.ashx";
            form1.submit();
        };

        function acceptance() {  //验收
            form1.action = "Acceptance.ashx";
            form1.submit();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td style="width: 120px;">项目名称</td>
                <td>
                    <textarea id="Proj_Name_Web" name="Proj_Name_Web" rows="3"><%=registeredInfo.Proj_Name%></textarea></td>
            </tr>
            <tr>
                <td>项目编号</td>
                <td>
                    <input type="text" name="Proj_Number_Web" value="<%=registeredInfo.Proj_Number%>" /></td>
            </tr>
            <tr>
                <td>项目地址</td>
                <td>
                    <textarea name="Proj_Address_Web" rows="3"><%=registeredInfo.Proj_Address%></textarea></td>
            </tr>
            <tr>
                <td>联系方式</td>
                <td>
                    <textarea name="Proj_Link_Web" rows="3"><%=registeredInfo.Proj_Link%></textarea></td>
            </tr>
            <tr>
                <td>安装人员</td>
                <td>
                    <input type="text" name="Install_Man_Web" value="<%=registeredInfo.Install_Man%>" /></td>
            </tr>
            <tr>
                <td>安装时间</td>
                <td>
                    <input type="text" name="Install_Time_Web" value="<%=registeredInfo.Install_Time%>" /></td>
            </tr>
            <tr>
                <td>安装点位</td>
                <td>
                    <input type="text" name="Install_Address_Web" value="<%=registeredInfo.Install_Address%>" /></td>
            </tr>
            <tr>
                <td>设备类型</td>
                <td>
                    <input type="text" name="Dev_Type_Web" value="<%=registeredInfo.Dev_Type%>" /></td>
            </tr>
            <tr>
                <td>设备厂家</td>
                <td>
                    <input type="text" name="Dev_Factory_Web" value="<%=registeredInfo.Dev_Factory%>" /></td>
            </tr>
            <tr>
                <td>设备品牌</td>
                <td>
                    <input type="text" name="Dev_Brand_Web" value="<%=registeredInfo.Dev_Brand%>" /></td>
            </tr>
            <tr>
                <td>设备型号</td>
                <td>
                    <input type="text" name="Dev_Model_Web" value="<%=registeredInfo.Dev_Model%>" /></td>
            </tr>
            <tr>
                <td>设备价格</td>
                <td>
                    <input type="text" name="Dev_Price_Web" value="<%=registeredInfo.Dev_Price%>" /></td>
            </tr>
            <tr>
                <td>设备编号</td>
                <td>
                    <input type="text" name="Dev_Number_Web" value="<%=registeredInfo.Dev_Number%>" /></td>
            </tr>
            <tr>
                <td>IMEI</td>
                <td>
                    <input type="text" readonly="true" name="Dev_Imei_Web" value="<%=registeredInfo.Dev_Imei%>" /></td>
            </tr>
            <tr>
                <td>CCID</td>
                <td>
                    <input type="text" name="Dev_Ccid_Web" value="<%=registeredInfo.Dev_Ccid%>" /></td>
            </tr>
            <tr>
                <td>NB卡号</td>
                <td>
                    <input type="text" name="Dev_NB_Number_Web" value="<%=registeredInfo.Dev_NB_Number%>" /></td>
            </tr>
            <tr>
                <td>NB卡有效期</td>
                <td>
                    <input type="text" name="Dev_NB_ExpirationDate_Web" value="<%=registeredInfo.Dev_NB_ExpirationDate%>" /></td>
            </tr>
            <tr>
                <td>备注</td>
                <td>
                    <textarea name="Remarks_Web" rows="3"><%=registeredInfo.Remarks%></textarea></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" id="btn_change" value="修改" style="width: 100%; height: 45px; font-size: 26px"
                        onclick="changeInfo();" />
                    <input type="submit" id="btn_Registered" value="注册" style="width: 100%; height: 45px; font-size: 26px" />
                    <input type="button" id="btn_Acceptance" value="验收" style="width: 100%; height: 45px; font-size: 26px"
                        onclick="acceptance();" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
