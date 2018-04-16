using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        SetEditFormLayoutItemVisibility(!ASPxGridView1.IsNewRowEditing);
    }
    private void SetEditFormLayoutItemVisibility(bool value) {
        GetEditFormLayoutItemByName(ASPxGridView1, "ProductID").Visible = value;
    }
    private LayoutItemBase GetEditFormLayoutItemByName(ASPxGridView grid, string name) {
        return grid.EditFormLayoutProperties.FindItemOrGroupByName(name);
    }
    protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e) {
        if (e.ButtonID == "CustomButtonNew") {
            SetEditFormLayoutItemVisibility(false);
            ASPxGridView1.AddNewRow();
        } else {
            SetEditFormLayoutItemVisibility(true);
            ASPxGridView1.StartEdit(e.VisibleIndex);
        }
    }
    protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
        throw new CustomExceptions.MyException("Data inserts aren't allowed in online examples");
    }
    protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
        throw new CustomExceptions.MyException("Data updates aren't allowed in online examples");
    }
    protected void ASPxGridView1_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e) {
        if (e.Exception is CustomExceptions.MyException)
            e.ErrorText = e.Exception.Message;
    }
}