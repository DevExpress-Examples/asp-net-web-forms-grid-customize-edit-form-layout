Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        SetEditFormLayoutItemVisibility((Not ASPxGridView1.IsNewRowEditing))
    End Sub
    Private Sub SetEditFormLayoutItemVisibility(ByVal value As Boolean)
        GetEditFormLayoutItemByName(ASPxGridView1, "ProductID").Visible = value
    End Sub
    Private Function GetEditFormLayoutItemByName(ByVal grid As ASPxGridView, ByVal name As String) As LayoutItemBase
        Return grid.EditFormLayoutProperties.FindItemOrGroupByName(name)
    End Function
    Protected Sub ASPxGridView1_CustomButtonCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomButtonCallbackEventArgs)
        If e.ButtonID = "CustomButtonNew" Then
            SetEditFormLayoutItemVisibility(False)
            ASPxGridView1.AddNewRow()
        Else
            SetEditFormLayoutItemVisibility(True)
            ASPxGridView1.StartEdit(e.VisibleIndex)
        End If
    End Sub
    Protected Sub ASPxGridView1_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Throw New CustomExceptions.MyException("Data inserts aren't allowed in online examples")
    End Sub
    Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Throw New CustomExceptions.MyException("Data updates aren't allowed in online examples")
    End Sub
    Protected Sub ASPxGridView1_CustomErrorText(ByVal sender As Object, ByVal e As ASPxGridViewCustomErrorTextEventArgs)
        If TypeOf e.Exception Is CustomExceptions.MyException Then
            e.ErrorText = e.Exception.Message
        End If
    End Sub
End Class