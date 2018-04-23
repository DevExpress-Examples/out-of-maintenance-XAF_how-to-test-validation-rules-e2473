#Application TestValidationWin
#Application TestValidationWeb

*Action New(Employee)

*Action Save

*CheckValidationResult
 Message = Problems were detected during data validation. *
 Info = "Name" must not be empty.
 Info = "Age" must be greater than or equal to "18".

*OptionalAction Close

*FillForm
 Name = Mary Tellitson
 Age = 17
 
*Action Save
 
*CheckValidationResult
 Message = Problems were detected during data validation. *
 Columns = Target, Description
 Info = Mary Tellitson, "Age" must be greater than or equal to "18".
 
*OptionalAction Close

*FillForm
 Age = 18
 
*Action Save
 
*Action Navigation(Employee)

*CheckTable Employee
 Columns = Name, Age
 Row = Mary Tellitson, 18
