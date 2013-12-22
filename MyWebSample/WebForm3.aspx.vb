Public Class WebForm3
    Inherits System.Web.UI.Page

    Public wf2 As WebForm2

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lbl_fullname As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁


        If Not Me.IsPostBack Then

            Try
                wf2 = CType(context.Handler, WebForm2)
                Me.lbl_fullname.Text = wf2.FullName

            Catch ex As Exception
                Me.Response.Redirect("Webform1.aspx")
            End Try




        End If

    End Sub


End Class
