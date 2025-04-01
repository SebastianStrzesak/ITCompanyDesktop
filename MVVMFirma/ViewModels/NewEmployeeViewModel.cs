using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NewEmployeeViewModel : WorkspaceViewModel
    {
        public NewEmployeeViewModel()
        {
            base.DisplayName = "Employee";
        }
    }
}
