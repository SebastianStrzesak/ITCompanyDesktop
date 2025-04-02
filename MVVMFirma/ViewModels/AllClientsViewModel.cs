using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllClientsViewModel : WorkspaceViewModel
    {
        #region Fields
        private readonly ITCompanyEntities companyEntities; //to pole reprezentuje DB
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public AllClientsViewModel()
        {
            base.DisplayName = "Clients";

        }
        #endregion
        #region Helpers

        #endregion
    }
}
