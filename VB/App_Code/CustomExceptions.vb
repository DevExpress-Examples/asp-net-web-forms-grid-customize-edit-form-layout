Imports System
Imports System.Collections.Generic
Imports System.Linq
Namespace CustomExceptions
	Public Class MyException
		Inherits Exception

		Public Sub New(ByVal message As String)
			MyBase.New(message)
		End Sub
	End Class
End Namespace