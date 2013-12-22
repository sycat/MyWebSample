Imports System.IO
Imports System.Data.OracleClient
Imports System.Data.SqlClient

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.ViewState("OriginalStartDate") = "2010/1/1"
        'Dim OglDateS As Nullable(Of DateTime) = DateTime.Parse(Me.ViewState("OriginalStartDate"))
        'Dim s As String = IIf(Me.ViewState("test") = "", "empty", "value")
        'Me.Response.Write(OglDateS.Value)

        'Dim OglDateS As Nullable(Of DateTime) = If(Me.ViewState("OriginalStartDate") = "", _
        '                                           Nothing, _
        '                                           DateTime.Parse(Me.ViewState("OriginalStartDate")))
        'Dim OglDateE As Nullable(Of DateTime) = If(Me.ViewState("OriginalEndDate") = "", _
        '                                           Nothing, _
        '                                           DateTime.Parse(Me.ViewState("OriginalEndDate")))

        Dim s As String = "http://FAQ.aspx?WhichClass='9'&aaa=0"
        'Class2010.WriteLog(HttpUtility.HtmlDecode(HttpUtility.HtmlEncode(s).ToString))

        Dim TourismAry As New ArrayList()
        TourismAry.Add("aaa")
        TourismAry.Add("bbb")
        TourismAry.Add("ccc")
        TourismAry.Contains("a")
        'Dim sss As String = String.Join("','", TourismAry.ToArray(GetType(String)))
        Me.Response.Write(TourismAry.Contains("aaa"))

        If Not IsPostBack Then
            'Response.Write("not postback")

            'foo()

        Else
            '    Response.Write("is postback")

        End If

    End Sub



    Private Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn.Click

        'Me.hid.Value = "Changed"
        'Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType, "", "alert('YY');", True)
        System.Threading.Thread.Sleep(5000)
        Using sw As StreamWriter = New StreamWriter("C:\\log\ClickLog.txt", True)
            sw.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} {1}", DateTime.Now, "TEST")
            sw.Close()
        End Using

        Server.Transfer("Default2.aspx")


    End Sub


    Private Sub foo()

        Dim cmd As OracleCommand
        cmd = New OracleCommand(" insert into test1 (col1, col2) values (TEST1_SEQUENCE.nextval, 'test') ")
        'cmd = New OracleCommand(" select '1' from dual ")

        Dim connection As New OracleConnection("Data Source=localhost:1521;Persist Security Info=True;User ID=ed39298;Password=add39298")

        Using connection
            ' 開始寫入DB
            connection.Open()

            ' Start a local transaction
            Dim transaction As OracleTransaction
            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                cmd.Connection = connection
                cmd.Transaction = transaction
                cmd.ExecuteNonQuery()

                transaction.Commit()

                Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), _
                                                               "AddSuccess", _
                                                               "alert('Add Success.');", _
                                                               True)

            Catch ex As Exception
                transaction.Rollback()
                Response.Write("<b>ERROR MESSAGE:</b>" + ex.ToString() + "<hr/>")
            End Try

        End Using

    End Sub

    Private Sub too(ByVal s As ArrayList)
        s.Clear()
    End Sub

End Class