<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ImageList.aspx.vb" Inherits="WebApplication1.ImageList"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>ImageList</title>
		<style type="text/css">
			div.imageitem { FLOAT: left }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align="right"><a href="javascript://" onclick="location('ImageUpload.aspx')">ImageExplorer</a></div>
			<!--
			<asp:Image id="Image1" runat="server" Width="200" Height="200" AlternateText="替代文字"></asp:Image>
			<br>
			<asp:Image id="Image2" runat="server" Width="200" Height="200" AlternateText="替代文字"></asp:Image>
			-->
		</form>
	</body>
</HTML>
