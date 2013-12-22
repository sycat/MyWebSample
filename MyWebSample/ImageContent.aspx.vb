Imports System.Drawing.Imaging
Imports System.Data.OracleClient
Imports System.IO
Imports System.Text
Imports System.Drawing

Public Class ImageContent
    Inherits System.Web.UI.Page

#Region " Web Form �]�p�u�㲣�ͪ��{���X "

    '���� Web Form �]�p�u��һݪ��I�s�C
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    '�`�N: �U�C�w�d��m�ŧi�O Web Form �]�p�u��ݭn�����ءC
    '�ФŧR���β��ʥ��C
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: ���� Web Form �]�p�u��һݪ���k�I�s
        '�ФŨϥε{���X�s�边�i��ק�C
        InitializeComponent()
    End Sub

#End Region

    Private Structure BlobImage
        Public Image As System.Drawing.Image
        Public ExtName As String
    End Structure

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�b�o�̩�m�ϥΪ̵{���X�H��l�ƺ���

        If Not IsPostBack Then

            If Not Context.Request.QueryString("id") = "" Then
                Dim id As String = Context.Request.QueryString("id")

                ' Now you have the id, do what you want with it, to get the right image
                ' More than likely, just pass it to the method, that builds the image
                Dim banner As BlobImage = GetBanner(id)

                If Not banner.Image Is Nothing Then
                    ' Of course set this to whatever your format is of the image
                    ' Save the image to the OutputStream
                    Select Case banner.ExtName
                        Case ".jpg"
                            Context.Response.ContentType = "image/jpeg"
                            banner.Image.Save(Context.Response.OutputStream, ImageFormat.Jpeg)
                        Case ".gif"
                            Context.Response.ContentType = "image/gif"
                            banner.Image.Save(Context.Response.OutputStream, ImageFormat.Gif)
                        Case ".png"
                            Context.Response.ContentType = "image/png"
                            banner.Image.Save(Context.Response.OutputStream, ImageFormat.Png)
                    End Select

                End If

            Else
                Context.Response.ContentType = "text/html"
                Context.Response.Write("<p>Need a valid id</p>")

            End If

        End If

    End Sub

    Private Function GetBanner(ByVal id As String) As BlobImage

        Dim conn As OracleConnection = New OracleConnection("Data Source=trainingDB.evaair.com;Persist Security Info=True;User ID=U01;Password=S123845227")
        Dim OleDbCmd As New OracleCommand(" SELECT IF1_CONTENT, IF1_EXTNAME FROM TEST_IMAGE_FILE1 where IF1_ID = :id ", conn)
        OleDbCmd.Parameters.Add("id", OracleType.VarChar).Value = id

        Dim banner As BlobImage

        Try
            conn.Open()
            Dim reader As OracleDataReader = OleDbCmd.ExecuteReader()

            While reader.Read()

                Dim MyClob As OracleLob = reader.GetOracleLob(0)
                Dim StreamReader As StreamReader = New StreamReader(MyClob, Encoding.Default)
                banner.Image = New Bitmap(System.Drawing.Image.FromStream(StreamReader.BaseStream))
                banner.ExtName = reader.GetOracleString(1).Value

                'Image.Save(Server.MapPath("upFile/" + Name + ".jpg"))

            End While

            reader.Close()

        Catch ex As Exception


        Finally
            conn.Close()
        End Try

        Return banner

    End Function

End Class
