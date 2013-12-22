Imports System.IO
Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected FirstNameTextBox As System.Web.UI.WebControls.TextBox

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents first As System.Web.UI.WebControls.TextBox
    Protected WithEvents last As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents btn_email As System.Web.UI.WebControls.Button
    Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Public ReadOnly Property FirstName() As String
        Get
            Return first.Text
        End Get
    End Property

    Public ReadOnly Property LastName() As String
        Get
            Return last.Text
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁

        Me.Button1.Visible = False
        'Button1_Click(sender, e)
        Me.RadioButton1.Checked = True

        Dim w As StreamWriter = File.AppendText("C:\log\log.txt")
        Log("Form1 Page_Load Start", w)
        ' Close the writer and underlying file.
        w.Close()

        HyperLink1.NavigateUrl = "https://www.uniair.com.tw/uniairec/"

        If Not Me.IsPostBack Then

            Me.Response.Write("*****IsPostBack*****<br>")

            Try
                Me.Response.Write("no error<br>")
                'Me.Response.Write(Request.Form("foo").ToString)
            Catch ex As Exception
                Me.Response.Write(ex.Message)
                Me.Response.Write(ex.StackTrace)
            End Try


        End If




    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Not foo() Then
            Exit Sub
        End If

        Server.Transfer("./WebForm2.aspx")
        'Response.Redirect("./WebForm2.aspx")

    End Sub

    Public Shared Sub Log(ByVal logMessage As String, ByVal w As TextWriter)
        w.Write(ControlChars.CrLf & "Log Entry : ")
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
        w.WriteLine("  :")
        w.WriteLine("  :{0}", logMessage)
        w.WriteLine("-------------------------------")
        ' Update the underlying file.
        w.Flush()
    End Sub

    Private Sub btn_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_email.Click
        'Me.Response.Redirect("mailto:es@service.uniair.com.tw", False)
        Me.Response.Write("<script>javascript: alert('test');</script>")

    End Sub

    '使用 Function 並產生回傳值
    Private Function foo() As Boolean

        '失敗的時候回傳False
        Me.Page.RegisterStartupScript("UploadSuccess", "<script type='text/javascript'>alert('Upload Success.');</script>")
        Return False

    End Function

End Class
