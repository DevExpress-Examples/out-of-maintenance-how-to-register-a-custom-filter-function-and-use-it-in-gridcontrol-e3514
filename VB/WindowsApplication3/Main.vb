Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Data.Filtering


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		   gridControl1.DataSource = GetData()
		End Sub

		Private Function GetData() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("Name")
			dt.Columns.Add("Date", GetType(DateTime))

			For i As Integer = 0 To 29
				dt.Rows.Add(i, String.Format("Name {0}", i), DateTime.Now.AddDays(i))
			Next i

			Return dt
		End Function

		Private Sub OnShowFilterPopupDate(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventArgs) Handles gridView1.ShowFilterPopupDate
			Dim op As New FunctionOperator("IsDayOff", New OperandProperty(e.Column.FieldName))
			e.List.Add(New DevExpress.XtraEditors.FilterDateElement("IsDayOff", "", op))
		End Sub
	End Class
End Namespace
