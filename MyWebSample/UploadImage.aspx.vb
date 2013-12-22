Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OracleClient
Imports System.IO
Imports System.Web.Configuration

Public Class UploadImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load






    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.FileUpload1.HasFile Then

            '取得副檔名
            Dim ExtName As String = System.IO.Path.GetExtension(Me.FileUpload1.PostedFile.FileName).ToLower()

            If ExtName = ".jpg" Or ExtName = ".gif" Or ExtName = ".png" Then

                Try
                    Dim imgbyte(Me.FileUpload1.PostedFile.InputStream.Length) As Byte
                    Me.FileUpload1.PostedFile.InputStream.Read(imgbyte, 0, imgbyte.Length)
                    FileUpload1.PostedFile.InputStream.Close()

                    '寫入資料庫
                    Using conn As New OracleConnection("Data Source=trainingDB.evaair.com;Persist Security Info=True;User ID=U01;Password=S123845227")

                        Dim OleDbCmd As New OracleCommand(" insert into TEST_IMAGE_FILE1 (IF1_ID, IF1_EXTNAME, IF1_CONTENT, IF1_INS_DT) values (to_char(SYSTIMESTAMP, 'YYYYMMDDHH24MISSFF3'), :ExtensionName, :IMGFILE, sysdate) ", conn)
                        OleDbCmd.Parameters.Add("IMGFILE", OracleType.Blob).Value = imgbyte
                        OleDbCmd.Parameters.Add("ExtensionName", OracleType.VarChar).Value = ExtName

                        Try
                            conn.Open()
                            OleDbCmd.ExecuteNonQuery()
                        Catch ex As SqlException
                            Throw ex
                        Finally
                            conn.Close()
                        End Try

                    End Using

                Catch ex As Exception
                    Me.Response.Write("ex.Message=    " & ex.Message)
                    Me.Response.Write("<br>ex.StackTrace= " & ex.StackTrace)
                End Try

            End If

        End If

    End Sub
End Class