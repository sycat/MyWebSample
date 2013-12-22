Imports System.IO

Public Class WebForm2
    Inherits System.Web.UI.Page

    Public wf1 As WebForm1

#Region " Web Form �]�p�u�㲣�ͪ��{���X "

    '���� Web Form �]�p�u��һݪ��I�s�C
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button

    '�`�N: �U�C�w�d��m�ŧi�O Web Form �]�p�u��ݭn�����ءC
    '�ФŧR���β��ʥ��C
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: ���� Web Form �]�p�u��һݪ���k�I�s
        '�ФŨϥε{���X�s�边�i��ק�C
        InitializeComponent()
    End Sub

#End Region

    Public ReadOnly Property FullName() As String
        Get
            Return lbl1.Text
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�b�o�̩�m�ϥΪ̵{���X�H��l�ƺ���

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
