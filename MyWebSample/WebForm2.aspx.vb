Imports System.IO

Public Class WebForm2
    Inherits System.Web.UI.Page

    Public wf1 As WebForm1

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Public ReadOnly Property FullName() As String
        Get
            Return lbl1.Text
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁

        Me.Response.Write("Form2 Page_Load")

        Dim w As StreamWriter = File.AppendText("C:\log\log.txt")
        Log("Form2 Page_Load Start", w)
        ' Close the writer and underlying file.
        w.Close()


        If Not Me.IsPostBack Then

            wf1 = CType(Context.Handler, WebForm1)
            Me.lbl1.Text = wf1.FirstName & wf1.LastName

        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim w As StreamWriter = File.AppendText("C:\log\log.txt")
        Log("Form2 Button1_Click Start", w)
        ' Close the writer and underlying file.
        w.Close()

        Server.Transfer("./WebForm3.aspx")

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

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

End Class
