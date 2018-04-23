#Application TestValidationWinNoWindowsFormsValidationModule

*Action New(Employee)

*Action Save

*HandleDialog
 Message[0] = Problems were detected during data validation. *
 Message[1] = - "Age" must be greater than or equal to "18".
 Message[2] = - "Name" must not be empty.
 
*OptionalAction OK

*FillForm
 Name = Mary Tellitson
 Age = 17
 
*Action Save
 
*HandleDialog
 Message[0] = Problems were detected during data validation. *
 Message[1] = Mary Tellitson
 Message[2] = - "Age" must be greater than or equal to "18".

*OptionalAction OK

*FillForm
 Age = 18
 
*Action Save
 
*Action Navigation(Employee)

*CheckTable Employee
 Columns = Name, Age
 Row = Mary Tellitson, 18