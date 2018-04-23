Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.Persistent.BaseImpl


Namespace TestValidation.Module
	Public NotInheritable Partial Class TestValidationModule
		Inherits ModuleBase
		Public Sub New()
			ModelDifferenceResourceName = "TestValidation.Module.Model.DesignedDiffs"
			InitializeComponent()
		End Sub
		Public Overrides Sub Setup(ByVal application As XafApplication)
			XafTypesInfo.Instance.RegisterEntity("Employee", GetType(IEmployee))
			MyBase.Setup(application)
		End Sub
	End Class
End Namespace
