using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Validation;

namespace TestValidation.Module {
    [TestFixture]
    public class EmployeeValidationTests {
        private IObjectSpace objectSpace;
        [SetUp]
        public virtual void SetUp() {
            objectSpace = new XPObjectSpaceProvider(new MemoryDataStoreProvider()).CreateObjectSpace();
            XafTypesInfo.Instance.RegisterEntity("Employee", typeof(IEmployee));
            XafTypesInfo.Instance.GenerateEntities();
        }
        [Test]
        public void EmployeeIsValid() {
            IEmployee employee = objectSpace.CreateObject<IEmployee>();
            RuleSet ruleSet = new RuleSet();
            RuleSetValidationResult result;

            result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save);
            Assert.AreEqual(ValidationState.Invalid,
                result.GetResultItem(EmployeeValidationRules.EmployeeNameIsRequired).State);

            employee.Name = "Mary Tellitson";
            result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save);
            Assert.AreEqual(ValidationState.Valid,
                result.GetResultItem(EmployeeValidationRules.EmployeeNameIsRequired).State);

            employee.Age = 17;
            result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save);
            Assert.AreEqual(ValidationState.Invalid,
                result.GetResultItem(EmployeeValidationRules.EmployeeIsAdult).State);

            employee.Age = 18;
            result = ruleSet.ValidateTarget(objectSpace, employee, DefaultContexts.Save);
            Assert.AreEqual(ValidationState.Valid,
                result.GetResultItem(EmployeeValidationRules.EmployeeIsAdult).State);
        }
    }
}
