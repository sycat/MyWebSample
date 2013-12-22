<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadImage.aspx.vb" Inherits="MyExample.UploadImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
    
    </div>
    <asp:Button ID="Button1" runat="server" Text="Upload" /><br />
    1a<br />
    <asp:Image ID="Image1a" ImageUrl="~/Handler1.ashx?id=20120509085139828" runat="server" /><br />
    </form>
</body>
</html>
