<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="ZNMS.Registered.Web.Registered" %>
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
                    <td>设备项目名称</td>
                    <td>
                        <input type="text" name="mySBXMMC" value="<%=registeredInfo.SBXMMC%>" /></td>
                </tr>
                <tr>
                    <td>项目编号</td>
                    <td>
                        <input type="text" name="myXMBH" value="<%=registeredInfo.XMBH%>" /></td>
                </tr>
                <tr>
                    <td>项目地址</td>
                    <td>
                        <input type="text" name="myXMDZ" value="<%=registeredInfo.XMDZ%>" /></td>
                </tr>
                <tr>
                    <td>三方对接人及联系方式</td>
                    <td>
                        <input type="text" name="myDJRLXFS" value="<%=registeredInfo.DJRLXFS%>" /></td>
                </tr>
                <tr>
                    <td>安装人员</td>
                    <td>
                        <input type="text" name="myAZRY" value="<%=registeredInfo.AZRY%>" /></td>
                </tr>
                <tr>
                    <td>安装时间</td>
                    <td>
                        <input type="text" name="myAZSJ" value="<%=registeredInfo.AZSJ%>" /></td>
                </tr>
                <tr>
                    <td>安装点位</td>
                    <td>
                        <input type="text" name="myAZDW" value="<%=registeredInfo.AZDW%>" /></td>
                </tr>
                <tr>
                    <td>设备类型</td>
                    <td>
                        <input type="text" name="mySBLX" value="<%=registeredInfo.SBLX%>" /></td>
                </tr>
                <tr>
                    <td>设备编号</td>
                    <td>
                        <input type="text" name="mySBBH" value="<%=registeredInfo.SBBH%>" /></td>
                </tr>
                <tr>
                    <td>IMEI</td>
                    <td>
                        <input type="text" readonly="true" name="myIMEI" value="<%=registeredInfo.IMEI%>" /></td>
                </tr>
                <tr>
                    <td>CCID</td>
                    <td>
                        <input type="text" name="myCCID" value="<%=registeredInfo.CCID%>" /></td>
                </tr>
                <tr>
                    <td>NB卡号</td>
                    <td>
                        <input type="text" name="myNBKH" value="<%=registeredInfo.NBKH%>" /></td>
                </tr>
                <tr>
                    <td>NB卡有效期</td>
                    <td>
                        <input type="text" name="myNBYXQ" value="<%=registeredInfo.NBYXQ%>" /></td>
                </tr>
                <tr>
                    <td>EX1</td>
                    <td>
                        <input type="text" name="myEX1" value="<%=registeredInfo.EX1%>" /></td>
                </tr>
                <tr>
                    <td>EX2</td>
                    <td>
                        <input type="text" name="myEX2" value="<%=registeredInfo.EX2%>" /></td>
                </tr>
                <tr>
                    <td>EX3</td>
                    <td>
                        <input type="text" name="myEX3" value="<%=registeredInfo.EX3%>" /></td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td>
                        <input type="text" name="myBZ" value="<%=registeredInfo.BZ%>" /></td>
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
