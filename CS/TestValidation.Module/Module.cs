using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;
using DevExpress.Persistent.BaseImpl;


namespace TestValidation.Module {
    public sealed partial class TestValidationModule : ModuleBase {
        public TestValidationModule() {
            ModelDifferenceResourceName = "TestValidation.Module.Model.DesignedDiffs";
            InitializeComponent();
        }
        public override void Setup(XafApplication application) {
            XafTypesInfo.Instance.RegisterEntity("Employee", typeof(IEmployee));
            base.Setup(application);
        }
    }
}
