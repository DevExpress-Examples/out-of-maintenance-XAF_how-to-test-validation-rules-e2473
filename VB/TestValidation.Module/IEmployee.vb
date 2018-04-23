Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation

Namespace TestValidation.Module
	<DomainComponent, DefaultClassOptions, ImageName("BO_Employee")> _
	Public Interface IEmployee
		<RuleRequiredField(EmployeeValidationRules.EmployeeNameIsRequired, DefaultContexts.Save)> _
		Property Name() As String
		<RuleValueComparison(EmployeeValidationRules.EmployeeIsAdult, DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 18)> _
		Property Age() As Integer
	End Interface
	Public Class EmployeeValidationRules
		Public Const EmployeeNameIsRequired As String = "EmployeeNameIsRequired"
		Public Const EmployeeIsAdult As String = "EmployeeIsAdult"
	End Class

End Namespace
