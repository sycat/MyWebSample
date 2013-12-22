Imports System.Data.OracleClient
Imports System.IO.Path

Public Class ImageUpload
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ImageFile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents ButtonUpload As System.Web.UI.WebControls.Button

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

    End Sub

    Private Sub ButtonUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click

        Dim conn As New OracleConnection("Data Source=trainingDB.evaair.com;Persist Security Info=True;User ID=U01;Password=S123845227")
        Dim UploadImage As HttpPostedFile = Request.Files("ImageFile")

        If UploadImage.ContentLength > 0 Then

            Dim ExtensionName As String = GetExtension(UploadImage.FileName).ToLower()

            If ExtensionName = ".jpg" Or ExtensionName = ".gif" Or ExtensionName = ".png" Then

                Dim imgbyte(UploadImage.ContentLength) As Byte
                UploadImage.InputStream.Read(imgbyte, 0, imgbyte.Length)
                UploadImage.InputStream.Close()

                Try
                    conn.Open()
                    Dim OleDbCmd As New OracleCommand( _
                        " insert into TEST_IMAGE_FILE1 (IF1_ID, IF1_EXTNAME, IF1_CONTENT, IF1_INS_DT) values (to_char(SYSTIMESTAMP, 'YYYYMMDDHH24MISSFF3'), :ExtensionName, :IMGFILE, sysdate) ", _
                        conn)
                    OleDbCmd.Parameters.Add("ExtensionName", OracleType.VarChar).Value = ExtensionName
                    OleDbCmd.Parameters.Add("IMGFILE", OracleType.Blob).Value = imgbyte
                    OleDbCmd.ExecuteNonQuery()
                Catch ex As Exception
                    Me.Response.Write(ex.Message)
                Finally
                    conn.Close()
                End Try

            End If

        End If



    End Sub

End Class
