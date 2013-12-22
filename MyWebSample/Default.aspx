<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="MyExample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-latest.min.js"></script>
    <script type="text/javascript">
        /*function check() {
            document.getElementById('btn').disabled=true;
            return true;
        }*/

        $(function () {
            $("#form1").submit(function () {
                $("#btn").prop("disabled", true);
            });
        });

        function btn_Click1() {
            $("#btnSend").val('AA');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1">
        Init.
    </div>
    <asp:Button id="btn" runat="server" Text="Button" />
    <div onclick="btn_Click1();">click me</div>
    <input type="text" id="btnSend" value="" />
    </form>
</body>
</html>
