<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LockButton.aspx.vb" Inherits="MyWebSample.LockButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script type="text/javascript">
    function disableForm(theform)
    {
        if (document.all || document.getElementById) {
            //sleep(10000);
            for (i = 0; i < theform.length; i++) {
                var tempobj = theform.elements[i];
                if (tempobj.type.toLowerCase() == "submit" || tempobj.type.toLowerCase() == "reset")
                    tempobj.disabled = true;
            }

            setTimeout('alert("Your form has been submitted.  Notice how the submit and reset buttons were disabled upon submission.");', 500);
            return true;

        } else {
            alert("The form has been submitted.  But, since you're not using IE 4+ or NS 6, the submit button was not disabled on form submission.");
            return false;
        }

        theform.submit();
    }
</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" onSubmit="return disableForm(this);" method="post" >
    <div>
        Name: <input type=text name=person>
	    <input type=submit><input type=reset><input type=button value="test" onclick="test();">
    </div>
    </form>
</body>
</html>
