<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1"%>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
		<script type="text/javascript">
			$(function() {
				//$("#Form1").clear();
				$("#RadioButton1").attr("Checked", "Checked");
				//alert('start');
			});
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:RadioButton id="RadioButton1" GroupName="temp" runat="server"></asp:RadioButton>
			<asp:RadioButton id="Radiobutton2" GroupName="temp" Checked="True" runat="server"></asp:RadioButton>
			First Name:
			<asp:textbox id="first" runat="server"></asp:textbox><br>
			Last Name:
			<asp:textbox id="last" runat="server"></asp:textbox><br>
			<asp:button id="Button1" runat="server" Text="Go to second page"></asp:button><br>
			<asp:HyperLink id="HyperLink1" runat="server">HyperLink</asp:HyperLink><br>
			<asp:button id="btn_email" runat="server" Text="Send email"></asp:button><br>
		</form>
	</body>
</HTML>
