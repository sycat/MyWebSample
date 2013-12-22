<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PreventDoubleSubmit.aspx.vb" Inherits="MyExample.PreventDoubleSubmit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-latest.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Buttom will cost 3 sec to work.<br />
        It is not work while working.
    </div>
    <asp:ImageButton ID="BtnOk" runat="server" ImageUrl="./img/ok.gif" />
    <asp:Button id="BtnSubmit" runat="server" Text="Button" />
    <span id="lblMsg"></span>
    
    </form>
    <script type="text/javascript">
        function submitOnClick(btn) {
            if (checkData() == true) {
                $(btn).attr('disabled', '');  // Set button disabled.
                $(btn).css('cursor', 'wait'); // Set button cursor.
                $(btn).val('Checking...'); // Set UI change.
                return true;
            } else {
                return false;
            }
        }
        function checkData() {
            /*
                Check Data is correct or wrong.
            */
            return true; // If Data is correct.
        }

        function checkFormData(btn) {
            /*
                Check Data is correct or wrong.
            */

            // If Data is correct.
            $(btn).attr('disabled', '');  // Set button disabled.
            $(btn).css('cursor', 'wait'); // Set button cursor.
            return true;
        }
    </script>
</body>
</html>
