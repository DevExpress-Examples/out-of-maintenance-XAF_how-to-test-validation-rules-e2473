Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports NUnit.Framework
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Persistent.Validation

Namespace TestValidation.Module
	<TestFixture> _
	Public Class EmployeeValidationTests
		Private objectSpace As IObjectSpace
		<SetUp> _
		Public Overridable Sub SetUp()
			objectSpace = New XPObjectSpaceProvider(New MemoryDataStoreProvider()).CreateObjectSpace()
			XafTypesInfo.Instance.RegisterEntity("Employee", GetType(IEmployee))
			XafTypesInfo.Instance.GenerateEntities()
		End Sub
		<Test> _
		Public Sub EmployeeIsValid()
			Dim employee As IEmployee = objectSpace.CreateObject(Of IEmployee)()
			Dim ruleSet As New RuleSet()
			Dim result As RuleSetValidationResult

			result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save)
			Assert.AreEqual(ValidationState.Invalid, result.GetResultItem(EmployeeValidationRules.EmployeeNameIsRequired).State)

			employee.Name = "Mary Tellitson"
			result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save)
			Assert.AreEqual(ValidationState.Valid, result.GetResultItem(EmployeeValidationRules.EmployeeNameIsRequired).State)

			employee.Age = 17
			result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save)
			Assert.AreEqual(ValidationState.Invalid, result.GetResultItem(EmployeeValidationRules.EmployeeIsAdult).State)

			employee.Age = 18
			result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save)
			Assert.AreEqual(ValidationState.Valid, result.GetResultItem(EmployeeValidationRules.EmployeeIsAdult).State)
		End Sub
	End Class
End Namespace
