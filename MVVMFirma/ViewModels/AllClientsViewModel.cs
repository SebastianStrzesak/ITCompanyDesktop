using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class AllClientsViewModel : WorkspaceViewModel
    {
        #region DB
        private readonly ITCompanyEntities companyEntities; //to pole reprezentuje DB
        #endregion
        #region LoadCommand
        private BaseCommand _LoadCommand; //interfejs wywołuje komendy, o one odpowiednie funkcje (load) pobierającą z DB
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => load());
                return _LoadCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<Clients> _List; //tu będą przechowywani klienci z DB
        public ObservableCollection<Clients> List
        {
            get
            {
                if (_List == null)
                    load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List); //to jest zlecenie odświezena listy na interfejsie
            }
        }
        #endregion
        #region Constructor
        public AllClientsViewModel()
        {
            base.DisplayName = "Clients";
            companyEntities = new ITCompanyEntities();

        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych
        private void load()
        {
            List=new ObservableCollection<Clients>
                (
                    companyEntities.Clients.ToList() //z DB pobieram dane, i rekordy zamieniam na liste
                );
        }
        #endregion
    }
}
