Imports System.Data.OracleClient

Public Class ImageList
    Inherits System.Web.UI.Page

#Region " Web Form �]�p�u�㲣�ͪ��{���X "

    '���� Web Form �]�p�u��һݪ��I�s�C
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator

    '�`�N: �U�C�w�d��m�ŧi�O Web Form �]�p�u��ݭn�����ءC
    '�ФŧR���β��ʥ��C
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: ���� Web Form �]�p�u��һݪ���k�I�s
        '�ФŨϥε{���X�s�边�i��ק�C
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�b�o�̩�m�ϥΪ̵{���X�H��l�ƺ���

        If Not IsPostBack Then

            Dim conn As OracleConnection = New OracleConnection("Data Source=trainingDB.evaair.com;Persist Security Info=True;User ID=U01;Password=S123845227")
            Dim OleDbCmd As OracleCommand = New OracleCommand(" SELECT IF2_ID FROM TEST_IMAGE_FILE2 ", conn)

            Try
                conn.Open()
                Dim dr As OracleDataReader = OleDbCmd.ExecuteReader()

                While dr.Read()
                    addImageItem(dr.Item("IF2_ID"))
                End While
                'addImageItem("20120508154352312")

                dr.Close()

            Catch ex As Exception

            Finally
                conn.Close()
            End Try


            'Me.Image1.ImageUrl = "./ImageContent.aspx?id=1a"
            'Me.Image1.Attributes.Add("onmouseover", "this.style.cursor='pointer';")
            'Me.Image1.Attributes.Add("onclick", "alert('test');")
            'Me.Image2.ImageUrl = "./ImageContent.aspx?id=1b"


        End If

    End Sub


    Private Sub addImageItem(ByVal id As String)


        Dim imgControl As New System.Web.UI.WebControls.Image
        imgControl.AlternateText = "Image Text"
        imgControl.ImageUrl = "./ImageContent.aspx?id=" & id

        Dim divControl As HtmlControl = New HtmlGenericControl("div")
        'divControl.Attributes.Add("id", "myid")
        divControl.Attributes.Add("align", "center")
        divControl.Controls.Add(New LiteralControl(id))


        Dim control As Control = Me.FindControl("Form1")
        Dim divParrent As HtmlControl = New HtmlGenericControl("div")
        divParrent.Attributes.Add("class", "imageitem")
        divParrent.Controls.Add(divControl)
        divParrent.Controls.Add(imgControl)
        control.Controls.Add(divParrent)

    End Sub

End Class
