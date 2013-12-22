<%@ Reference Page="WebForm1.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm2.aspx.vb" Inherits="WebApplication1.WebForm2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label ID="lbl1" Runat="server"></asp:Label>
			<asp:Button id="Button1" Text="Go to third page" runat="server" /><br>
			<asp:Button id="Button2" runat="server" Text="Only Postback"></asp:Button>
			<a href="WebForm1.aspx">WebForm1</a>
		</form>
	</body>
</HTML>
