using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewSoftwareViewModel:WorkspaceViewModel //bo wszystkie zakładki dziedziczą po WSVM (nadklasa dla zakładek)
    {
        public NewSoftwareViewModel() 
        {
            base.DisplayName = "Software";
        }
    }
}
