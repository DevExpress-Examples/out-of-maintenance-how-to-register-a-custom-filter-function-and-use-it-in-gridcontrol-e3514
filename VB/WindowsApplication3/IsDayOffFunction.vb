Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.Data.Filtering

Namespace DXSample
	Public Class IsDayOffFunction
		Implements ICustomFunctionOperatorBrowsable
		Private Const FunctionName As String = "IsDayOff"
		Private Shared ReadOnly instance As New IsDayOffFunction()

		Public Shared Sub Register()
			CriteriaOperator.RegisterCustomFunction(instance)
		End Sub
		Public Shared Function Unregister() As Boolean
			Return CriteriaOperator.UnregisterCustomFunction(instance)
		End Function

		#Region "ICustomFunctionOperatorBrowsable Members"

		Public ReadOnly Property Category() As FunctionCategory Implements ICustomFunctionOperatorBrowsable.Category
			Get
				Return FunctionCategory.DateTime
			End Get
		End Property

		Public ReadOnly Property Description() As String Implements ICustomFunctionOperatorBrowsable.Description
			Get
				Return "IsDayOff"
			End Get
		End Property

		Public Function IsValidOperandCount(ByVal count As Integer) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandCount
		   Return count = 1
		End Function

		Public Function IsValidOperandType(ByVal operandIndex As Integer, ByVal operandCount As Integer, ByVal type As Type) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandType
			Return type Is GetType(DateTime)
		End Function

		Public ReadOnly Property MaxOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MaxOperandCount
			Get
				Return 1
			End Get
		End Property

		Public ReadOnly Property MinOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MinOperandCount
			Get
				Return 1
			End Get
		End Property

		#End Region

		#Region "ICustomFunctionOperator Members"

		Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate
			Dim dt As DateTime = Convert.ToDateTime(operands(0))
			Return dt.DayOfWeek = DayOfWeek.Sunday OrElse dt.DayOfWeek = DayOfWeek.Saturday
		End Function

		Public ReadOnly Property Name() As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name
			Get
				Return FunctionName
			End Get
		End Property

		Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
			Return GetType(Boolean)
		End Function

		#End Region
	End Class
End Namespace