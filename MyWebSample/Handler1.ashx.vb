Imports System.Web
Imports System.Web.Services
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.IO
Imports System.Data.OracleClient

Public Class Handler1
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        If Not String.IsNullOrEmpty(context.Request.QueryString("id")) Then

            Dim id As String = context.Request.QueryString("id").ToString

            ' Now you have the id, do what you want with it, to get the right image
            ' More than likely, just pass it to the method, that builds the image
            Dim ImageResult As Image = GetImage(id)

            If Not ImageResult Is Nothing Then
                ' Of course set this to whatever your format is of the image
                context.Response.ContentType = "image/jpeg"
                ' Save the image to the OutputStream
                ImageResult.Save(context.Response.OutputStream, ImageFormat.Jpeg)
                ImageResult.Dispose()
            End If


        Else
            context.Response.ContentType = "text/html"
            context.Response.Write("<p>Need a valid id</p>")
        End If

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property


    Private Function GetImage(ByVal id As String) As Image

        ' Not sure how you are building your MemoryStream
        ' Once you have it, you just use the Image class to 
        ' create the image from the stream.

        Using conn As OracleConnection = New OracleConnection("Data Source=trainingDB.evaair.com;Persist Security Info=True;User ID=U01;Password=S123845227")

            Dim SQL As String = " SELECT IF1_CONTENT FROM TEST_IMAGE_FILE1 where IF1_ID = '" & id & "' "
            Dim cmd As OracleCommand = New OracleCommand(SQL, conn)
            Dim Image As Image = Nothing

            Try
                conn.Open()
                Dim reader As OracleDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim MyClob As OracleLob = reader.GetOracleLob(0)
                    Dim StreamReader As StreamReader = New StreamReader(MyClob, Encoding.Default)

                    Image = New Bitmap(Image.FromStream(StreamReader.BaseStream))
                    'Image.Save(Server.MapPath("upFile/" + Name + ".jpg"))

                End While
                reader.Close()

            Catch ex As Exception


            Finally
                conn.Close()
            End Try

            Return Image

        End Using



    End Function

End Class