Public Class PreventDoubleSubmit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Support above .net 1.1
        'Me.btn_ok.Attributes.Add("onClick", "this.disabled=true;this.style.cursor='wait';" + GetPostBackEventReference(Me.btn_ok).ToString())
        'Me.BtnOk.Attributes.Add("onClick", "if(submitOnClick(this)==false) {return false;};" + GetPostBackEventReference(Me.BtnOk).ToString())
        Me.BtnOk.Attributes.Add("onClick", "if(!checkFormData(this)) {return false;};" + GetPostBackEventReference(Me.BtnOk).ToString())


        '.net 4.0 version, but not work.
        'Me.btn_ok.Attributes.Add("onClick", Me.ClientScript.GetPostBackEventReference(Me, Me.btn_ok.ID.ToString))

        Me.BtnSubmit.Attributes.Add("onclick", _
                                    "if(submitOnClick(this)){" + ClientScript.GetPostBackEventReference(Me.BtnSubmit, Nothing) + ";}")


        If Not IsPostBack Then
            
        End If

    End Sub

    Private Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        System.Threading.Thread.Sleep(3000)
        'Class2010.WriteLog("BtnSubmitClick")
        Server.Transfer("Default2.aspx")
    End Sub


    Private Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnOk.Click
        System.Threading.Thread.Sleep(3000)
        'Class2010.WriteLog("BtnOkClick")
        Server.Transfer("Default2.aspx")
    End Sub
End Class