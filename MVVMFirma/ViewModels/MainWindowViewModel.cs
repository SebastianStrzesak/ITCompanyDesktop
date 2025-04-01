using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using MVVMFirma.Helper;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands // Właściwość dostępowa do komend, które są dostępne w aplikacji
        {
            get
            {
                if (_Commands == null) // Sprawdza, czy komendy zostały już utworzone. Jeśli nie, tworzy je.
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }

        private List<CommandViewModel> CreateCommands() // Metoda tworząca i zwracająca listę komend dostępnych w aplikacji.
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Employees",
                    new BaseCommand(() => this.ShowAll<AllEmployeesViewModel>())),
                new CommandViewModel(
                    "Employee",
                    new BaseCommand(() => this.CreateView(new NewEmployeeViewModel()))),

                new CommandViewModel(
                    "Softwares",
                    new BaseCommand(() => this.ShowAll<AllSoftwaresViewModel>())),
                new CommandViewModel(
                    "Software",
                    new BaseCommand(() => this.CreateView(new NewSoftwareViewModel()))),

                new CommandViewModel(
                    "Equipments",
                    new BaseCommand(() => this.ShowAll<AllEquipmentViewModel>())),
                new CommandViewModel(
                    "Equipment",
                    new BaseCommand(() => this.CreateView(new NewEquipmentViewModel()))),

                new CommandViewModel(
                    "Salaries",
                    new BaseCommand(() => this.ShowAll<AllSalariesViewModel>())),
                new CommandViewModel(
                    "Salarie",
                    new BaseCommand(() => this.CreateView(new NewSalarieViewModel()))),

                new CommandViewModel(
                    "Leaves",
                    new BaseCommand(() => this.ShowAll<AllLeavesViewModel>())),
                new CommandViewModel(
                    "Leave",
                    new BaseCommand(() => this.CreateView(new NewLeaveViewModel()))),

                new CommandViewModel(
                    "PerformanceReviews",
                    new BaseCommand(() => this.ShowAll<AllPerformanceReviewsViewModel>())),
                new CommandViewModel(
                    "PerformanceReview",
                    new BaseCommand(() => this.CreateView(new NewPerformanceReviewViewModel()))),

                new CommandViewModel(
                    "Departments",
                    new BaseCommand(() => this.ShowAll<AllDepartmentsViewModel>())),
                new CommandViewModel(
                    "Department",
                    new BaseCommand(() => this.CreateView(new NewDepartmentViewModel()))),

                new CommandViewModel(
                    "Invoices",
                    new BaseCommand(() => this.ShowAll<AllInvoicesViewModel>())),
                new CommandViewModel(
                    "Invoice",
                    new BaseCommand(() => this.CreateView(new NewInvoiceViewModel()))),

                new CommandViewModel(
                    "Trainings",
                    new BaseCommand(() => this.ShowAll<AllTrainingsViewModel>())),
                new CommandViewModel(
                    "Training",
                    new BaseCommand(() => this.CreateView(new NewTrainingViewModel()))),

                new CommandViewModel(
                    "Clients",
                    new BaseCommand(() => this.ShowAll<AllClientsViewModel>())),
                new CommandViewModel(
                    "Client",
                    new BaseCommand(() => this.CreateView(new NewClientViewModel()))),

                new CommandViewModel(
                    "ProjectBudgets",
                    new BaseCommand(() => this.ShowAll<AllProjectBudgetsViewModel>())),
                new CommandViewModel(
                    "ProjectBudget",
                    new BaseCommand(() => this.CreateView(new NewProjectBudgetViewModel()))),

                new CommandViewModel(
                    "Projects",
                    new BaseCommand(() => this.ShowAll<AllProjectsViewModel>())),
                new CommandViewModel(
                    "Project",
                    new BaseCommand(() => this.CreateView(new NewProjectViewModel()))),

                new CommandViewModel(
                    "TimeSheets",
                    new BaseCommand(() => this.ShowAll<AllTimeSheetsViewModel>())),
                new CommandViewModel(
                    "TimeSheet",
                    new BaseCommand(() => this.CreateView(new NewTimesheetViewModel()))),

                new CommandViewModel(
                    "Tasks",
                    new BaseCommand(() => this.ShowAll<AllTasksViewModel>())),
                new CommandViewModel(
                    "Task",
                    new BaseCommand(() => this.CreateView(new NewTaskViewModel()))),

                new CommandViewModel(
                    "TaskAssignments",
                    new BaseCommand(() => this.ShowAll<AllTaskAssignmentsViewModel>())),
                new CommandViewModel(
                    "TaskAssignment",
                    new BaseCommand(() => this.CreateView(new NewTaskAssignmentViewModel())))
            };
        }
        #endregion

        #region Workspaces
        // Właściwość dostępowa do kolekcji przestrzeni roboczych (widoków), które są otwarte w aplikacji.
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        // Obsługuje zmiany w kolekcji przestrzeni roboczych (dodawanie lub usuwanie widoków).
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e) // Obsługuje zdarzenie żądania zamknięcia przestrzeni roboczej.
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }

        private void ShowAll<TWorkspace>() where TWorkspace : WorkspaceViewModel, new()
        {
            TWorkspace workspace =
                this.Workspaces.FirstOrDefault(vm => vm is TWorkspace) as TWorkspace;
            if (workspace == null)
            {
                workspace = new TWorkspace();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        // Ustawia przestrzeń roboczą jako aktywną w widoku.
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
